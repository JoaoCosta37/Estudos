using MyWebServer.DateTimeProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Log
{
    public class AppendDateTimeInfoDecorator : ILogger
    {
        private readonly ILogger logger;

        public AppendDateTimeInfoDecorator(ILogger logger)
        {
            this.logger = logger;
        }
        public void WriteLine(string content)
        {
            var appendContent = $"{CurrentTime.Instance.CurrentTime().ToString("ddMMyyyyHHmmss")} {content}";

            logger.WriteLine(appendContent);
        }
    }
}
