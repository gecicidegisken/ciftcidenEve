using System.Diagnostics;
using ciftcidenEve.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Threading.Tasks;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubCategoryPage : ContentPage
    {
        public string Tag = "";
        public SubCategoryPage(string tag)
        {
            InitializeComponent();
            this.BindingContext = new SubCategoryViewModel(tag);
            this.Tag = tag;
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.Navigation.PopAsync();
            return true;
        }
        async void mRefreshViewSubCategoryPage_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewSubCategoryPage.IsRefreshing = false;

        }


        protected override void OnAppearing()
        {
            
            mRefreshViewSubCategoryPage.IsRefreshing = true;
            base.OnAppearing();

        }
        
    }
}