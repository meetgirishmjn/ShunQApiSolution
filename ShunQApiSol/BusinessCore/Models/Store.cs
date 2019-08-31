using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public bool IsActive { get; set; }
        public Address Address { get; set; }
    }
}
