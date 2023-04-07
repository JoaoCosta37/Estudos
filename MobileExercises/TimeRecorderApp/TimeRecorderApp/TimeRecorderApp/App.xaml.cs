using DryIoc;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using TimeRecorderApp.Infrastructure;
using TimeRecorderApp.Services;
using TimeRecorderApp.ViewModels;
using TimeRecorderApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeRecorderApp
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
            await NavigationService.NavigateAsync(nameof(TimerPage));

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TimerPage, TimerPageViewModel>();
            containerRegistry.Register<IFirebaseClientFactory, FirebaseClientFactory>();
            containerRegistry.Register<IRequiredHoursService, RequiredHoursService>();
            //containerRegistry.Register<IMessageService, MessageService>();

            //containerRegistry.Register<IUserProvider, UserProvider>();

            //containerRegistry.Register<UserService>();

            //containerRegistry.Register<IUserService>(() => {
            //    var userService = containerRegistry.GetContainer().Resolve<UserService>();
            //    return new UserServiceWithCache(userService);

            //});


            var container = containerRegistry.GetContainer();

            //container.RegisterDelegate<ServiceFactory>(r => r.Resolve);
            //container.RegisterMany(new[] { typeof(IMediator).GetAssembly() }, Registrator.Interfaces);
            //container.RegisterMany(typeof(NewChatRoom.Handler).GetAssembly().GetTypes().Where(t => t.IsMediatorHandler()));
            //container.RegisterMany(typeof(NewChatRoom.CommandValidator).GetAssembly().GetTypes().Where(t => t.IsPipeline()));


            //container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);
            //container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>), ifAlreadyRegistered: IfAlreadyRegistered.AppendNewImplementation);


            containerRegistry.Register<IAuth>(() => DependencyService.Get<IAuth>());


        }
    }
}
