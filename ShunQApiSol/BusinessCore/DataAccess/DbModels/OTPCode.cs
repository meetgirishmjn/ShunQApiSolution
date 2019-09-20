using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class OTPCode
    {
        public string Id { get; set; }
        public long UserMasterId { get; set; }
        public string OTP { get; set; }
        public string OTPType { get; set; }
        public DateTime ExpireOn { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
