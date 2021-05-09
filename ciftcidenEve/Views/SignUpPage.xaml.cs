using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Toast;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            return true;
           
        }
       async protected void OnButtonClicked(object sender, EventArgs e)
        {
            //CrossToastPopUp.Current.ShowCustomToast("Üyelik işlemi tamamlandı", "#f5712f","white", Plugin.Toast.Abstractions.ToastLength.Short);
           //CrossToastPopUp.Current.ShowToastMessage("bu çalışıtyo.");

            //await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

        }
    }
}