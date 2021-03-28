using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using ciftcidenEve.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ciftcidenEve.Views
{
    public partial class ProductsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}