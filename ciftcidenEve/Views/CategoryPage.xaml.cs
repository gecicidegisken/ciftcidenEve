using ciftcidenEve.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            this.BindingContext = new CategoryViewModel();

        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            return true;
        }
        async void mRefreshViewCategoryPage_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewCategoryPage.IsRefreshing = false;

        }

        protected override void OnAppearing()
        {
            mRefreshViewCategoryPage.IsRefreshing = true;
            base.OnAppearing();
        }
    }
}