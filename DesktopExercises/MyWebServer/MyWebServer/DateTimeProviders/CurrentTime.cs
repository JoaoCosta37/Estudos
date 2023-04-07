using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.DateTimeProviders
{
    public class CurrentTime
    {
        //SINGLETON

        private static ICurrentTimeProvider instance;

        public static ICurrentTimeProvider Instance { get {
                if(instance == null)
                {
                    throw new InvalidOperationException("Current Time Provider não iniciado");
                }
                return instance;

            }
        }

        public static void SetProvider(ICurrentTimeProvider currentTimeProvider)
        {
            if (instance == null)
            {
               instance = currentTimeProvider;
            }
        }
    }
}
