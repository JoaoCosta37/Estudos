using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Config
{
    public static class ConfigsExtentions
    {
        public static List<WriteMethods> GetWriteMethods(this IGetConfig configs)
        {
            var list = new List<WriteMethods>();
            var writeMethodConfig = configs.GetContent("writeMethod");

            string[] methods = writeMethodConfig.Split(';');

            foreach (string method in methods)
            {
               if( Enum.TryParse<WriteMethods>(method, true, out WriteMethods writeMethod))
                {
                    list.Add(writeMethod);
                }

            }

            return list;
        }

    }
}
