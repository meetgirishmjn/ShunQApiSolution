using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelementryApi.RequestModels
{
    public class ItemAddedModel
    {
        public string CartId { get; set; }
        public string ItemCode { get; set; }
        public float CartWeight { get; set; }
    }
}
