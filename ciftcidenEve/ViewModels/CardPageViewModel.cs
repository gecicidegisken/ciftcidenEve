using ciftcidenEve.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ciftcidenEve.ViewModels
{
    public class CardPageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> BagProducts { get; }
        public Command LoadItemsCommand { get; }
        public CardPageViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            BagProducts = new ObservableCollection<Product>();
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BagProducts.Clear();
                BagProducts.Clear();
                var bagItems = App.products;

                foreach (var item in bagItems)
                {
                    BagProducts.Add(item);
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
    }
}
