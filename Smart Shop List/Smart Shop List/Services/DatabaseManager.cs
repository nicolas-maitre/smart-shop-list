using Newtonsoft.Json;
using PCLStorage;
using Smart_Shop_List.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smart_Shop_List.Services
{
    public class DatabaseManager
    {
        const string jsonDbFilePath = "db.json";
        private IFile dbFile = null;
        public DatabaseManager()
        {
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var products = await GetProductsAsync();
            foreach(var product in products)
            {
                if (product.Id == id) return product;
            }
            return null;
        }

        public async Task SaveProductAsync(Product product)
        {
            var products = await GetProductsAsync();
            var alreadyProduct = products.Remove(product);
            products.Add(product);
            SaveProductsAsync(products);
        }

        public async Task DeleteProductAsync(Product product)
        {
            var products = await GetProductsAsync();
            var alreadyProduct = products.Remove(product);
            SaveProductsAsync(products);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            string jsonText = await (await GetDbFile()).ReadAllTextAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(jsonText);
            if (products == null)
            {
                products = new List<Product>();
            }
            return products;
        }

        public async void SaveProductsAsync(List<Product> products)
        {
            string jsonString = JsonConvert.SerializeObject(products);
            await (await GetDbFile()).WriteAllTextAsync(jsonString);
        }

        private async Task<IFile> GetDbFile()
        {
            if (dbFile == null)
            {
                var appFolder = FileSystem.Current.LocalStorage;
                dbFile = await appFolder.CreateFileAsync(jsonDbFilePath, CreationCollisionOption.OpenIfExists);
            }
            return dbFile;
        }
    }

}
