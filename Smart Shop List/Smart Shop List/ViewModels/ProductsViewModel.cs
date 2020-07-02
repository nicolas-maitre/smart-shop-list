using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Smart_Shop_List.Models;
using Smart_Shop_List.Views;

namespace Smart_Shop_List.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Items { get; set; }
        public Command LoadProductsCommand { get; set; }

        public ProductsViewModel()
        {
            Title = "Produits";
            Items = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            MessagingCenter.Subscribe<NewItemPage, Product>(this, "AddProduct", async (obj, item) =>
            {
                var newItem = item as Product;
                Items.Add(newItem);
                await DataStore.AddProductAsync(newItem);
            });
        }

        async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetProductsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}