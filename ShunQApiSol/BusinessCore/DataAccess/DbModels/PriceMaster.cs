using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class PriceMaster
    {
        [Key]
        public string Id { get; set; }

        [Required]
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
