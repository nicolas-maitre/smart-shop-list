using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Shop_List.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddProductAsync(T item);
        Task<bool> UpdateProductAsync(T item);
        Task<bool> DeleteProductAsync(string id);
        Task<T> GetProductAsync(string id);
        Task<IEnumerable<T>> GetProductsAsync(bool forceRefresh = false);
    }
}
