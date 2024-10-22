using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UsingCamera
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel viewModel = new MainPageViewModel();
            this.BindingContext = new MainPageViewModel();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            MainPageViewModel viewModel = (MainPageViewModel)this.BindingContext;
            viewModel.Barcode = result.Text;
        }
    }
}
