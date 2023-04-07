using Proxy.Config;
using Proxy.Log.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log.Factory
{
    public class LoggerFactory : ILoggerFactory
    {
        public LoggerFactory()
        {

        }
        public void ConfigureLogger()
        {
            var writeMethods = Configs.Config.GetWriteMethods();

            Dictionary<WriteMethods, ILogger> loggers = new Dictionary<WriteMethods,ILogger>();
            foreach (var method in writeMethods)
            {
                if (method == WriteMethods.logTxt)
                {
                    if(!loggers.ContainsKey(method))
                    loggers.Add(method,new TxtLogger());
                }
                else if (method == WriteMethods.dataBase)
                {
                    if (!loggers.ContainsKey(method))
                        loggers.Add(method, new DataBaseLogger());
                }
                else if (method == WriteMethods.none || method == WriteMethods.console)
                {
                    if (!loggers.ContainsKey(method))
                        loggers.Add(method,new ConsoleLogger());
                }

            }
            Logger.SetLogger(loggers.Values.ToList());
        }
    }
}
