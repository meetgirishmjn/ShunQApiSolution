using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelementryApi.RequestModels
{
    public class ItemAddedModel
    {
        public string CartQRCode { get; set; }
        public string ItemQRCode { get; set; }
        public float CartWeight { get; set; }
    }
}
