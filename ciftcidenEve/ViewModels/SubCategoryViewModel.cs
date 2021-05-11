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
    public class SubCategoryViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; }


        public Command LoadItemsCommand { get; }
        public Command<Product> ItemTapped { get; }

        public string Tag;

        public string PageTitle { get; }

        public SubCategoryViewModel() { }
        public SubCategoryViewModel(string Tag)
        {

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
           
            Products = new ObservableCollection<Product>();
            ItemTapped = new Command<Product>(ShowItemDetails);
            PageTitle = Tag;
            this.Tag = Tag;

        }

        async Task ExecuteLoadItemsCommand()
        {

            IsBusy = true;

            try
            {
                Products.Clear();
                List<Product> itemsdb = App.mDatabase.GetProductsBySubTag(Tag);
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


        private async void ShowItemDetails(Product product)
        {
            if (product == null)
                return;


            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ItemId)}={product.Id}");

        }


    }
}
