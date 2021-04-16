using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ciftcidenEve.Models;
using ciftcidenEve.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;


namespace ciftcidenEve.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }
        public ICommand LoginCommand => new Command(OnLoginClicked);
        public ICommand ItemDetailCommand => new Command<Product>(ShowItemDetails);
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }

        public HomePageViewModel()
        {
            Title = "Ana Sayfa";
         
            Products = new ObservableCollection<Product>();
            
            AddItemCommand = new Command(OnAddItem);
        }

     
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));  //ürün satış page'ye gidecek şekilde yönlendirilecek
        }
        private async void ShowItemDetails(Product product)
        {
            if (product == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={product.Id}");
        }

    }
}