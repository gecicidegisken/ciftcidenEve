using ciftcidenEve.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Plugin.Toast;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ciftcidenEve.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(ItemIdFromCard), nameof(ItemIdFromCard))]
    public class ProductDetailViewModel : BaseViewModel
    {
        public Command AddBagCommand { get; }
        
        string text;
        string tag;
        string subTag;
        float price;
        string description;
        string satici;
        string city;
        int itemId;
        Uri path;
      

        public ProductDetailViewModel()
        {
            LoadItemId(ItemId);
            LoadItemIdCard(ItemId);
            AddBagCommand = new Command(OnAddClicked);
            
        }
        private async void OnAddClicked(object obj) { 
        
            Product product = App.mDatabase.GetProduct(itemId).Result;
            Product bagProduct = new Product();
            bagProduct.Text = product.Text;
            bagProduct.Price = product.Price;
            bagProduct.Satici = product.Satici;
            bagProduct.City = product.City;
            bagProduct.Tag = product.Tag;
            bagProduct.Path = product.Path;


            App.shoppingCard.AddToCard(bagProduct);
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
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        public Uri Path
        {

            get => path; 
            set => SetProperty(ref path, value);
            
           
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

        public int ItemIdFromCard
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemIdCard(value);
            }
        }

        public async void LoadItemIdCard(int itemId)
        {
            try
            {
                Product item = App.shoppingCard.GetProduct(itemId);
                Id = item.Id;
                Text = item.Text;
                Tag = item.Tag;
                SubTag = item.SubTag;
                Description = item.Description;
                Price = item.Price;
                Path = item.Path;
                Satici = item.Satici;
                City = item.City;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            this.OnPropertyChanged();
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
                Path = item.Path;
                Satici = item.Satici;
                City = item.City;
              
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            this.OnPropertyChanged();
        }

    }
}
