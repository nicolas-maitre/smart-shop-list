using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smart_Shop_List.Models;

namespace Smart_Shop_List.Services
{
    public class ProductsDataStore : IDataStore<Product>
    {
        readonly List<Product> products;

        public ProductsDataStore()
        {
            products = new List<Product>()
            {
                new Product { Id = "fake", Title = "loading..."},
            };
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            products.Add(product);
            await App.Database.SaveProductAsync(product);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateProductAsync(Product item)
        {
            var oldItem = products.Where((Product arg) => arg.Id == item.Id).FirstOrDefault();
            products.Remove(oldItem);
            products.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            var oldItem = products.Where((Product arg) => arg.Id == id).FirstOrDefault();
            products.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await Task.FromResult(products.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false)
        {
            List<Product> dbProducts = await App.Database.GetProductsAsync();
            products.Clear();
            products.Sort(); //sort by score
            products.AddRange(dbProducts);
            return await Task.FromResult(products);
        }
    }
}