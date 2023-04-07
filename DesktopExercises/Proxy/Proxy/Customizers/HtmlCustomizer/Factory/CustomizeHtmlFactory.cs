using Proxy.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.HtmlCustomizer.Factory
{
    public class CustomizeHtmlFactory : ICustomizeHtmlFactory
    {
        public ICustomizeHtmlResponse GetCustomizeHmtl()
        {
            var customHtmlConfigs = Configs.GetConfig("customizeHtml").Split("?");
            var htmlCustomizeConfig = customHtmlConfigs[0];
            var parameterString = customHtmlConfigs.Length > 1 ? customHtmlConfigs[1] : "none";

            // var separator = Configs.GetConfig("customizeHtml").IndexOf("?");
            // var htmlCustomizeConfig = separator == -1 ? Configs.GetConfig("customizeHtml").Trim() :  Configs.GetConfig("customizeHtml").Substring(0, separator).Trim();
            // var parameterString = separator == -1 ? "none" : Configs.GetConfig("customizeHtml").Substring(separator + 1).Trim();
            var customizeParameters =  parameterString.Split(';');
 
            if (htmlCustomizeConfig == "removeTag")
            {
                return new RemoveTagHtml(customizeParameters);
            }
            else 
                throw new InvalidOperationException("Invalid Customizer!");
        }
    }
}
