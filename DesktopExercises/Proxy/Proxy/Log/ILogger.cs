using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log
{
    public interface ILogger
    {
        void WriteLine(string content);
    }
}
