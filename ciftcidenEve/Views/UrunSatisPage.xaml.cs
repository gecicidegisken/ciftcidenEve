using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using System;
using System.IO;
namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrunSatisPage : ContentPage
    {
        public Product Product { get; set; }
       
        public UrunSatisPage()
        {
            InitializeComponent();
            BindingContext = new AddNewProductViewModel();
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