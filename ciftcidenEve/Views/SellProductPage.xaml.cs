using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using ciftcidenEve.Services;
using System;
using Plugin.Toast;
using System.IO;
using System.Diagnostics;
using Firebase.Storage;
using Plugin.Media.Abstractions;
using Plugin.Media;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ciftcidenEve.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellProductPage : ContentPage
    {
        public Product Product = new Product();
        public CategoryService categoryService = new CategoryService();
        public string cat = "";
        public Boolean isThereMainCategory = false;
        SellProductViewModel sellProductViewModel;

        // sonradan eklediklerim
        MediaFile file;
        public SellProductPage()
        {
            InitializeComponent();
            sellProductViewModel = new SellProductViewModel();
            BindingContext = sellProductViewModel;
            TagPicker.ItemsSource = categoryService.Categories;
            
        }

        protected void CleanForm()
        {
            //image.Source = null;
            //descrText.Text = string.Empty;
            //isimText.Text = string.Empty;
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
            CleanForm();
            return true;
        }
 
        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {

            (sender as Button).IsEnabled = true;

            await CrossMedia.Current.Initialize();
            
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
                });
                if (file == null)
                    return;
                image.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        
        }

        // Store image photo
        public async Task<string> StoreImages(Stream imageStream)
        {
            List<Product> list = App.mDatabase.GetProducts();
            int number = list.Count + 1;
            var stroageImage = await new FirebaseStorage("ciftcideneve-6894d.appspot.com")
                .Child("Images")
                .Child(number+".jpg")
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            Uri imageUri = new Uri(imgurl);
            Product.Path = imageUri;
            sellProductViewModel.imageUri = imageUri;
            sellProductViewModel.Path = imageUri;
            CrossToastPopUp.Current.ShowCustomToast("Fotoğraf yüklendi", 
                "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);

            return imgurl;
        }


        

    }
}