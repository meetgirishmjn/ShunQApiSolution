using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int SortOrder { get; set; }
        public int Quantity { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
