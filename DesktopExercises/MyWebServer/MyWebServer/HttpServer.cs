using MyWebServer.Config;
using MyWebServer.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class HttpServer
    {
        private readonly string url;
        private HttpListener listener;
        private readonly string folder;
        private readonly string writeMethod;
        private readonly IResponseFactory responseFactory;
        private readonly ILoggerFactory loggerFactory;
        private ILogger logger;
        static int requestCount = 0;

        public HttpServer(IResponseFactory responseFactory, ILoggerFactory loggerFactory)
        {
            this.url = Configs.GetConfig("url");
            this.folder = Configs.GetConfig("folder");
            this.writeMethod = Configs.GetConfig("writeMethod");
            this.responseFactory = responseFactory;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.GetLogger();
        }
        public void StartListener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            logger.WriteLine($"Listening for connections on {url}");
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();
            listener.Close();
        }
        public async Task HandleIncomingConnections()
        {
            bool runServer = true;

            while (runServer)
            {
                HttpListenerContext ctx = await listener.GetContextAsync();
                HttpListenerRequest req = ctx.Request;
                response(ctx, req);
            }
        }
        void response(HttpListenerContext ctx, HttpListenerRequest req)
        {
            HttpListenerResponse resp = ctx.Response;
            LogRequest(req);
            
            var handler = responseFactory.GetResponseHandler(folder, resp,req);
            handler.SendResponse();
            resp.Close();
        }
        public void LogRequest(HttpListenerRequest req)
        {
            logger.WriteLine($"Request #: {++requestCount}");
            logger.WriteLine(req.Url.ToString());
            logger.WriteLine(req.HttpMethod);
            logger.WriteLine(req.UserHostName);
            logger.WriteLine(req.UserAgent);
            logger.WriteLine("");
        }
        
    }
}
