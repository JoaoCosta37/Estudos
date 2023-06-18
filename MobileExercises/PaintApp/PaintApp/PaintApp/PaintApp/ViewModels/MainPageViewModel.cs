using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace PaintApp.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            SaveCommand = new Command(() => save());
        }
        public Command SaveCommand { get; set; }
        private void save()
        {

        }
    }
}
