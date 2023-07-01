using PomodoroApp.Enums;
using PomodoroApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.ViewModels
{
    public class PomodoroControlViewModel : BindableBase
    {
        private PomodoroControl pomodoroControl;

        public PomodoroControlViewModel(PomodoroControl pomodoroControl)
        {
            this.pomodoroControl = pomodoroControl;
        }
        public PomodoroControl PomodoroControl
        {
            get { return pomodoroControl; }
            set
            {
                this.pomodoroControl = value;
                RaisePropertyChanged();
            }
        }
        public int Count
        {
            get { return PomodoroControl.Count; }
            set
            {
                this.PomodoroControl.Count = value;
                RaisePropertyChanged();
            }
        }
        public int PomodoroTimesBeforeLongPause
        {
            get { return PomodoroControl.PomodoroTimesBeforeLongPause; }
            set
            {
                this.PomodoroControl.PomodoroTimesBeforeLongPause = value;
                RaisePropertyChanged();
            }
        }
        public bool PomodoroFinished
        {
            get { return PomodoroControl.PomodoroFinished; }
            set
            {
                this.PomodoroControl.PomodoroFinished = value;
                RaisePropertyChanged();
            }
        }
        public int DailyTotal
        {
            get { return PomodoroControl.DailyTotal; }
            set
            {
                this.PomodoroControl.DailyTotal = value;
                RaisePropertyChanged();
            }
        }
        public TimeType CurrentType
        {
            get {
                return this.PomodoroControl.CurrentType;
                //var result = (TimeType)Enum.Parse(typeof(TimeType), PomodoroControl.CurrentType);
                //return result;
            }
            set
            {
                //this.PomodoroControl.CurrentType = value.ToString();
                this.PomodoroControl.CurrentType = value;
                RaisePropertyChanged();
            }
        }
        public List<TimeDuration> Durations
        {
            get { return PomodoroControl.Durations; }
            set
            {
                this.PomodoroControl.Durations = value;
                RaisePropertyChanged();
            }
        }
    }
}
