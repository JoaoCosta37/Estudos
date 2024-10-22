using PomodoroApp.Singles;
using PomodoroApp.ViewModels;
using PomodoroApp.ViewModels.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage
    {
        private readonly IEventAggregator eventAggregator;

        public ConfigPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            //SizeChanged += (sender, e) => sizeChangedHandler(sender, e);

        }

        //private void sizeChangedHandler(object sender, EventArgs e)
        //{
        //    if (ColorThemeGrid.Width <= 0) return;

        //    var valueReference = Width / (ColorThemeGrid.ColumnDefinitions.Count + 2);




        //    //if (Width > Height)
        //    //{
        //    //    valueReference = Height / ColorThemeGrid.RowDefinitions.Count;
        //    //}

        //    foreach(var row in ColorThemeGrid.RowDefinitions)
        //    {
        //        row.Height = valueReference;
        //    }

        //    foreach (var row in ColorThemeGrid.ColumnDefinitions)
        //    {
        //        row.Width = valueReference;
        //    }

        //    //if (ColorThemeGrid.Width > 0)
        //    //{
        //    //    foreach(var row in ColorThemeGrid.RowDefinitions)
        //    //    {
        //    //        row.Height = ColorThemeGrid.Width / 5;
        //    //    }
        //    //}
        //}
        protected override bool OnBackButtonPressed()
        {
            BackgColorInstance.UpdateBackgColor();
            eventAggregator.GetEvent<ConfigChangedEvent>().Publish(new ConfigChangedEventArgs() { ConfigName = nameof(MainPageViewModel.PomodoroControlVm) });
            return base.OnBackButtonPressed();
        }

    }
}