using DryIoc;
using MediatR;
using PomodoroApp.Features;
using PomodoroApp.MediatR;
using PomodoroApp.Repositorys;
using PomodoroApp.ViewModels;
using PomodoroApp.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroApp
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
            await NavigationService.NavigateAsync(nameof(Views.ConfigPage));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfigPage, ConfigPageViewModel>();
            containerRegistry.Register<BackgColorRepository>();
            //containerRegistry.Register<TimeDurationRepository>();
            containerRegistry.Register<PomodoroControlRepository>();
            //containerRegistry.Register<IFirebaseClientFactory, FirebaseClientFactory>();
            //containerRegistry.Register<IRequiredHoursService, RequiredHoursService>();
            //containerRegistry.Register<IMessageService, MessageService>();

            //containerRegistry.Register<IUserProvider, UserProvider>();


            //containerRegistry.Register<IUserService>(() => {
            //    var userService = containerRegistry.GetContainer().Resolve<UserService>();
            //    return new UserServiceWithCache(userService);

            //});


            var container = containerRegistry.GetContainer();

            container.RegisterDelegate<ServiceFactory>(r => r.Resolve);
            container.RegisterMany(new[] { typeof(IMediator).GetAssembly() }, Registrator.Interfaces);
            container.RegisterMany(typeof(UpdatePomodoroControl.Handler).GetAssembly().GetTypes().Where(t => t.IsMediatorHandler()));
            //container.RegisterMany(typeof(UpdatePomodoroControl.CommandValidator).GetAssembly().GetTypes().Where(t => t.IsPipeline()));


            //container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);
            //container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);


            //containerRegistry.Register<IAuth>(() => DependencyService.Get<IAuth>());


        }
    }
}
