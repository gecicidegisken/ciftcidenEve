using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ciftcidenEve.Models;
using ciftcidenEve.Views;
using ciftcidenEve.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ciftcidenEve.ViewModels
{
    public class HomePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        

        private Product _selectedItem;
        public ObservableCollection<Product> Products { get; }
        public ICommand LoginCommand { get; }
        public ICommand ItemDetailCommand { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public ProductDetailViewModel details;
        public Command<Product> ItemTapped { get; }

        public HomePageViewModel()
        {
            Title = "Ana Sayfa";
            AddItemCommand = new Command(OnAddItem);
            ItemDetailCommand = new Command<Product>(ShowItemDetails);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoginCommand = new Command(OnLoginClicked);
            Products =new ObservableCollection<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
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
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync("//UrunSatisPage"); 
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
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        private async void ShowItemDetails(Product product)
        {
            if (product == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //details = new ProductDetailViewModel(product.Text, product.Tag, product.Price);
            //await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(details)}");
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ItemId)}={product.Id}");
        
        
        }

        

    }
}