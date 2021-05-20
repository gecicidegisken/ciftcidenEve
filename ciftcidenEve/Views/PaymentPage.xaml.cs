using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciftcidenEve.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        CardPage cp = new CardPage();
        public PaymentPage()
        {
            InitializeComponent();
            //CardPage cp = new CardPage();
            UpdatePage();
        }

       public void UpdatePage()
        {
            toplamTutar.Text = "Ödenecek Tutar: " + cp.changeTotal().ToString() + " TL ";
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(CardPage)}");
            return true;
        }
    }
}