using ImTools;
using PomodoroApp.Enums;
using PomodoroApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public int DailyCount
        {
            get { return PomodoroControl.DailyCount; }
            set
            {
                this.PomodoroControl.DailyCount = value;
                RaisePropertyChanged();
            }
        }
        public int CountToLongBreak
        {
            get { return PomodoroControl.CountToLongBreak; }
            set
            {
                this.PomodoroControl.CountToLongBreak = value;
                RaisePropertyChanged();
            }
        }
        public int PomodoroTimesBeforeLongBreak
        {
            get { return PomodoroControl.PomodoroTimesBeforeLongBreak; }
            set
            {
                this.PomodoroControl.PomodoroTimesBeforeLongBreak = value;
                RaisePropertyChanged();
            }
        }
        //public bool PomodoroFinished
        //{
        //    get { return PomodoroControl.ProgressPosition == (int)TimeType.POMODORO; }
        //    set
        //    {
        //        this.PomodoroControl.ProgressPosition = value;
        //        RaisePropertyChanged();
        //    }
        //}
        public int Progress
        {
            get { return PomodoroControl.Progress; }
            set
            {
                this.PomodoroControl.Progress = value;
                RaisePropertyChanged();
            }
        }
        //public int DailyTotal
        //{
        //    get { return PomodoroControl.DailyTotal; }
        //    set
        //    {
        //        this.PomodoroControl.DailyTotal = value;
        //        RaisePropertyChanged();
        //    }
        //}
        public int DailyGoal
        {
            get { return PomodoroControl.DailyGoal; }
            set
            {
                this.PomodoroControl.DailyGoal = value;
                RaisePropertyChanged();
            }
        }
        public int TimeTypeValue
        {
            get { return this.PomodoroControl.TimeTypeValue; }
            set
            {
                this.PomodoroControl.TimeTypeValue = value;
                RaisePropertyChanged();
            }
        }
        //public TimeType CurrentType
        //{
        //    get
        //    {
        //        return this.PomodoroControl.CurrentType;
        //        //var result = (TimeType)Enum.Parse(typeof(TimeType), PomodoroControl.CurrentType);
        //        //return result;
        //    }
        //    set
        //    {
        //        //this.PomodoroControl.CurrentType = value.ToString();
        //        this.PomodoroControl.CurrentType = value;
        //        RaisePropertyChanged();
        //    }
        //}
        public List<TimeDurationViewModel> Durations
        {
            get
            {
                return  this.PomodoroControl.Durations.Map((x) => new TimeDurationViewModel(x)).ToList();
            }
            set
            {
                this.PomodoroControl.Durations = value.Map((x) => x.TimeDuration).ToList();
                RaisePropertyChanged();
            }
        }
    }
}
