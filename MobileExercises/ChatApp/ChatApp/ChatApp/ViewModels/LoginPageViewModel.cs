using ChatApp.Models;
using ChatApp.Service;
using ChatApp.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatApp.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        private string user;
        private string name;
        public bool HasPassword;
        private string password;
        private string confirmPassword;
        private bool isLoginMode = true;
        private readonly IAuth auth;
        private readonly IUserService userService;
        private readonly IPageDialogService dialogService;
        private readonly INavigationService navigationService;

        public LoginPageViewModel(IAuth auth, INavigationService navigationService, IPageDialogService dialogService, IUserService userService)
        {
            ConfirmCommand = new Command(() => confirm());
            SwitchLoginModeCommand = new Command((x) => switchLoginMode((bool)x));
            this.auth = auth;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.userService = userService;
        }
        public string User
        {
            get => user;
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        public string ConfirmPassword
        {
            get => this.confirmPassword;
            set
            {
                this.confirmPassword = value;
                RaisePropertyChanged();
            }
        }
        public bool IsLoginMode
        {
            get => this.isLoginMode;
            set
            {
                this.isLoginMode = value;
                RaisePropertyChanged();
            }
        }
        public Command ConfirmCommand { get; set; }
        public Command SwitchLoginModeCommand { get; set; }
        void confirm()
        {
            if (!isLoginMode) singUp();
            login();

        }
        async void login()
        {
            var token = await auth.LoginWithEmailPassword(user, password);

            if (String.IsNullOrWhiteSpace(token))
            {
                dialogService.DisplayAlertAsync("Error", "Invalid Credentials", "OK");
            }
            else
            {
                navigationService.NavigateAsync(Routes.ChatRoomsPageRoute);
            }
        }
        async void singUp()
        {
            var token = await auth.SingUpWithEmailAndPasswordAsync(user, password);
            userService.CreateUserAsync(new User() { Id = user, Name = name });

        }
        void switchLoginMode(bool value)
        {
            IsLoginMode = value;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (auth.IsSignIn())
            {
                navigationService.NavigateAsync(Routes.ChatRoomsPageRoute);
            }
        }
    }
}
