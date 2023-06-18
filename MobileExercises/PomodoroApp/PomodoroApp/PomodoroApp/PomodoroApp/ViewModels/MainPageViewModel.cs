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

namespace PomodoroApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private TimeSpan pomodoro;
        private TimeSpan currentTime;
        private TimeSpan remainingTime;
        private Timer timer;
        private bool start = false;
        private List<TimeDurationViewModel> timesList = new List<TimeDurationViewModel>();
        private PomodoroControlViewModel pomodoroControl;
        public string backgColor;
        private readonly INavigationService navigationService;
        private readonly BackgColorRepository backgColorRepository;
        private readonly TimeDurationRepository timeDurationRepository;
        private readonly PomodoroControlRepository pomodoroControlRepository;
        private readonly IEventAggregator eventAggregator;

        public MainPageViewModel(INavigationService navigationService,
                                 BackgColorRepository backgColorRepository,
                                 TimeDurationRepository timeDurationRepository,
                                 PomodoroControlRepository pomodoroControlRepository,
                                 IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.backgColorRepository = backgColorRepository;
            this.timeDurationRepository = timeDurationRepository;
            this.pomodoroControlRepository = pomodoroControlRepository;
            this.eventAggregator = eventAggregator;

            this.TimeControllerCommand = new Command((() => timeController()));

            this.eventAggregator.GetEvent<ConfigChangedEvent>().Subscribe(ConfigEventHandler);

            this.reset();
            this.setTimeList();
            this.setPomodoroControl();
        }
        public TimeDurationViewModel SelectedItem
        {
            set
            {
                this.Pomodoro = value.TimeDuration.Duration;
                RaisePropertyChanged();
                RaisePropertyChanged("CurrentTime");
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
        public PomodoroControlViewModel PomodoroControl
        {
            get => this.pomodoroControl;
            set
            {
                this.pomodoroControl = value;
                RaisePropertyChanged();
            }

        }
        public string BackgColor
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
        public bool IsRunning => this.timer.Enabled;
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

        private void ConfigEventHandler(ConfigChangedEventArgs args)
        {
            if (args.ConfigName == nameof(this.BackgColor))
            {
                RaisePropertyChanged(nameof(this.BackgColor));
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

        private void setTimeList()
        {
            var timeL = this.timeDurationRepository.GetTimeDurationListAsync().Result;
            foreach (var time in timeL)
            {
                this.TimesList.Add(new TimeDurationViewModel(time));
            }
        }
        private void setPomodoroControl()
        {
            var pomodoroC = this.pomodoroControlRepository.GetPomodoroControlAsync().Result;
            this.pomodoroControl = new PomodoroControlViewModel(pomodoroC);
        }

        private void reset()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer = null;
            }
            this.start = false;
            this.pomodoro = TimeSpan.FromMinutes(.1);
            this.CurrentTime = new TimeSpan();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //parameters.Add("backgColor", BackgColorInstance.Instance);

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            RaisePropertyChanged(nameof(this.BackgColor));
        }
    }


}
