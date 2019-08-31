using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class StoreMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public AddressMaster Address { get; set; }

    }


}
