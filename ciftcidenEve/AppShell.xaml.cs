using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace ciftcidenEve
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(SellProductPage), typeof(SellProductPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            App.authorization = false;
            await Shell.Current.GoToAsync("//HomePage");
        }

        private async void OnSatisClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("çalışıyo");
        }
    }
}
