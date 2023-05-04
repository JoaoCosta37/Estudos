using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private TimeSpan pomodoro;
        private TimeSpan currentTime;
        private TimeSpan remainingTime;
        public MainPageViewModel()
        {
            this.pomodoro = TimeSpan.FromMinutes(1);
            this.remainingTime = this.pomodoro;
        }
        public TimeSpan RemainingTime
        {
            get => this.remainingTime;
            set
            {
                this.remainingTime = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan Pomodoro
        {
            get => this.pomodoro;
            set
            {
                this.pomodoro = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan CurrentTime
        {
            get => this.currentTime;
            set
            {
                this.currentTime = value;
                this.RemainingTime = this.pomodoro - this.currentTime;
                RaisePropertyChanged();
            }
        }

    }


}
