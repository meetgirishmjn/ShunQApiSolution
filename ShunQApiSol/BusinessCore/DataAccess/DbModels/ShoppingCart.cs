using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public int StoreId { get; set; }
        public long UserId { get; set; }
        public int Status { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
