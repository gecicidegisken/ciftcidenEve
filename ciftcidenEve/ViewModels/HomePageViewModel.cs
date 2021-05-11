using System.Windows.Input;
using Xamarin.Forms;
using ciftcidenEve.Models;
using ciftcidenEve.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;

namespace ciftcidenEve.ViewModels
{
    public class HomePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Product _selectedItem;
        public List<Product> Products { get; }
        public ICommand AccountCommand { get; }
        public ICommand ItemDetailCommand { get; }
        public Command LoadItemsCommand { get; }     
        public ICommand CategoryCommand { get; }

        public ProductDetailViewModel details;
        public Command<Product> ItemTapped { get; }
        public string Tag { get; }
      

        public HomePageViewModel()
        {
            Title = "Ana Sayfa";
            ItemDetailCommand = new Command<Product>(ShowItemDetails);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AccountCommand = new Command(OnAccountClicked);
            Products = new List<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
            CategoryCommand = new Command<string>(ShowCategory);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            
            try
            {
                Products.Clear();
                List<Product> itemsdb = App.mDatabase.GetProducts();
                foreach (var item in itemsdb)
                {
                    Products.Add(item);
                }
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            finally
            {
                IsBusy = false;
            }
           
        }

        private async void OnAccountClicked(object obj)
        {
            if (App.authorization)
            {
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