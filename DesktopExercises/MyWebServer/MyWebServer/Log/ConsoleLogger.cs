using MyWebServer.DateTimeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class ConsoleLogger : ILogger
    {
      
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}
