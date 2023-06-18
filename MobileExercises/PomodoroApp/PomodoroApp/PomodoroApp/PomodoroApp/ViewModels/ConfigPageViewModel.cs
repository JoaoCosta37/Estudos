using PomodoroApp.Models;
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
        private readonly IEventAggregator eventAggregator;

        public ConfigPageViewModel(IEventAggregator eventAggregator)
        {
            this.AlterBackgroudColorCommand = new Command(((x) => alterBackgroudColor(x)));
            this.eventAggregator = eventAggregator;
        }
        public string BackgColor
        {
            get { return BackgColorInstance.Instance; }
            set
            {
                BackgColorInstance.Instance = value;
                RaisePropertyChanged(); 
            }
        }
        public Command AlterBackgroudColorCommand { get; set; }
        //private void setBackgColor()
        //{
        //    var result = this.BackgColor = backgColorRepository.GetBackgColor().Result;
        //    if(result != null)
        //    {

        //    }
        //}
        private void alterBackgroudColor(object colorHex)
        {
            BackgColorInstance.Instance = (string)colorHex;
            RaisePropertyChanged(nameof(this.BackgColor));
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(this.BackgColor)});
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //parameters.Add("backgColor", BackgColorInstance.Instance);

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //string bc = parameters.GetValue<string>("backgColor");
            //if (bc != null)
            //{
            //    BackgColorInstance.Instance = bc;
            //}
        }
    }
}
