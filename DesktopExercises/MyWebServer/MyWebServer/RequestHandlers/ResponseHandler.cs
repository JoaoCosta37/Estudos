using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public abstract class ResponseHandler
    {
        private readonly HttpListenerResponse resp;
        protected readonly string requestedResource;

        public ResponseHandler(HttpListenerResponse resp, string requestedResource)
        {
            this.resp = resp;
            this.requestedResource = requestedResource;
        }

        abstract public void SendResponse();
        
        protected void writeResponse(BinaryReader br)
        {
            byte[] buffer = new byte[2048];
            int bytesRead;
            while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
            {
                resp.OutputStream.Write(buffer, 0, bytesRead);
            }

        }
    }
}
