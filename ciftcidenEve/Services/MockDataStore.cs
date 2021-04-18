
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
            var domates = new Image { Source = "domates.png" };
            var yumurta = new Image { Source = "yumurta.png" };
            var sabun = new Image { Source = "sabun.png" };
            var recel = new Image { Source = "recel.png" };
            var meyveFidani = new Image { Source = "meyve_fidani.png" };
            
         
            items = new List<Product>()
            {
                new Product { Id =1, Text = "Yerli Domates Fidesi", Description="10 adet", Price=10, Tag = "Sebze", Image=domates, Satici="Hilal Elif Mutlu" },
                new Product { Id = 2, Text = "Tavuk Yumurtası", Description="1 Adet", Price=3, Tag = "Kahvaltılık", Image=yumurta,  Satici="Arif Karaçalıoğlu"},
                new Product { Id=3, Text = "Doğal Sabun", Description="Lavantalı el yapımı sabun", Price=20, Tag = "Kişisel Bakım", Image=sabun,  Satici="Hilal Elif Mutlu"},
                new Product { Id= 4, Text = "Çilek Reçeli", Description="En taze çileklerden üretilen çilek reçeli, 500 gr", Price=25, Tag = "Kahvaltılık", Image=recel, Satici="Hilal Elif Mutlu"},
                new Product { Id=5, Text = "Elma Fidanı", Description="1 Adet", Price=50, Tag = "Çiçek, Fidan, Tohum", Image=meyveFidani, Satici="Arif Karaçalıoğlu"},

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

        public Product GetItemsAsync(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}