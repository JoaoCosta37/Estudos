using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using Xamarin.Forms.Xaml;
using System.Globalization;
using PomodoroApp.Resources;

namespace PomodoroApp.Views.Markup
{
    public class MessageExtention : IMarkupExtension<string>
    {
        public string MessageKey { get; set; }
        public string ProvideValue(IServiceProvider serviceProvider)
        {
            var resource = new ResourceManager(typeof(Messages));
            var message = resource.GetString(MessageKey, CultureInfo.CurrentCulture);
            return message;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<string>).ProvideValue(serviceProvider);
        }
    }
}
