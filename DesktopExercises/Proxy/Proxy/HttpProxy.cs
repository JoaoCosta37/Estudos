
using Proxy.Config;
using Proxy.Log;
using SimpleHttpProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    public class HttpProxy
    {

        public HttpProxy()
        {

        }
        public void StartListener()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(Configs.GetConfig("localServerPort"));
            listener.Start();

            Logger.WriteLine("Listening...");

            Task listenTask = HandleIncomingConnections(listener);
            listenTask.GetAwaiter().GetResult();
            listener.Close();
        }

        async Task HandleIncomingConnections(HttpListener listener)
        {
            while (true)
            {
                var ctx = await listener.GetContextAsync();
                Relay relay = new Relay(ctx);
                relay.ProcessRequest();
            }
        }
    }
}
