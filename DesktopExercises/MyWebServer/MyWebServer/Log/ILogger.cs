using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public interface ILogger
    {
        void WriteLine(string content);
    }
}
