using SQLite;
using System;

namespace Smart_Shop_List.Models
{
    public class Product
    {
        [PrimaryKey]
        public string Id { get; set; }
        public ProductState State { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public enum ProductState { Exist, Added, Bought, Deleted }
    }
    /**
     * Exist: in products list
     * Added: in shop list
     * Bought: in shop list but was bought
     * Deleted: removed from db
     */
}