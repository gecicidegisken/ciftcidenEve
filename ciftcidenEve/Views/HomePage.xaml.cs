using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            
        }

        async private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewHomePage.IsRefreshing = false;
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            return true;
        }
    }
}