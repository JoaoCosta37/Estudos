using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class GetConfig :IGetConfig
    {
        private const string configFile = "C:\\Users\\Joaoc\\Documents\\GitHub\\DesktopExercises\\MyWebServer\\config.txt";

        Dictionary<string, string> configs = new Dictionary<string, string>();

        public GetConfig()
        {
            configs = loadContent();
        }
        public string GetContent(string config)
        {
            return configs[config];
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
                    int index = lineConfig.IndexOf('=') ;
                    var configName = lineConfig.Substring(0, index);
                    var configDescription = lineConfig.Substring(index+1);
                    contentConfig.Add(configName.Trim(), configDescription.Trim());

                    //var lineSplited = lineConfig.Split(new char[] { '=' }, 2);
                    //contentConfig.Add(lineSplited[0].Trim(), lineSplited[1].Trim());

                    lineConfig = sr.ReadLine();
                }
                return contentConfig;
            }
        
        }
    }
}
