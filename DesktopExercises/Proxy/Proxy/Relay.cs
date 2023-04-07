using Proxy.Customizers.HtmlCustomizer;
using Proxy.Log;
using Proxy.Response;
using Proxy.Response.Factory;
using SimpleHttpProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Relay
    {
        private readonly HttpListenerContext originalContext;
        private IResponseHandlerFactory responseFactory =  new ResponseHandlerFactory();
        private IResponseHandler responseHandler;

        public Relay(HttpListenerContext originalContext)
        {
            this.originalContext = originalContext;
        }

        public async void ProcessRequest()
        {
            string rawUrl = originalContext.Request.RawUrl;
            Logger.WriteLine("Proxy receive a request for: " + rawUrl);

            var relayRequest = (HttpWebRequest)WebRequest.Create(rawUrl);
            relayRequest.KeepAlive = false;
            relayRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            relayRequest.UserAgent = this.originalContext.Request.UserAgent;

            var requestData = new RequestState(relayRequest, originalContext);

            var response = await relayRequest.GetResponseAsync();

            ResponseCallBack(response, requestData);
            

        }

        private void ResponseCallBack(WebResponse responseFromWebSiteBeingRelayed, RequestState requestData)
        {
            Logger.WriteLine("Proxy receive a response from " + requestData.context.Request.RawUrl);

            this.responseHandler = this.responseFactory.GetResponseHandler(responseFromWebSiteBeingRelayed, requestData);


          
            
                using (var responseStreamFromWebSiteBeingRelayed = responseFromWebSiteBeingRelayed.GetResponseStream())
                {
                    var originalResponse = requestData.context.Response;

                    var streamResponse =  responseHandler.GetResponse(responseStreamFromWebSiteBeingRelayed, responseFromWebSiteBeingRelayed);

                    streamResponse.CopyTo(originalResponse.OutputStream);

                    originalResponse.OutputStream.Close();
                }
            }
        }
    }

