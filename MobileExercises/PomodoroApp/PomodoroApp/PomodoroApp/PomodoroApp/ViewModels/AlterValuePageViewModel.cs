using PomodoroApp.Models;
using PomodoroApp.Singles;
using PomodoroApp.ViewModels.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace PomodoroApp.ViewModels
{
    public class AlterValuePageViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;
        private TimeDurationViewModel timeDurationVm;

        public AlterValuePageViewModel( INavigationService navigationService, IEventAggregator eventAggregator)
        {
            AddDurationValueCommand = new Command((x) => updateDurationValue(true, x));
            SubtractDurationValueCommand = new Command((x) => updateDurationValue(false, x));
            ConfirmCommand = new Command(() => confirm());
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            setTimeDurationViewModel();
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
        public Command AddDurationValueCommand { get; set; }
        public Command SubtractDurationValueCommand { get; set; }
        public Command ConfirmCommand { get; set; }
        public TimeDurationViewModel TimeDurationVm
        {
            get => this.timeDurationVm;
            set
            {
                this.timeDurationVm = value;
                RaisePropertyChanged();
            }
        }
        void setTimeDurationViewModel()
        {
            this.timeDurationVm = PomodoroControlInstance.Instance.Durations[PomodoroControlInstance.IsSelectedToUpdate];
        }

        private void updateDurationValue(bool isAdd, object value)
        {
            TimeSpan valueToUpdate = TimeSpan.FromMinutes(Convert.ToInt32(value));
            if (isAdd)
            {
                this.TimeDurationVm.Duration += valueToUpdate;
            }
            else
            {
                //if (this.TimeDurationVm.Duration.TotalMinutes == 0) return;
                if (this.TimeDurationVm.Duration <= valueToUpdate)
                {
                    this.TimeDurationVm.Duration = TimeSpan.FromMinutes(1);
                }
                else { this.TimeDurationVm.Duration -= valueToUpdate; }

            }
            RaisePropertyChanged(nameof(this.TimeDurationVm));
        }
        private void confirm()
        {
            //var list = PomodoroControlInstance.Instance.Durations;
            //var index = list.FindIndex((x) => x.TimeType == this.TimeDurationVm.TimeType);
            //list[index] = TimeDurationVm;
            //PomodoroControlInstance.Instance.Durations = list;
            PomodoroControlInstance.SavePomodoroControlAsync();
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(ConfigPageViewModel.TimesList)});
            navigationService.GoBackAsync();
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //parameters.Add("NewTimeDuration", this.TimeDurationVm);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //var timeDuration = parameters.GetValue<TimeDurationViewModel>("TimeDuration");
            //this.TimeDurationVm = timeDuration;
        }
    }
}
