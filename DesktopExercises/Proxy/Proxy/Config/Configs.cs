using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Config
{
    public class Configs
    {
        private static IGetConfig instance;
        public static string GetConfig(string Key)
        {
            if (instance == null)
                throw new InvalidOperationException("Nenhum Arquivo de configuração carregado");
            return instance.GetContent(Key);
        }

        public static IGetConfig Config
        {
            get
            {
                return instance;
            }
        }

        public static void SetConfig(IGetConfig getConfig)
        {
            if (instance == null)
            {
                instance = getConfig;
            }
        }
    }
}
