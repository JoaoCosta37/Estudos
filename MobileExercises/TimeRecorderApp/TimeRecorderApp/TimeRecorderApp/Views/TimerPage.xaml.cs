using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeRecorderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();

            //lblLabel.BackgroundColor = Color.Black;
            //lblLabel.Text = "Teste";
            //lblLabel.FontSize = 50;
            //lblLabel.TextColor = Color.AliceBlue;

            
        }
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await lblLabel.FadeTo(1, 5750, Easing.BounceOut);
        //    await lblLabel.ScaleTo(2, 2500, Easing.CubicInOut);
        //    await lblLabel.ScaleTo(1, 1500, Easing.Linear);
        //    await lblLabel.ScaleTo(3, 2500, Easing.CubicInOut);
        //    await lblLabel.ScaleTo(1, 1500, Easing.Linear);
        //    await lblLabel.RotateTo(45, 2000, Easing.Linear);
        //    await lblLabel.RotateTo(90, 2000, Easing.Linear);
        //    await lblLabel.RotateTo(120, 2000, Easing.Linear);
        //    await lblLabel.RotateTo(180, 3000, Easing.Linear);
        //    await lblLabel.RotateTo(270, 2000, Easing.Linear);
        //    await lblLabel.RotateTo(360, 2000, Easing.Linear);
        //}
    }
}
