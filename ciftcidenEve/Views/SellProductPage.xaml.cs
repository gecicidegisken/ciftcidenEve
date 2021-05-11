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
        public Boolean isThereMainCategory = false;
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
            SubTagPicker.Items.Clear();
            isThereMainCategory = true;
            cat = TagPicker.SelectedItem.ToString();
            categoryService.ShowSubCategory(cat);
            // SubTagPicker.ItemsSource = categoryService.SubCategories;
            foreach(string i in categoryService.SubCategories)
            {
                SubTagPicker.Items.Add(i);
            }
           
            //CrossToastPopUp.Current.ShowCustomToast(cat, "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
            notifySubTags();

        }
        private void notifySubTags()
        {
            if (isThereMainCategory)
            {
                SubTagPicker.Items.Clear();
                foreach (string i in categoryService.SubCategories)
                {
                    SubTagPicker.Items.Add(i);
                }
                Debug.WriteLine("darari");
                cat = TagPicker.SelectedItem.ToString();
                categoryService.ShowSubCategory(cat);
               // SubTagPicker.ItemsSource = categoryService.SubCategories;
                OnPropertyChanged("SubTagPicker");
                OnPropertyChanged("SubTag");
            }
                
        }
        
        private void SubTagPicker_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("focused");
            notifySubTags();
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