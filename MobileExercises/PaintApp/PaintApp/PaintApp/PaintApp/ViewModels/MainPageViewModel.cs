using PaintApp.Services;
using Prism.Mvvm;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Xamarin.Forms;

namespace PaintApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        IPhotoPickerService photoPickerService;
        private static SKColor brushColor =  SKColors.Blue;

        public event Action<Stream> OnStreamLoaded;
        public MainPageViewModel()
        {
            this.photoPickerService = DependencyService.Get<IPhotoPickerService>();
            SaveCommand = new Command(() => save());
            OpenImageCommand = new Command(() => getPicker());
        }
        public Command SaveCommand { get; set; }
        public Command OpenImageCommand { get; set; }
        public static SKColor BrushColor
        {
            get => brushColor;
            set
            {
                brushColor = value;
            }
        }
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
