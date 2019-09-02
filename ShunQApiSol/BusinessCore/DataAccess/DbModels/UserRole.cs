using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class UserRole
    {
        public int Id { get; set; }
        public long UserMasterId { get; set; }
        public int RoleMasterId { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public UserMaster UserMaster { get; set; }

        public RoleMaster RoleMaster { get; set; }
    }
}
