using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{

    public class StoreCategoryXref
    {
        public long Id { get; set; }
        public int StoreMasterId { get; set; }
        public StoreMaster Store { get; set; }

        public int StoreCategoryId { get; set; }
        public StoreCategory Category { get; set; }
    }
}
