using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class FileResponseHandler : ResponseHandler
    {
        private readonly string rootFolder;

        public FileResponseHandler(HttpListenerResponse resp, string requestedResource, string rootFolder) : base(resp, requestedResource)
        {
            this.rootFolder = rootFolder;
        }

        public override void SendResponse()
        {
            var fullPath = Path.Combine(rootFolder, requestedResource);

            if (File.Exists(fullPath))
            {

                using (FileStream fs = new FileStream(fullPath,
                                                                  FileMode.Open,
                                                                  FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        writeResponse(br);
                    }
                }
            }
        }
    }
}
