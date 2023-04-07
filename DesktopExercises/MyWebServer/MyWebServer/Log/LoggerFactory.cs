using MyWebServer.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Log
{
    public class LoggerFactory : ILoggerFactory
    {

        public LoggerFactory()
        {
        }
        public ILogger GetLogger()
        {
            var writeMethod = Configs.GetConfig("writeMethod");
            var logFile = Configs.GetConfig("logFile");
            if (writeMethod == "logTxt")
            {
                return new AppendDateTimeInfoDecorator(new TxtLogger(logFile));
            }
            else
            {
                return new AppendDateTimeInfoDecorator(new ConsoleLogger());
            }
        }
    }
}
