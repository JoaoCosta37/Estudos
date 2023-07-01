using PaintApp.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace PaintApp.ViewModels
{
    public class MainPageViewModel
    {
        IPhotoPickerService photoPickerService;

        public event Action<Stream> OnStreamLoaded;
        public MainPageViewModel()
        {
            this.photoPickerService = DependencyService.Get<IPhotoPickerService>();
            SaveCommand = new Command(() => save());
            OpenImageCommand = new Command(() => getPicker());
        }
        public Command SaveCommand { get; set; }
        public Command OpenImageCommand { get; set; }
        private void save()
        {

        }
        private async void getPicker()
        {
            var result = await photoPickerService.GetImageStreamAsync();

            OnStreamLoaded?.Invoke(result);
           
        }
    }
}
