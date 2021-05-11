using ciftcidenEve.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Plugin.Toast;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ciftcidenEve.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ProductDetailViewModel : BaseViewModel
    {
        public Command AddBagCommand { get; }
        
        string text;
        string tag;
        string subTag;
        float price;
        string description;
        string satici;
        int itemId;
        Image image;
      

        public ProductDetailViewModel()
        {
            LoadItemId(ItemId);
            AddBagCommand = new Command(OnAddClicked);
            
        }
        private async void OnAddClicked(object obj) { 
        
            Product product = App.mDatabase.GetProduct(itemId).Result;
            Product bagProduct = new Product();
            bagProduct.Id = App.products.Count + 1;
            bagProduct.Text = product.Text;
            bagProduct.Price = product.Price;
            bagProduct.Satici = product.Satici;
            bagProduct.Tag = product.Tag;


            App.products.Add(bagProduct);
            CrossToastPopUp.Current.ShowCustomToast("Ürün Sepete Eklendi", "#f5712f", "white", Plugin.Toast.Abstractions.ToastLength.Short);
        }
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
        public string SubTag
        {
            get => subTag;
            set => SetProperty(ref subTag, value);
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
                Product item = App.mDatabase.GetProduct(itemId).Result;
                Id = item.Id;
                Text = item.Text;
                Tag = item.Tag;
                SubTag = item.SubTag;
                Description = item.Description;
                Price = item.Price;
               // Image = item.Image; 
               // Image.Source = item.Image.Source;
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
