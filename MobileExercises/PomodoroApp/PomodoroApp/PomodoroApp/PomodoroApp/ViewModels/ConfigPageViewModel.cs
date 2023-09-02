using PomodoroApp.Enums;
using PomodoroApp.Features;
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
    public class ConfigPageViewModel : BindableBase
    {
        //private List<TimeDurationViewModel> timesList = new List<TimeDurationViewModel>();
        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigationService;

        public ConfigPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            this.AlterBackgroudColorCommand = new Command(((x) => alterBackgroudColor(x)));
            this.UpdateTimeCommand = new Command(((x) => updateTime(x)));
            this.TestCommand = new Command((() => test()));
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;
            this.eventAggregator.GetEvent<ConfigChangedEvent>().Subscribe(ConfigEventHandler);
        }
        private void test()
        {
            this.PomodoroControlVm.PomodoroTimesBeforeLongBreak += 1;
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
            get => PomodoroControlInstance.Instance;
            set
            {
                PomodoroControlInstance.Instance = value;
                RaisePropertyChanged();
            }
        }
        public List<TimeDurationViewModel> TimesList
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
        public Command TestCommand { get; set; }
        private void alterBackgroudColor(object colorHex)
        {
            BackgColorInstance.Instance = (Color)colorHex;
            RaisePropertyChanged(nameof(this.BackgColor));
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(this.BackgColor) });
        }
        private void updateTime(object parameter)
        {
            var param = (string)parameter;
            var index = (int)Enum.Parse(typeof(TimeType), param);
            PomodoroControlInstance.IsSelectedToUpdate = index;

            //this.timeToEdit =  (TimeType)Enum.Parse(typeof(TimeType),param);
            //PomodoroControlInstance.IsSelectedTimeDuration = this.TimesList.Where((x) => Enum.GetName(typeof(TimeType), x.TimeType) == param).FirstOrDefault();
            //var navigationParams = new NavigationParameters()
            //{
            //    {"TimeType", this.TimesList.Where((x) => Enum.GetName(typeof(TimeType), x.TimeType) == param).FirstOrDefault()}
            //};
            navigationService.NavigateAsync(nameof(UpdateTimePage));
            //var result = this.TimesList.Where<TimeDuration>((x) => this.PomodoroControlVm.CurrentType == x.TimeType).FirstOrDefault();
        }
        private void ConfigEventHandler(ConfigChangedEventArgs args)
        {
            if (args.ConfigName == nameof(this.TimesList))
            {
                RaisePropertyChanged(nameof(this.TimesList));
            }
        }
        private void updatePomodoroControl()
        {
            PomodoroControlInstance.SavePomodoroControlAsync();
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(this.PomodoroControlVm)});
        }
    }
}
