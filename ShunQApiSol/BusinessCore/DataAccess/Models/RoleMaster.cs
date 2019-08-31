using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.Models
{
    public class RoleMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
