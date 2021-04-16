using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ciftcidenEve.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T product);
        Task<bool> UpdateItemAsync(T product);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
