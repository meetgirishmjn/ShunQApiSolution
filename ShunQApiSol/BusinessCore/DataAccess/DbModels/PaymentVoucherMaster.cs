using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class PaymentVoucherMaster
    {
        public long Id { get; set; }
        public string PaymentGatewayName { get; set; }
        public string Status { get; set; }
        public bool IsSuccess { get; set; }
        public string CartId { get; set; }
        public float Amount { get; set; }
        public string UserName { get; set; }
        public string GatewayResponse { get; set; }
        public string GatewayPaymentId { get; set; }
        public bool HashValidation { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
