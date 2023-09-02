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
using Prism.Navigation;
using PomodoroApp.Repositorys;
using PomodoroApp.Singles;
using Prism.Events;
using PomodoroApp.ViewModels.Events;
using System.Xml.Schema;
using PomodoroApp.Features;
using MediatR;
using System.Linq;
using PomodoroApp.Enums;
using System.Globalization;

namespace PomodoroApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private Timer timer;
        public string backgColor;
        private TimeSpan currentTime;
        private TimeSpan remainingTime;
        private bool isStarted = false;
        private int positionSelectedItem;
        private readonly IMediator mediator;
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public MainPageViewModel(INavigationService navigationService,
                                 IEventAggregator eventAggregator,
                                 IMediator mediator)
        {
            this.mediator = mediator;
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;

            this.RestartCommand = new Command((() => reset()));
            this.TimeControllerCommand = new Command((() => timeController()));

            this.eventAggregator.GetEvent<ConfigChangedEvent>().Subscribe(ConfigEventHandler);


            this.loadTimeType();
        }
        #region Properties
        public int PositionSelectedItem
        {
            get => this.positionSelectedItem;
            set
            {
                this.positionSelectedItem = value;
                this.RemainingTime = PomodoroControlVm.Durations[value].TimeDuration.Duration;
                RaisePropertyChanged();
            }
        }
        public PomodoroControlViewModel PomodoroControlVm
        {
            get => PomodoroControlInstance.Instance;
            set
            {
                PomodoroControlInstance.Instance = value;
                RaisePropertyChanged();
            }

        }
        public List<TimeDurationViewModel> TimesList
        {
            get => this.PomodoroControlVm.Durations;
            set
            {
                this.PomodoroControlVm.Durations = value;
                RaisePropertyChanged();
            }
        }
        public int Progress
        {
            get => this.PomodoroControlVm.Progress;
            set
            {
                this.PomodoroControlVm.Progress = value;
                RaisePropertyChanged();
            }
        }
        public double PomodoroProgressPorcent
        {
            get => this.porcentCustom(this.PomodoroControlVm.CountToLongBreak, this.PomodoroControlVm.PomodoroTimesBeforeLongBreak);
        }
        public string PomodoroProgressIndicator
        {
            get => $"{this.PomodoroControlVm.CountToLongBreak}/{this.PomodoroControlVm.PomodoroTimesBeforeLongBreak}";
        }
        public string DailyProgressIndicator
        {
            get => $"{this.PomodoroControlVm.DailyCount}/{this.PomodoroControlVm.DailyGoal}";
        }
        public double DailyProgressPorcent
        {
            get => this.porcentCustom(this.PomodoroControlVm.DailyCount, this.PomodoroControlVm.DailyGoal);

        }

        public TimeSpan CurrentTime
        {
            get => this.currentTime;
            set
            {
                this.currentTime = value;
                this.RemainingTime = this.Pomodoro - this.CurrentTime;
                RaisePropertyChanged();
            }
        }
        public Color BackgColor
        {
            get
            {
                var result = BackgColorInstance.Instance;
                return result;
            }
            set
            {
                BackgColorInstance.Instance = value;
            }
        }
        bool isCorrectTimeType
        {
            get => this.PositionSelectedItem == this.PomodoroControlVm.TimeTypeValue;
        }
        public TimeType CurrentType
        {
            get => (TimeType)Enum.ToObject(typeof(TimeType), this.PositionSelectedItem);
        }
        public bool CanRestart
        {
            get => this.IsStarted && !IsRunning;
        }
        public bool IsStarted
        {
            get => this.isStarted;
            set
            {
                this.isStarted = value;
                RaisePropertyChanged();
            }
        }
        public bool IsRunning
        {
            get
            {
                var result = this.timer?.Enabled ?? false;
                return result;
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
            get => this.PomodoroControlVm.Durations[this.PositionSelectedItem].TimeDuration.Duration;
            set
            {
                //this.PomodoroControlVm.Durations[this.PositionSelectedItem].TimeDuration.Duration = value;
                this.RemainingTime = value;
                RaisePropertyChanged();
            }
        }


        #endregion
        public Command TimeControllerCommand { get; set; }
        public Command RestartCommand { get; set; }

        #region Methods
        private void ConfigEventHandler(ConfigChangedEventArgs args)
        {
            if (args.ConfigName == nameof(this.BackgColor))
            {
                RaisePropertyChanged(nameof(this.BackgColor));
            }
            if (args.ConfigName == nameof(this.PomodoroControlVm))
            {
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.PomodoroControlVm));
                RaisePropertyChanged(nameof(this.TimesList));
            }
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentTime = CurrentTime.Add(TimeSpan.FromSeconds(1));
            if (RemainingTime == TimeSpan.Zero)
            {
                this.timer.Stop();
                this.updatePomodoroControl();
                return;
            }
        }
        private void reset()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer = null;
            }
            this.IsStarted = false;
            this.CurrentTime = new TimeSpan();
            setCorrectPosition();
            RaisePropertyChanged(nameof(this.CanRestart));

        }
        private void timeController()
        {
            if (!this.IsStarted)
            {
                this.IsStarted = true;
                this.timerStart();
            }
            else if (this.IsRunning)
            {
                this.timer.Stop();
                RaisePropertyChanged(nameof(CurrentTime));
            }
            else
            {
                this.timerStart();
            }
            RaisePropertyChanged(nameof(this.IsRunning));
            RaisePropertyChanged(nameof(this.CurrentType));
            RaisePropertyChanged(nameof(this.CanRestart));
        }
        private void timerStart()
        {
            if (timer == null)
            {
            if (this.isCorrectTimeType && this.PomodoroControlVm.TimeTypeValue == 0)
            {
                this.Progress = -1;
            }
                this.timer = new Timer();
                this.timer.Interval = 1000;
                this.timer.Elapsed += Timer_Elapsed;
            }
            timer.Start();
        }
        private void loadTimeType()
        {
            //PomodoroControlInstance.UpdatePomodoroControlAsync(mediator, true);
            setCorrectPosition();
            //var command = new UpdateStatistics.Command();
            //mediator.Send(command);
            //RaisePropertyChanged(nameof(this.Progress));
        }
        private void updatePomodoroControl()
        {
            if (this.isCorrectTimeType)
            {
                PomodoroControlInstance.UpdatePomodoroControlAsync(mediator);
            }
            else
            {
                setCorrectPosition();
            }
            RaisePropertyChanged(nameof(this.Progress));
            RaisePropertyChanged(nameof(this.DailyProgressIndicator));
            RaisePropertyChanged(nameof(this.DailyProgressPorcent));
            RaisePropertyChanged(nameof(this.PomodoroProgressPorcent));
            RaisePropertyChanged(nameof(this.PomodoroProgressIndicator));
            this.reset();
        }
        private void setCorrectPosition()
        {
            this.PositionSelectedItem = this.PomodoroControlVm.TimeTypeValue;
        }
        private double porcentCustom(int firstValue, int secundValue)
        {
            if (secundValue == 0) return 1;
            var porcent = (double)firstValue/secundValue;
            return porcent > 1 ? 1 : porcent;
        }
        #endregion
    }


}
