using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.HtmlCustomizer
{
    public interface ICustomizeHtmlResponse
    {
        public MemoryStream CustomizeHtml(string html);
    }
}
