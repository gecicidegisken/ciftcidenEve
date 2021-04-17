using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        public CardPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            return true;
        }
    }
}