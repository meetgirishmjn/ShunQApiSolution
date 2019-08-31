using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
