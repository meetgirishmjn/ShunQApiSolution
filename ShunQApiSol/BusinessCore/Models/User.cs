using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int CompanyId { get; set; }
        public string[] Roles { get; set; }

        public User()
        {
            this.Roles = new string[] { };
        }
    }
}
