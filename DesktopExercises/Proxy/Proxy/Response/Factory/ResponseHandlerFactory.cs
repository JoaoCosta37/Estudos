using Proxy.Config;
using Proxy.Customizers.HtmlCustomizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Response.Factory
{
    public class ResponseHandlerFactory : IResponseHandlerFactory
    {
        public ResponseHandlerFactory()
        {

        }
        public IResponseHandler GetResponseHandler(WebResponse responseFromWebSiteBeingRelayed, RequestState requestData)
        {
            if (responseFromWebSiteBeingRelayed.ContentType.Contains("text/html") && Configs.GetConfig("customizeHtml") != "none")
            {
                return new HtmlResponseHandler();
            }
            else if (responseFromWebSiteBeingRelayed.ContentType.Contains("image") && Configs.GetConfig("customizeImage") != "none")
            {
                return new ImageResponseHandler();
            }
            else
            {
                return new DefaultResponseHandler();
            }
        }
    }
}

