using System.Windows.Input;
using Xamarin.Forms;
using ciftcidenEve.Models;
using ciftcidenEve.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ciftcidenEve.ViewModels
{
    public class HomePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Product _selectedItem;
        public ObservableCollection<Product> Products { get; set; }
        public ICommand AccountCommand { get; }
        public ICommand ItemDetailCommand { get; }
        public Command LoadItemsCommand { get; }     
        public ICommand CategoryCommand { get; }

        public ProductDetailViewModel details;
        public Command<Product> ItemTapped { get; }
        public Command ImageRetrieve{ get; set; }
        public  string Filter = "";
        public  string SubFilter = "";
      

        public HomePageViewModel()
        {
            Title = "Ana Sayfa";
            ItemDetailCommand = new Command<Product>(ShowItemDetails);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AccountCommand = new Command(OnAccountClicked);
            Products = new ObservableCollection<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
            CategoryCommand = new Command<string>(ShowCategory);
            ImageRetrieve = new Command(imageRetrieve);
        }

       
        async public Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
           
            try { 
            if (Filter == "Şehir")
            {
               
                Products.Clear();
                List<Product> itemsdb = App.mDatabase.GetProductsByCity(SubFilter);
                foreach (var item in itemsdb)
                {
                    Products.Add(item);
                } 
                Debug.WriteLine(" şehir içinde alt filtre: " +SubFilter);
            }
            else if (Filter == "Fiyat")
            {
                
                Debug.WriteLine("Fiyata göre sıralama");
            }
            else if (Filter == "Satıcı")
            {
              
                Products.Clear();
                List<Product> itemsdb = App.mDatabase.GetProductsBySeller(SubFilter);
                foreach (var item in itemsdb)
                {
                    Products.Add(item);
                }
            }

            else
            {
               
                Products.Clear();
                List<Product> itemsdb = App.mDatabase.GetProducts();
                foreach (var item in itemsdb)
                {
                    Products.Add(item);
                }
            }
            }
            finally { 
            IsBusy = false;
            }
        }


        public void onAppearing()
        {
            IsBusy = true;

            try
            {
                if (Filter == "Şehir")
                {

                    Products.Clear();
                    List<Product> itemsdb = App.mDatabase.GetProductsByCity(SubFilter);
                    foreach (var item in itemsdb)
                    {
                        Products.Add(item);
                        OnPropertyChanged();
                    }
                   
                    Debug.WriteLine(" şehir içinde alt filtre: " + SubFilter);
                }
                else if (Filter == "Fiyat")
                {

                    Debug.WriteLine("Fiyata göre sıralama");
                    OnPropertyChanged();
                }
                else if (Filter == "Satıcı")
                {

                    Products.Clear();
                    List<Product> itemsdb = App.mDatabase.GetProductsBySeller(SubFilter);
                    foreach (var item in itemsdb)
                    {
                        Products.Add(item);
                        OnPropertyChanged();
                    }
                }

                else
                {

                    Products.Clear();
                    List<Product> itemsdb = App.mDatabase.GetProducts();
                    foreach (var item in itemsdb)
                    {
                        Products.Add(item);
                        OnPropertyChanged();
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }


        public void imageRetrieve()
        {
            Image image = new Image();
            image.Source = ImageSource.FromUri(new Uri(""));
        }

        private async void OnAccountClicked(object obj)
        {
            if (App.authorization)
            {Debug.WriteLine(Filter);
                Debug.WriteLine("giriş yapılmış");
                //burda hesabım sayfasına yönlendirelecek
            }
            else
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
            
        }
      
        public Product SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                ShowItemDetails(value);
            }
        }
 
        private async void ShowItemDetails(Product product)
        {
            if (product == null)
                return;
        
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ItemId)}={product.Id}");

        }

        private async void ShowCategory(string tag)
        {
            Debug.WriteLine("buraya kadar geldi");
            await Application.Current.MainPage.Navigation.PushAsync(new CategoryPage(tag));

        }
        

    }

}

