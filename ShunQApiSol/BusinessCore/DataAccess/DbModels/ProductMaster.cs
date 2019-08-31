using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class ProductMaster
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ThumbImage { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public ICollection<ProductCategory> Categories { get; set; }
        public ICollection<ProductBarcode> BarCodes { get; set; }
    }
}
