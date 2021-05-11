using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using ciftcidenEve.Services;
using System;
using Plugin.Toast;
using System.IO;
using System.Diagnostics;


namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellProductPage : ContentPage
    {
        public Product Product = new Product();
        public CategoryService categoryService = new CategoryService();
        public string cat = "";
        public SellProductPage()
        {
            InitializeComponent();
            BindingContext = new SellProductViewModel();
            TagPicker.ItemsSource = categoryService.Categories;
           
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


        async void OnTagPickerSelectedIndexChanged(object sender, EventArgs e)
        {

            cat = TagPicker.SelectedItem.ToString();
            categoryService.ShowSubCategory(cat);
            SubTagPicker.ItemsSource = categoryService.SubCategories;
        }
        private void SubTagPicker_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("focused");

            categoryService.ShowSubCategory(cat);



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