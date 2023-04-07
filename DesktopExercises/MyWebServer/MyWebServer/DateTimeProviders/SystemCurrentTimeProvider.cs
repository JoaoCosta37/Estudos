using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.DateTimeProviders
{
    public class SystemCurrentTimeProvider : ICurrentTimeProvider
    {
        public DateTime CurrentTime()
        {
            //communicação com Banco de Dados;
            return DateTime.Now;
        }
    }
}
