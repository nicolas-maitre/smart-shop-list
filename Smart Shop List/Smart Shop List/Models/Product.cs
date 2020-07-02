using SQLite;
using System;

namespace Smart_Shop_List.Models
{
    public class Product : IEquatable<Product>, IComparable<Product>
    {
        [PrimaryKey]
        public string Id { get; set; }
        public ProductState State { get; set; }
        public string Title { get; set; }
        //public string Description { get; set; }
        public float Score { get; set; }

        public enum ProductState { Exist, Added, Bought, Deleted }
        public override bool Equals(object obj)
        {
            Product product = obj as Product;
            if (product == null)
            {
                return false;
            }
            return Equals(product);
        }

        public bool Equals(Product product)
        {
            return Id == product.Id;
        }

        public int CompareTo(Product product)
        {
            if(Score == product.Score)
            {
                return 0;
            }
            return (Score > product.Score) ? 1 : -1;
        }
    }
    /**
     * Exist: in products list
     * Added: in shop list
     * Bought: in shop list but was bought
     * Deleted: removed from db
     */
}