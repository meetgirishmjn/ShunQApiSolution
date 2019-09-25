using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
   public class CartVoucher
    {
        public string Id { get; set; }
        public string VoucherId { get; set; }
        public DateTime AppliedOn { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        [ForeignKey("VoucherId")]
        public DiscountVoucherMaster VoucherMaster { get; set; }
    }
}
