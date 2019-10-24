using System;
using System.Collections.Generic;
using System.Text;
using xApp.ViewModels;

namespace xApp.Services
{
    public class ErrorResponse
    {
        public string Message { get; set; }
    }
    public class LogInResult
    {
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AuthToken { get; set; }
    }

    public class HomeViewResult
    {
        public AppViewModel App { get { return AppViewModel.Instance; } }
        public string[] BannerUrls { get; set; }
        public TileSection[] TileSections { get; set; }
        public bool HasActiveCart { get; set; }
        public ShoppingCart Cart { get; set; }
        public UserInfo User { get; set; }

        public HomeViewResult()
        {
            this.BannerUrls = new string[] { };
            this.TileSections = new TileSection[] { };
        }

        public class TileSection
        {
            public string Title { get; set; }
            public Tile[] Tiles { get; set; }
        }

        public class Tile
        {
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string DetailUrl { get; set; }
        }
    }

    public class UserInfo
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ImageId { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public bool EmailVerified { get; set; }
        public bool MobileVerified { get; set; }
        public string Props { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }

        public string[] Roles { get; set; }

        public UserInfo()
        {
            this.Roles = new string[] { };
        }
    }
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
        public int ItemCount { get; set; }

        public List<CartItemVM> Items { get; set; }

        public List<CartVoucherItem> Vouchers { get; set; }

        public int LineItemCount { get; set; }
        public float TotalAmount { get; set; }
        public float TotalItemDiscount { get; set; }
        public float TotalVoucherDiscount { get; set; }
        public float NetAmount { get; set; }
        public float AmountBeforeVoucherDiscount { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<CartItemVM>();
            this.Vouchers = new List<CartVoucherItem>();
        }
    }

    public class CurrencyRef
    {
        public string Currency { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

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
