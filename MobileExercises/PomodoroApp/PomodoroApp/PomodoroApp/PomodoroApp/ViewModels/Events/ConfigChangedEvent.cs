using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.ViewModels.Events
{
    public  class ConfigChangedEvent : PubSubEvent<ConfigChangedEventArgs>
    {

    }
    public class ConfigChangedEventArgs
    {
        public string ConfigName { get; set; }
    }
}
