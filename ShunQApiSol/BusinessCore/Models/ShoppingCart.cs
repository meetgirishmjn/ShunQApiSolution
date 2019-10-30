using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessCore.Models
{
   public class ShoppingCart
    {
        public string Id { get; set; }

        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string CartDeviceId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public string StoreBannerImage { get; set; }

        public CurrencyRef Currency { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; }
        public int ItemCount { get { return Items.Count; } }

        public List<CartItemVM> Items { get; set; }

        public List<CartVoucherItem> Vouchers { get; set; }

        public int LineItemCount { get { return Items.GroupBy(o => o.ProductId).Count(); } }
        public float TotalAmount { get; set; }
        public float TotalItemDiscount { get; set; }
        public float TotalVoucherDiscount { get; set; }
        public float NetAmount { get; set; }
        public float AmountBeforeVoucherDiscount { get; set; }
        public ShoppingCart()
        {
            Currency = CurrencyRef.India;
            this.Items = new List<CartItemVM>();
            this.Vouchers = new List<CartVoucherItem>();
        }
    }

    public class CartView
    {
        public bool HasActiveCart { get; set; }
        public int CartItemCount { get; set; }
        public int StoreId { get; set; }
    }
        public class CartItemVM
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ThumbImage { get; set; }
        public float MRP { get; set; }
        public float Discount { get; set; }
        public string DiscountText { get; set; }
        public float Price { get; set; }
        public int SortOrder { get; set; }
        public int Quantity { get; set; }
    }

    public class CartVoucherItem
    {
        public string VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }


}
