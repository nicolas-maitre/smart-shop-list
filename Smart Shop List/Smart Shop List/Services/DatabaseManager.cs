using Smart_Shop_List.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Shop_List.Services
{
    public class DatabaseManager
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        public static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        public DatabaseManager()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Product).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Product)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await Database.Table<Product>().ToListAsync();
            return products;
        }

        public Task<Product> GetProductAsync(string id)
        {
            return Database.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.Id != null)
            {
                return Database.UpdateAsync(product);
            }
            else
            {
                return Database.InsertAsync(product);
            }
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return Database.DeleteAsync(product);
        }
    }

}
