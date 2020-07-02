using System;

using Smart_Shop_List.Models;

namespace Smart_Shop_List.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Product Item { get; set; }
        public ItemDetailViewModel(Product item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
