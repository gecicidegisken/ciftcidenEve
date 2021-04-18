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
 public class CategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; }
        public Command LoadItemsCommand { get; }

        public CategoryViewModel()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
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
                   // if(item.Tag)
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
    }
}
