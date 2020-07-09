using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookTime.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

    }



    public interface UDataStore<T> { 
        Task<bool> AddUserAsync(T user);
        Task<bool> UpdateUserAsync(T user);
        Task<bool> DeleteUserAsync(string id);
        Task<T> GetUserAsync(string id);
        Task<IEnumerable<T>> GetUserAsync(bool forceRefresh = false);
    }
}
