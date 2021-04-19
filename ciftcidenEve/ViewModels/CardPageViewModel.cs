using ciftcidenEve.Models;
using System;
using ciftcidenEve.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Toast;

namespace ciftcidenEve.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> BagProducts { get; }
        public Command LoadItemsCommand { get; }
        
      

        public bool hasItems { get; set; }
        public Command<Product> ItemTapped { get; }
        public CardPageViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            BagProducts = new ObservableCollection<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BagProducts.Clear();
                
                var bagItems = App.products;

                foreach (var item in bagItems)
                {
                    BagProducts.Add(item);
                    hasItems = false;
                    OnPropertyChanged();
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
        private async void ShowItemDetails(Product product)
        {
            if (product == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ItemId)}={product.Id}");

        }
      

    }
}
