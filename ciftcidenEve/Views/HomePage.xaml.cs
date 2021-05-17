 using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;
using ciftcidenEve.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace ciftcidenEve.Views
{
    public partial class HomePage : ContentPage
    { 
        FilterService filtersList = new FilterService();
        CategoryService categories = new CategoryService();

        HomePageViewModel _viewModel;
        List<string> filters = new List<string>();
       
        
        public HomePage()
        {
            
            InitializeComponent();
            
            _viewModel = new HomePageViewModel();
            BindingContext = _viewModel;
            ShowFilters();


        }
        async private void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            mRefreshViewHomePage.IsRefreshing = false;
            mRefreshViewHomePage.Command = _viewModel.LoadItemsCommand;
           
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            return true;
        }
        protected async override void OnAppearing()
        {
 
            base.OnAppearing();
            _viewModel.onAppearing();
            mRefreshViewHomePage.IsRefreshing = true;
            collectionView.ItemsSource = _viewModel.Products;
            OnPropertyChanged("mRefreshViewHomePage");
            OnPropertyChanged("collectionView");

        }

        protected void ShowFilters()
        {
            filters.Add("Şehir");
            filters.Add("Fiyat");
            filters.Add("Satıcı");
            FilterPicker.ItemsSource = filters;
        }

        public void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.Filter = FilterPicker.SelectedItem.ToString();
            Debug.WriteLine(_viewModel.Filter.ToString());

            if (FilterPicker.SelectedIndex == 0) { 
            SubFilterPicker.ItemsSource = filtersList.Cities;
          
            }
            else if (FilterPicker.SelectedIndex == 1)
            {
                //SubFilterPicker.ItemsSource = Filters.Prices;
               
            }
            else if (FilterPicker.SelectedIndex == 2)
            {
               
                SubFilterPicker.ItemsSource = FilterService.Sellers;
            }

            SubFilterPicker.IsVisible = true;
            SubFilterPicker.Focus();
        }

        public void SubFilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            _viewModel.SubFilter = SubFilterPicker.SelectedItem.ToString();

            Debug.WriteLine(_viewModel.SubFilter.ToString());

            _viewModel.onAppearing();
            base.OnAppearing();
            OnAppearing();

        }
    }
}