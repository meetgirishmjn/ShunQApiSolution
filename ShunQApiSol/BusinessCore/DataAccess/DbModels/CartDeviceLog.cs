using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class CartDeviceLog
    {
        public string Id { get; set; }
        public string AppId { get; set; }
        public string DeviceId { get; set; }
        public string ShoppingCartId { get; set; }
        public string CartDeviceId { get; set; }
        public string LogType { get; set; }
        public string ProductId { get; set; }
        public float CartWeight { get; set; }
        public string Data { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
