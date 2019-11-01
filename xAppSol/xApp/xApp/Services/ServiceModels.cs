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

    public partial class HomeViewResult
    {
        public string[] BannerUrls { get; set; }
        public TileSection[] TileSections { get; set; }
        public bool HasActiveCart { get; set; }
        public ShoppingCart Cart { get; set; }
        public UserInfo User { get; set; }

   
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

    public partial class HomeViewResult2
    {
        public string[] BannerUrls { get; set; }
        public HomeViewResult.TileSection[] TileSections { get; set; }
        public AppViewModel AppView { get; set; }
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

        //AppView
        public string UserName { get; set; }
        public string FullName { get; set; }
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

    public partial class StoreInfoViewModel
    {
        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BannerImageUrl { get; set; }
        public StoreReview ReviewRating { get; set; }
        public bool HasActiveCart { get; set; }
        public Address Address { get; set; }
        public int CartItemCount { get; set; }
        public AppViewModel AppView { get; set; }
    }

    public class StoreReview
    {
        public int StoreId { get; set; }
        public float Value { get; set; }
        public float VoteCount { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class StoreCategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StoreCount { get; set; }
        public string ImageUrl { get; set; }
    }

    public class StoreListViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public List<StoreListItem> StoreList { get; set; }
        public bool HasActiveCart { get; set; }
        public int? ActiveStoreId { get; set; }
        public StoreListViewModel()
        {
            this.StoreList = new List<StoreListItem>();
        }

        public class StoreListItem
        {
            public int StoreId { get; set; }
            public string StoreCode { get; set; }
            public string StoreName { get; set; }
            public string ShortName { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public string BannerImageUrl { get; set; }
            public StoreReview ReviewRating { get; set; }
            public bool HasActiveCart { get; set; }
            public Address Address { get; set; }
        }
    }

    public class SearcStoreRequestModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }

        public int[] FilterByCategoryIds { get; set; }
    }
    public partial class CheckoutViewModel
    {
        public bool IsCartValid { get; set; }
        public string ValidationCaption { get; set; }
        public string ValidationTitle { get; set; }
        public List<string> ValidationMessages { get; set; }
        public List<VoucherItem> AppliedVouchers { get; set; }
        public string VoucherErrorMessage { get; set; }
        public List<LineItem> LineItems { get; set; }
        public int TotalLineItem { get; set; }
        public int TotalItem { get; set; }
        public float TotalAmount { get; set; }
        public float TotalDiscount { get; set; }
        public float TotalVoucherDiscount { get; set; }
        public float OrderTotal { get; set; }
        public float AmountBeforeVoucherDiscount { get; set; }
        public CurrencyRef Currency { get; set; }
       

        public class VoucherItem
        {
            public string Code { get; set; }
            public string CodeDescription { get; set; }
            public float Amount { get; set; }
            public string Status { get; set; }
        }

        public class LineItem
        {
            public string Id { get; set; }
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string SubTitle { get; set; }
            public int Quantity { get; set; }
            public float Amount { get; set; }
            public float MRP { get; set; }
            public bool HasDiscount { get; set; }
        }
    }
    public class LoginOauthModel
    {
        public string ProviderName { get; set; }
        public string ProfileId { get; set; }
        //public string UserId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
    }
    public class LoginSuccessModel
    {
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AuthToken { get; set; }
        public string[] Roles { get; set; }
    }
    public class RegisterUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReferralCode { get; set; }
    }
    public class RegisterUserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string AuthToken { get; set; }
        public string Message { get; set; }
    }
}
