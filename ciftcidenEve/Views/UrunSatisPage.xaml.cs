using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using System;
using System.IO;
using System.Collections.Generic;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunSatisPage : ContentPage
    {
        public Product Product = new Product();
       
        public UrunSatisPage()
        {
            InitializeComponent();
            BindingContext = new AddNewProductViewModel();
           TagPicker.ItemsSource = Product.Categories;
           
        }
        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            return true;
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
               
            }

                 (sender as Button).IsEnabled = true;
        }
    }
}