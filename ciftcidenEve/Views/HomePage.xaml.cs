 using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;

namespace ciftcidenEve.Views
{
    public partial class HomePage : ContentPage
    {
        HomePageViewModel _viewModel;
        public HomePage()
        {
            
            InitializeComponent();
            
            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;

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
        protected override void OnAppearing()
        {
            base.OnAppearing();
          
            mRefreshViewHomePage.IsRefreshing = true;
        }

    }
}