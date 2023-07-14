using PomodoroApp.Singles;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PomodoroApp.ViewModels
{
    public class UpdateTimePageViewModel : BindableBase, INavigatedAware
    {
        public UpdateTimePageViewModel()
        {

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

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
