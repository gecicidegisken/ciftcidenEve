using ciftcidenEve.Models;
using System;
using ciftcidenEve.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using Plugin.Toast;

namespace ciftcidenEve.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> BagProducts { get; set; }
        public Command LoadItemsCommand { get; }
        public Command DeleteCommand { get; }
        public bool hasItems { get; set; }
        public Command<Product> ItemTapped { get; }
        public Command PaymentCommand { get; }
        public string Total { get; set; }
        public IObservable<String> Totalll { get; set; }
        public float ttl = 0;

        public CardPageViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            BagProducts = new ObservableCollection<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
            DeleteCommand = new Command<Product>(RemoveFromCard);
            PaymentCommand = new Command(OnPaymentClicked);

        }
       public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BagProducts.Clear();

                var bagItems = App.shoppingCard.ListProducts();

                foreach (var item in bagItems)
                {
                    BagProducts.Add(item);
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
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ItemIdFromCard)}={product.Id}");
        }
        public void onAppearing()
        {
            if(BagProducts.Count > 0)
            {
                hasItems = false;
                this.OnPropertyChanged("hasItems");
            }
            else
            {
                hasItems = true;
                this.OnPropertyChanged("hasItems");
            }
            IsBusy = true;
        }


        private async void RemoveFromCard(Product product)
        {
            App.shoppingCard.RemoveFromCard(product);
            onAppearing();
            await ExecuteLoadItemsCommand();
            Debug.WriteLine("silindi. ");
        }


        private async void OnPaymentClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(PaymentPage)}");
        }
        
    }
}
