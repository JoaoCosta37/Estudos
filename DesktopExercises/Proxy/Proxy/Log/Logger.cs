using Proxy.Log.Decorators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Log
{
    public class Logger
    {
        public static List<ILogger> instances;
        public static void WriteLine(string content)
        {
            foreach (var instance in instances) instance.WriteLine(content);
        }
        public static void SetLogger(List<ILogger> loggers)
        {
            if(instances == null)
            {
                instances = loggers.Select((log) => new AppendDataTimeInfoDecorator(log)).ToList<ILogger>();
            }

        }

    }
}
