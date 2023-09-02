using PomodoroApp.Enums;
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

        public TimeType TimeType
        {
            get => TimeDuration.TimeType;
            set
            {
                this.TimeDuration.TimeType = value;
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

        public override bool Equals(object obj)
        {
            return obj is TimeDurationViewModel model &&
                   EqualityComparer<TimeDuration>.Default.Equals(timeDuration, model.timeDuration) &&
                   EqualityComparer<TimeDuration>.Default.Equals(TimeDuration, model.TimeDuration) &&
                   TimeType == model.TimeType &&
                   Duration.Equals(model.Duration);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(timeDuration, TimeDuration, TimeType, Duration);
        }
    }
}
