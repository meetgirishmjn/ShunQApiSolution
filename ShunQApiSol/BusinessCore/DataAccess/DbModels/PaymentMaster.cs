using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class PaymentMaster
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public string Amount { get; set; }
        public string Hash { get; set; }
        public string Status { get; set; }
    }
}
