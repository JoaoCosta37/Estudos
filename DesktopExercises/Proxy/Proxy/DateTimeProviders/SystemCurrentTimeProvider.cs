using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.DateTimeProviders
{
    public class SystemCurrentTimeProvider : ICurrentTimeProvider
    {

        public DateTime CurrentTime()
        {
            return DateTime.Now;
        }
    }
}
