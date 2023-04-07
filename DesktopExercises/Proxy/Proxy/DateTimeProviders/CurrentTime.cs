using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DateTimeProviders
{
    public class CurrentTime
    {
        private static ICurrentTimeProvider instance;

        public static ICurrentTimeProvider Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException("Current Time Provider não iniciado");
                return instance;
            }
        }
        public static void SetProvider(ICurrentTimeProvider currentTime)
        {
            if(instance == null)
            {
                instance = currentTime;
            }
        }
    }
}
