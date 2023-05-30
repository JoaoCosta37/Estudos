using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using PomodoroApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using PomodoroApp.Models;

namespace PomodoroApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private TimeSpan pomodoro;
        private TimeSpan currentTime;
        private TimeSpan remainingTime;
        private Timer timer;
        private bool start = false;
        private List<TimeDurationViewModel> timesList;
        public MainPageViewModel()
        {
            this.reset();
            this.TimeControllerCommand = new Command((() => timeController()));
            this.timesList = new List<TimeDurationViewModel>()
            {
                new TimeDurationViewModel(new TimeDuration(){Description="POMODORO", Duration=TimeSpan.FromMinutes(.8)} ),
                new TimeDurationViewModel(new TimeDuration(){Description="PAUSA", Duration=TimeSpan.FromMinutes(.1)} ),
                new TimeDurationViewModel(new TimeDuration(){Description="PAUSA LONGA", Duration=TimeSpan.FromMinutes(.4)} ),
            };
        }
        public TimeDurationViewModel SelectedItem
        {
            set
            {
                this.Pomodoro = value.TimeDuration.Duration;
                RaisePropertyChanged();
            }
        }
        public List<TimeDurationViewModel> TimesList
        {
            get => this.timesList;
            set
            {
                this.timesList = value;
                RaisePropertyChanged();
            }
        }
        public bool Start
        {
            get => this.start;
            set
            {
                this.start = value;
                RaisePropertyChanged();
            }
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
                this.RemainingTime = value;
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
        public Command TimeControllerCommand { get; set; }

        private void timerStart()
        {
            if (timer == null)
            {
                this.timer = new Timer();
                this.timer.Interval = 1000;
                this.timer.Elapsed += Timer_Elapsed;
            }
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (RemainingTime == TimeSpan.Zero)
            {
                this.timer.Stop();
                return;
            }
            CurrentTime = CurrentTime.Add(TimeSpan.FromSeconds(1));
            if (RemainingTime == new TimeSpan())
            {
                this.reset();
            }
        }
        private void timeController()
        {
            if (!this.Start)
            {
                this.Start = true;
                this.timerStart();
            }
            else if (this.timer.Enabled)
            {
                this.timer.Stop();
                RaisePropertyChanged(nameof(CurrentTime));
            }
            else
            {
                this.timerStart();
            }
        }

        public bool IsRunning => this.timer.Enabled;

        private void reset()
        {
            if(this.timer != null)
            {
                this.timer.Stop();
                this.timer = null;
            }
            this.start = false;
            this.pomodoro = TimeSpan.FromMinutes(.1);
            this.CurrentTime = new TimeSpan();
        }

    }


}
