using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Response
{
    public interface IResponseHandler
    {
        Stream GetResponse(Stream responseFromWebSiteBeingRelayedStream, WebResponse responseFromWebSiteBeingRelayed);
    }
}
