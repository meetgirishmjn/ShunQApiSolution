﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessCore.DataAccess.DbModels
{
    public class ShoppingCart
    {
        public string Id { get; set; }

        public int StoreId { get; set; }

        public string CartDeviceId { get; set; }

        [Required]
        public long UserId { get; set; }

        public int Status { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ICollection<ShoppingCartItem> Items { get; set; }
        public ICollection<CartVoucher> Vouchers { get; set; }

        public CartDeviceMaster CartDeviceMaster { get; set; }
    }
}
