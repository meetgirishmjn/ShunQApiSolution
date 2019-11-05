using BusinessCore.Models;
using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCore.Services.Contracts
{
   public interface IStoreService
    {
        List<StoreCategoryItem> GetAllStoreCategory();
        IQueryable<Store> ReadStores();
        IQueryable<Store> ReadStores(StoreReadOption options);
        Store GetStore(int id);
        Store GetStore(string qrCode);
        Store GetStoreByDeviceId(string cartDeviceId);
        IQueryable<Store> ReadStores(int categoryId);
        StoreReview StoreReview(int storeId);
        List<StoreReview> StoreReviews(int[] storeIds);
        ShoppingCart StartShopping(string cartDeviceId);
        ShoppingCart GetCart(string cartId);
        ShoppingCart GetCart(long userId);
        ShoppingCart GetCart();
        ShoppingCart AddItemToCart(string productbarcode);
        ShoppingCart RemoveItemFromCart(string productbarcode);
        ShoppingCart AddVoucherToCart(string voucherCode);
        ShoppingCart RemoveVoucherToCart(string voucherCode);
        void DiscardCart();
        Task<CartDeviceEventArg> CartDeviceProductAddedAsync(CartDeviceEventArg arg);
        Task<CartDeviceEventArg> CartDeviceProductRemovedAsync(CartDeviceEventArg arg);
        Task<List<string>> ReadCartDeviceLogsAsync();
        Task<List<string>> ReadCartDeviceLogsAsync(string cartDeviceId);
        Task<int> RemoveAllCartDeviceLogsAsync(string cartDeviceId);
        CartValidationResult ValidateCart(string cartId);
        CartValidationResult ValidateCart();
        CartView GetCartView();
        CartVoucher  CreateCartVoucher(CartVoucher voucher);
        CartVoucher GetCartVoucher(string cartId);
    }
}
