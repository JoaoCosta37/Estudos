﻿    using ChatApp.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Prism.Navigation;
using ChatApp.Views;
using ChatApp.Models;
using DryIoc;

namespace ChatApp.ViewModels
{
    public class ChatRoomsPageViewModel : BindableBase, INavigatedAware
    {
        private readonly IChatRoomService chatRoomService;
        private readonly INavigationService navigationService;
        private readonly IAuth auth;
        private readonly IUserService userService;
        private User user;

        ObservableCollection<ChatRoomViewModel> chatRoomsVm;

        public ChatRoomsPageViewModel(IChatRoomService chatRoomService, INavigationService navigationService, IAuth auth, IUserProvider userProvider, IUserService userService)
        {
            this.chatRoomService = chatRoomService;
            this.navigationService = navigationService;
            this.auth = auth;
            this.userService = userService;
            this.user = userProvider.GetUser();
            loadUser();
            loadChatRoomsAsync();
            this.OpenChatRoomCommand = new Command((x) => openChatRoom(x));
            this.SingOutCommand = new Command(() => singOut());
        }

        public ObservableCollection<ChatRoomViewModel> ChatRoomsVm
        {
            get => chatRoomsVm;
            set
            {
                chatRoomsVm = value;
                RaisePropertyChanged();
            }
        }
        public string UserName 
        {
            get => user.Name;
        }
        public Command OpenChatRoomCommand { get; set; }
        public Command SingOutCommand { get; set; }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            loadChatRoomsAsync();
        }

        async Task loadChatRoomsAsync()
        {
            var chatRooms = await chatRoomService.GetChatRoomsAsync();

            List<ChatRoomViewModel> chatRoomsVm = chatRooms.Select(x => new ChatRoomViewModel(x)).ToList();

            ChatRoomsVm = new ObservableCollection<ChatRoomViewModel>(chatRoomsVm);
        }
        void openChatRoom(object chatRoomVm)
        {
            var chatRoom = (ChatRoomViewModel)chatRoomVm;
            var navParameters = new NavigationParameters
            {
                { "ChatRoom", chatRoom.Id}
            };
            navigationService.NavigateAsync(Routes.ChatPageRoute, navParameters);
        }
        void singOut()
        {
            var result = auth.SignOut();
            navigationService.NavigateAsync(Routes.LoginPageRoute);
        }
        async void loadUser()
        {
            try
            {
            var user = userService.GetUser(this.user.Id);
            this.user = user;

            }
            catch(Exception e)
            {
                 e.ToString();
            }
        }


    }
}
