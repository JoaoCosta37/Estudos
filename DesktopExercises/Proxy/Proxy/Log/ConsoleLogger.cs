using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log
{
    public class ConsoleLogger : ILogger
    {
    
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }

    }
}
