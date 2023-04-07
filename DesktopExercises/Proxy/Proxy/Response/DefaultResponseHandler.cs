using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Response
{
    public class DefaultResponseHandler : IResponseHandler
    {
        public Stream GetResponse(Stream responseFromWebSiteBeingRelayedStream, WebResponse responseFromWebSiteBeingRelayed)
        {
            return responseFromWebSiteBeingRelayedStream;
        }
    }
}
