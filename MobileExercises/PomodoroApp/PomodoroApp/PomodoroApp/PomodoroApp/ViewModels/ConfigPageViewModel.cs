using PomodoroApp.Enums;
using PomodoroApp.Models;
using PomodoroApp.Repositorys;
using PomodoroApp.Singles;
using PomodoroApp.ViewModels.Events;
using PomodoroApp.Views;
using Prism.DryIoc;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace PomodoroApp.ViewModels
{
    public class ConfigPageViewModel : BindableBase, INavigationAware
    {
        //private List<TimeDurationViewModel> timesList = new List<TimeDurationViewModel>();
        private PomodoroControlViewModel pomodoroControlVm;
        private readonly IEventAggregator eventAggregator;
        private readonly PomodoroControlRepository pomodoroControlRepository;
        private readonly INavigationService navigationService;

        public ConfigPageViewModel(IEventAggregator eventAggregator, PomodoroControlRepository pomodoroControlRepository, INavigationService navigationService)
        {
            this.PomodoroControlVm = new PomodoroControlViewModel(pomodoroControlRepository.GetPomodoroControlAsync().Result);
            this.AlterBackgroudColorCommand = new Command(((x) => alterBackgroudColor(x)));
            this.UpdateTimeCommand = new Command(((x) => updateTime(x)));
            this.eventAggregator = eventAggregator;
            this.pomodoroControlRepository = pomodoroControlRepository;
            this.navigationService = navigationService;
        }
        public Color BackgColor
        {
            get { return BackgColorInstance.Instance; }
            set
            {
                BackgColorInstance.Instance = value;
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
        public List<TimeDuration> TimesList
        {
            get => PomodoroControlVm.Durations;
            set
            {
                this.PomodoroControlVm.Durations = value;
                RaisePropertyChanged();
            }
        }
        public Command AlterBackgroudColorCommand { get; set; }
        public Command UpdateTimeCommand { get; set; }
        private void alterBackgroudColor(object colorHex)
        {
            BackgColorInstance.Instance = (Color)colorHex;
            RaisePropertyChanged(nameof(this.BackgColor));
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(this.BackgColor) });
        }
        private void updateTime(object parameter)
        {
            var param = (string)parameter;
            var navigationParams = new NavigationParameters()
            {
                {"TimeDuration", this.TimesList.Where((x) => Enum.GetName(typeof(TimeType), x.TimeTypeValue) == param).FirstOrDefault()}
            };
            navigationService.NavigateAsync(nameof(UpdateTimePage),navigationParams);
            var result = this.TimesList.Where<TimeDuration>((x) => this.PomodoroControlVm.CurrentType == x.TimeType).FirstOrDefault();
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //var pomodoroControl = parameters.GetValue<PomodoroControlViewModel>("PomodoroControl");
            //this.pomodoroControlVm = pomodoroControl;
        }
    }
}
