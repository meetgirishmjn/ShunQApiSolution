using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.Models
{
    public class LogInSession
    {
        public Guid Id { get; set; }
        public long UserMasterId { get; set; }
        public string AuthToken { get; set; }
        public DateTime ExpireOn { get; set; }
        public string DeviceId { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual UserMaster UserMaster { get; set; }
    }
}
