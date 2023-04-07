using MyWebServer.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class ResponseFactory : IResponseFactory
    {
        private string mainPage;


        public ResponseFactory()
        {
            this.mainPage = Configs.GetConfig("mainPage");
        }
        public ResponseHandler GetResponseHandler(String rootFolder, HttpListenerResponse resp, HttpListenerRequest req)
        {
            string requestedResource = getResourceFromRequest(req);

            var resourcePath = Path.Combine(rootFolder, requestedResource);

            if (File.Exists(resourcePath))
                return new FileResponseHandler(resp, requestedResource, rootFolder);

            if (requestedResource == "index.html")
                return new AvailableFilesResponseHandler(resp, requestedResource, rootFolder);

            return new ErrorResponseHandler(resp, requestedResource, rootFolder, ErrorCode.E404);
        }

        private string getResourceFromRequest(HttpListenerRequest req)
        {
            return req.RawUrl.Substring(1) == "" ? mainPage : req.RawUrl.Substring(1);
        }
    }
}
