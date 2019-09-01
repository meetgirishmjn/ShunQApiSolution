using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class ShoppingCart
    {
        public string Id { get; set; }

        public int StoreId { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }

        public List<Item> Items { get; set; }

        public ShoppingCart()
        {
            this.Items = new List<Item>();
        }

        public class Item
        {
            public string ProductId { get; set; }
            public int SortOrder { get; set; }
            public int Quantity { get; set; }
        }
    }

   
}
