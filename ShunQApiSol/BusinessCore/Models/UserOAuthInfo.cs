using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
   public class UserOAuthInfo
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public bool EmailVerified { get; set; }
        public bool MobileVerified { get; set; }
        public string OAuthProvider { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string[] Roles { get; set; }

        public UserOAuthInfo()
        {
            this.Roles = new string[] { };
        }
    }
}
