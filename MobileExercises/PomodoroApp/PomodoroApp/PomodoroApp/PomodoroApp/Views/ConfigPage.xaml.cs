using PomodoroApp.ViewModels;
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
        //MainPageViewModel viewModel { get => this.BindingContext as MainPageViewModel; }
        public ConfigPage()
        {
            InitializeComponent();
            SizeChanged += (sender, e) => sizeChangedHandler(sender, e);

        }
        private void sizeChangedHandler(object sender, EventArgs e)
        {
            if (ColorThemeGrid.Width <= 0) return;

            var valueReference = Width / (ColorThemeGrid.ColumnDefinitions.Count + 2);




            //if (Width > Height)
            //{
            //    valueReference = Height / ColorThemeGrid.RowDefinitions.Count;
            //}

            foreach(var row in ColorThemeGrid.RowDefinitions)
            {
                row.Height = valueReference;
            }

            foreach (var row in ColorThemeGrid.ColumnDefinitions)
            {
                row.Width = valueReference;
            }

            //if (ColorThemeGrid.Width > 0)
            //{
            //    foreach(var row in ColorThemeGrid.RowDefinitions)
            //    {
            //        row.Height = ColorThemeGrid.Width / 5;
            //    }
            //}
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    viewModel.BackgColor = BindingContext.;
        //    return true;
        //}

    }
}