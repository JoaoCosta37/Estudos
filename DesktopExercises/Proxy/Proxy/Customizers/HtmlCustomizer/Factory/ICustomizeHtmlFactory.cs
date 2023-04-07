using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.HtmlCustomizer.Factory
{
    public interface ICustomizeHtmlFactory
    {
        ICustomizeHtmlResponse GetCustomizeHmtl();
    }
}
