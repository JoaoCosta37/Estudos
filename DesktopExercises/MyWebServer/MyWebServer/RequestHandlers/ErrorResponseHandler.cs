using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class ErrorResponseHandler : ResponseHandler
    {
        private readonly ErrorCode errorCode;
        private readonly string rootFile = @"DefaultPages\error";

        public ErrorResponseHandler(HttpListenerResponse resp, string requestedResource, string rootFolder, ErrorCode errorCode) : base(resp, requestedResource)
        {
            this.errorCode = errorCode;
        }
        public override void SendResponse()
        {
            var path = Path.Combine(rootFile, $"{errorCode.ToString().Substring(1)}.html");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    writeResponse(br);
                }
            }
        }
    }
}
