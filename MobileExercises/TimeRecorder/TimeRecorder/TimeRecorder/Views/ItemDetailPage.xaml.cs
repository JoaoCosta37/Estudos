using System.ComponentModel;
using TimeRecorder.ViewModels;
using Xamarin.Forms;

namespace TimeRecorder.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}