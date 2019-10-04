using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class CartDeviceEventArg
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string DeviceId { get; set; }
        public string CartId { get; set; }
        public string LogType { get; set; }
        public string ProductId { get; set; }
        public float CartWeight { get; set; }
        public string Data { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
