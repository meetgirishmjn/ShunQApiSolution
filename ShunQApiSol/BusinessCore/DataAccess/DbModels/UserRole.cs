using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class UserRole
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
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
