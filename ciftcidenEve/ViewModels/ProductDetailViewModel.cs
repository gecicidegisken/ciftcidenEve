using ciftcidenEve.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ciftcidenEve.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ProductDetailViewModel : BaseViewModel
    {
        Product product = new Product();

        string text;
        string tag;
        float price;
        string description;
        int itemId;

        public int Id { get; set; }
     
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }   
        public string Tag
        {
            get => tag;
            set => SetProperty(ref tag, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public float Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                Product item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Tag = item.Tag;
                Description = item.Description;
                Price = item.Price;
           
              
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            this.OnPropertyChanged();
        }

    }
}
