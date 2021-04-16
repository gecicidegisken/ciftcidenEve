using ciftcidenEve.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ciftcidenEve.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            //InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}