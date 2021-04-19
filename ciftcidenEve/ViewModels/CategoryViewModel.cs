using System.Windows.Input;
using Xamarin.Forms;
using ciftcidenEve.Models;
using ciftcidenEve.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;

namespace ciftcidenEve.ViewModels
{
    public class CategoryViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; }

        public Command LoadItemsCommand { get; }
        public Command<Product> ItemTapped { get; }

        public static string Tag;
       

        
        public CategoryViewModel()
        {
            
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Products = new ObservableCollection<Product>();
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
                    if(item.Tag==Tag)
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
