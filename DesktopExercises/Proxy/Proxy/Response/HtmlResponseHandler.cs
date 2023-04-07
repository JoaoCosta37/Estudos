using Proxy.Customizers.HtmlCustomizer;
using Proxy.Customizers.HtmlCustomizer.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Response
{
    public class HtmlResponseHandler : IResponseHandler
    {
        public Stream GetResponse(Stream responseFromWebSiteBeingRelayedStream, WebResponse responseFromWebSiteBeingRelayed)
        {
            var reader = new StreamReader(responseFromWebSiteBeingRelayedStream);
            string html = reader.ReadToEnd();
            ICustomizeHtmlFactory customizeHtmlFactory = new CustomizeHtmlFactory();
            var custom = customizeHtmlFactory.GetCustomizeHmtl();
            var stream = custom.CustomizeHtml(html);
            return stream;
        }
    }
}
