using ciftcidenEve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ciftcidenEve.Services
{
    public class MockDataStore : IDataStore<Product>
    {
        readonly List<Product> items;

        public MockDataStore()
        {
            items = new List<Product>()
            {
                new Product {  Text = "First item", Description="This is an item description." },
                new Product {  Text = "Second item", Description="This is an item description." },
                new Product {  Text = "Third item", Description="This is an item description." },
                new Product {  Text = "Fourth item", Description="This is an item description." },
                new Product {  Text = "Fifth item", Description="This is an item description." },
                new Product {  Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Product item)
        {
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