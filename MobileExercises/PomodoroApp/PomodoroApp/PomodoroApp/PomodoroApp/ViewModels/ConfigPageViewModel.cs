using PomodoroApp.Models;
using PomodoroApp.Repositorys;
using PomodoroApp.Singles;
using PomodoroApp.ViewModels.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
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

        public ConfigPageViewModel(IEventAggregator eventAggregator, PomodoroControlRepository pomodoroControlRepository)
        {
            this.PomodoroControlVm = new PomodoroControlViewModel (pomodoroControlRepository.GetPomodoroControlAsync().Result);
            this.AlterBackgroudColorCommand = new Command(((x) => alterBackgroudColor(x)));
            this.eventAggregator = eventAggregator;
            this.pomodoroControlRepository = pomodoroControlRepository;
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
        private void alterBackgroudColor(object colorHex)
        {
            BackgColorInstance.Instance = (Color)colorHex;
            RaisePropertyChanged(nameof(this.BackgColor));
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(this.BackgColor)});
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
