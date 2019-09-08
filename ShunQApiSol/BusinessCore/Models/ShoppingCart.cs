using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class ShoppingCart
    {
        public string Id { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }


        public long UserId { get; set; }
        public string Status { get; set; }
        public int ItemCount { get { return Items.Count; } }

        public List<Item> Items { get; set; }

        public ShoppingCart()
        {
            this.Items = new List<Item>();
        }

        public class Item
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string ShortName { get; set; }
            public string Description { get; set; }
            public string ThumbImage { get; set; }
            public float MRP { get; set; }
            public float Discount { get; set; }
            public string DiscountText { get; set; }
            public float Price { get; set; }
            public int SortOrder { get; set; }
            public int Quantity { get; set; }
        }
    }

   
}
