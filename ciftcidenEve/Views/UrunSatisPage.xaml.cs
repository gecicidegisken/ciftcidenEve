using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using System;
using Plugin.Toast;
using System.IO;


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
        protected override void OnAppearing()
        {
            
            if (App.authorization)
            {
                base.OnAppearing();
            }
            else
            {
                CrossToastPopUp.Current.ShowCustomToast("Bunun için giriş yapmalısınız", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
                Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
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