using ciftcidenEve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace ciftcidenEve.Services
{
    public class MockDataStore : IDataStore<Product>
    {
        
        readonly List<Product> items;
        public MockDataStore()
        {
            var domates = new Image { Source = "card_icon" };
            var yumurta = new Image();
            yumurta.Source = ImageSource.FromUri(new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"));
            items = new List<Product>()
            {
                new Product { Id =1, Text = "Yerli Domates Fidesi", Description="10 adet", Price=10, Tag = "Sebze", Image=domates, Satici="Hilal" },
                new Product { Id = 2, Text = "Tavuk Yumurtası", Description="1 Adet", Price=3, Tag = "Kahvaltılık", Image=yumurta},
                
            };
        }

        public async Task<bool> AddItemAsync(Product item)
        {
            item.Id = items.Count + 1;
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var oldItem = items.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Product arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
    }
}
}