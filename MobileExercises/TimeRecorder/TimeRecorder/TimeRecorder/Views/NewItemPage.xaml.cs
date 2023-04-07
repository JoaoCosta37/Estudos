using System;
using System.Collections.Generic;
using System.ComponentModel;
using TimeRecorder.Models;
using TimeRecorder.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeRecorder.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}