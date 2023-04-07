using Proxy;
using Proxy.Config;
using Proxy.DateTimeProviders;
using Proxy.Log;
using Proxy.Log.Factory;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace SimpleHttpProxy
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CurrentTime.SetProvider(new SystemCurrentTimeProvider());
            Configs.SetConfig(new GetConfig());
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.ConfigureLogger();
            HttpProxy server = new HttpProxy();
            server.StartListener();
        }
    }

 



   

}
