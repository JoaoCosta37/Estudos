using PomodoroApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.ViewModels
{
    public class TimeDurationViewModel : BindableBase
    {
        private TimeDuration timeDuration;

        public TimeDurationViewModel(TimeDuration timeDuration)
        {
            this.timeDuration = timeDuration;
        }
        public TimeDuration TimeDuration
        {
            get => timeDuration;
            set
            {
                this.timeDuration = value;
                RaisePropertyChanged();
            }
        }

        public string Description
        {
            get => TimeDuration.Description;
            set
            {
                this.TimeDuration.Description = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan Duration
        {
            get => TimeDuration.Duration;
            set
            {
                this.TimeDuration.Duration = value;
                RaisePropertyChanged();
            }
        }


    }
}
