using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.Models
{
    public class UserMaster
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ImageId { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public bool EmailVerified { get; set; }
        public bool MobileVerified { get; set; }
        public string Props { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
