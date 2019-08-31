using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class PriceMaster
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public float MRP { get; set; }
        public float Discount { get; set; }
        public string DiscountText { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
