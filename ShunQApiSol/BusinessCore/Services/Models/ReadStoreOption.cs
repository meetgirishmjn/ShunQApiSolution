using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Models
{
   public class ReadStoreOption
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? CategoryId { get; set; }
    }
}
