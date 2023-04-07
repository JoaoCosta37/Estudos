using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;
using TimeRecorderApp.Resources;
using Xamarin.Forms.Xaml;

namespace TimeRecorderApp.Views.Markup
{
    public class MessageExtention : IMarkupExtension<string>
    {
        public string MessageKey { get; set; }  
        public string ProvideValue(IServiceProvider serviceProvider)
        {
            var resouces = new ResourceManager(typeof(Messages));
            var message = resouces.GetString(MessageKey, CultureInfo.CurrentCulture);
            return message;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
