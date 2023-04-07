using MyWebServer.DateTimeProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class TxtLogger : ILogger
    {
        private readonly string logFile;
        private int requestCount = 0;

        public TxtLogger(string logFile)
        {
            this.logFile = logFile;
        }

        public void WriteLine(string content)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.WriteLine(content);
            }
        }
    }
}
