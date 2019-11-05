using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Models
{
    public class CartVoucher
    {
        public long VoucherId { get; set; }
        public string PaymentGatewayName { get; set; }
        public string Status { get; set; }
        public string CartId { get; set; }
        public string GatewayResponse { get; set; }
        public string GatewayPaymentId { get; set; }
        public string UserEmail { get; set; }
        public bool HashValidated { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
