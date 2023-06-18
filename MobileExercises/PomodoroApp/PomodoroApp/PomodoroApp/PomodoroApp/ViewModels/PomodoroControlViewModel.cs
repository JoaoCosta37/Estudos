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
        public bool PomodoroFineshed
        {
            get { return PomodoroControl.PomodoroFinished; }
            set
            {
                this.PomodoroControl.PomodoroFinished = value;
                RaisePropertyChanged();
            }
        }
        public bool CanLongTime
        {
            get { return PomodoroControl.CanLongTime; }
            set
            {
                this.PomodoroControl.CanLongTime = value;
                RaisePropertyChanged();
            }
        }
    }
}
