using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class ProductCategoryXref
    {
        public long Id { get; set; }
        public string ProductMasterId { get; set; }
        public ProductMaster Product { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}
