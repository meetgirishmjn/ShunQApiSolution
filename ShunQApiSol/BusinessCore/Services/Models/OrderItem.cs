using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Models
{
   public class OrderItem
    {
        public string OrderId { get; set; }
        public string OrderQR { get; set; }
        public string Status { get; set; }
        public bool IsSuccess { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime OrderDate { get; set; }
        public float Amount { get; set; }
    }
}
