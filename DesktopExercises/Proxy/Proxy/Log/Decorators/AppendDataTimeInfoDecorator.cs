using Proxy.DateTimeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log.Decorators
{
    public class AppendDataTimeInfoDecorator : ILogger
    {
        private readonly ILogger logger;

        public AppendDataTimeInfoDecorator(ILogger logger)
        {
            this.logger = logger;
        }
        public void WriteLine(string content)
        {
            var appendContent = $"{CurrentTime.Instance.CurrentTime().ToString("dd/MM/yyyy/HH:mm:ss")} {content}";
            logger.WriteLine(appendContent);
        }
    }
}
