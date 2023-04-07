using Proxy.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log
{
    public class TxtLogger : ILogger
    {
        private string logFile = Configs.GetConfig("logFile");

        public void WriteLine(string content)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true, Encoding.UTF8))
            {
                sw.WriteLine(content);
            }
        }
    }
}
