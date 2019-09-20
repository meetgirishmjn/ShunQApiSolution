using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class UserMasterOAuth
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ImageId { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public bool EmailVerified { get; set; }
        public bool MobileVerified { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
    }
}
