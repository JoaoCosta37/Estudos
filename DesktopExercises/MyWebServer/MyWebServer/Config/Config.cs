using MyWebServer.DateTimeProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Config
{
    public class Configs
    {
        private static IGetConfig instance;

        public static string GetConfig(string config)
        {
            if (instance is null)
                throw new InvalidOperationException("Nenhum Arquivo de Configuração Carregado");
            return instance.GetContent(config);
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
