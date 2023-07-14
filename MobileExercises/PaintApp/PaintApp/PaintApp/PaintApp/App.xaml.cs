using PaintApp.ViewModels;
using PaintApp.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PaintApp
{
    public partial class App : PrismApplication
    {
        public App()
           : this(null)
        {
        }
        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(nameof(Views.MainPage));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
