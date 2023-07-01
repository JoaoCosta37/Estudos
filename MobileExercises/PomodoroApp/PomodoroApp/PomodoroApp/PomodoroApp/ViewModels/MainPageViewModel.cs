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

namespace PomodoroApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private TimeSpan pomodoro;
        private TimeSpan currentTime;
        private TimeSpan remainingTime;
        private Timer timer;
        private bool isStarted = false;
        private List<TimeDurationViewModel> timesList = new List<TimeDurationViewModel>();
        private PomodoroControlViewModel pomodoroControlVm;
        public string backgColor;
        private readonly INavigationService navigationService;
        private readonly BackgColorRepository backgColorRepository;
        private readonly PomodoroControlRepository pomodoroControlRepository;
        private readonly IEventAggregator eventAggregator;
        private readonly IMediator mediator;

        public MainPageViewModel(INavigationService navigationService,
                                 BackgColorRepository backgColorRepository,
                                 PomodoroControlRepository pomodoroControlRepository,
                                 IEventAggregator eventAggregator,
                                 IMediator mediator)
        {
            this.navigationService = navigationService;
            this.backgColorRepository = backgColorRepository;
            this.pomodoroControlRepository = pomodoroControlRepository;
            this.eventAggregator = eventAggregator;
            this.mediator = mediator;
            this.TimeControllerCommand = new Command((() => timeController()));
            this.RestartCommand = new Command((() => reset()));

            this.eventAggregator.GetEvent<ConfigChangedEvent>().Subscribe(ConfigEventHandler);

            this.reset();
            //this.setTimeList();
            this.setPomodoroControl();
        }
        public TimeDuration SelectedItem
        {
            get
            {
                var result = this.TimesList.Where<TimeDuration>((x) => this.PomodoroControlVm.CurrentType == x.TimeType).FirstOrDefault();
                return result;
            }
            set
            {
                this.Pomodoro = value.Duration;
                this.PomodoroControlVm.CurrentType = value.TimeType;
                RaisePropertyChanged();
                RaisePropertyChanged("CurrentTime");
            }
        }
        public List<TimeDuration> TimesList
        {
            get => this.PomodoroControlVm.PomodoroControl.Durations;
            set
            {
                this.PomodoroControlVm.PomodoroControl.Durations = value;
                RaisePropertyChanged();
            }
        }
        public PomodoroControlViewModel PomodoroControlVm
        {
            get => this.pomodoroControlVm;
            set
            {
                this.pomodoroControlVm = value;
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
        public bool IsStarted
        {
            get => this.isStarted;
            set
            {
                this.isStarted = value;
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
        public bool IsRunning
        {
            get
            {
                var result = this.timer?.Enabled ?? false;

                return result;
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
        public Command RestartCommand { get; set; }

        private void ConfigEventHandler(ConfigChangedEventArgs args)
        {
            if (args.ConfigName == nameof(this.BackgColor))
            {
                RaisePropertyChanged(nameof(this.BackgColor));
            }
        }

        private void timeController()
        {
            if (!this.IsStarted)
            {
                this.IsStarted = true;
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
            RaisePropertyChanged(nameof(this.IsRunning));
        }

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
                this.updatePomodoroControl();
            }
        }

        //private void setTimeList()
        //{
        //    var timeL = this.timeDurationRepository.GetTimeDurationListAsync().Result;
        //    foreach (var time in timeL)
        //    {
        //        this.TimesList.Add(new TimeDurationViewModel(time));
        //    }
        //}
        private void setPomodoroControl()
        {
            var pomodoroC = this.pomodoroControlRepository.GetPomodoroControlAsync().Result;
            this.pomodoroControlVm = new PomodoroControlViewModel(pomodoroC);
        }
        private async void updatePomodoroControl()
        {
            var command = new UpdatePomodoroControl.Command() { PomodoroControlViewModel = pomodoroControlVm };
            var result = await mediator.Send(command);
            this.reset();
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
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            parameters.Add("PomodoroControl", this.pomodoroControlVm);

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //RaisePropertyChanged(nameof(this.BackgColor));
        }
    }


}
