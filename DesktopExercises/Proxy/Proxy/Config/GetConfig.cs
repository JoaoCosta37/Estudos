using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Config
{
    public class GetConfig : IGetConfig
    {
        private const string configFile = "C:\\Users\\Joaoc\\Documents\\GitHub\\DesktopExercises\\Proxy\\config.txt";
        Dictionary<string, string> configs = new Dictionary<string, string>();
        public GetConfig()
        {
            configs = loadContent();
        }
        public string GetContent(string key)
        {
            return configs[key];
        }
        Dictionary<string, string> loadContent()
        {
            string lineConfig;
            Dictionary<string, string> contentConfig = new Dictionary<string, string>();

            using (StreamReader sr = new StreamReader(configFile))
            {
                lineConfig = sr.ReadLine();
                while (lineConfig != null)
                {
                    if (!lineConfig.StartsWith("--")) //tratar comentário no arquivo de config
                    {
                    int index = lineConfig.IndexOf('=');
                    var configKey = lineConfig.Substring(0, index);
                    var configValue = lineConfig.Substring(index + 1);
                    contentConfig.Add(configKey.Trim(), configValue.Trim());
                    }
                    lineConfig = sr.ReadLine();
                }
                return contentConfig;
            }
        }
    }
}
