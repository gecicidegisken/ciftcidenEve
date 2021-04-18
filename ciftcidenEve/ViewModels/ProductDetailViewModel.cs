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
        

        string text;
        string tag;
        float price;
        string description;
        string satici;
        int itemId;
        Image image;
      

        public int Id { get; set; }
     
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }  
       
        public string Satici
        {
            get => satici;
            set => SetProperty(ref satici, value);
        }
        public Image Image
        {

            get => image;
            set
            {
                SetProperty(ref image, value);
                OnPropertyChanged(nameof(Image));
              
            }
           
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
                Image = item.Image; 
                Image.Source = item.Image.Source;
                Satici = item.Satici;
              
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            this.OnPropertyChanged();
        }

    }
}
