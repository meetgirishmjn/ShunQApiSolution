using BusinessCore.Models;
using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessCore.Services.Contracts
{
   public interface IStoreService
    {
        List<StoreCategoryItem> GetAllStoreCategory();
        IQueryable<Store> ReadStores();
        IQueryable<Store> ReadStores(ReadStoreOption options);
        Store GetStore(int id);
        Store GetStore(string qrCode);
        IQueryable<Store> ReadStores(int categoryId);
        StoreReview StoreReview(int storeId);
        List<StoreReview> StoreReviews(int[] storeIds);
        ShoppingCart StartShopping(int storeId);
        ShoppingCart GetCart(string cartId);
        ShoppingCart GetCart();
        ShoppingCart AddItemToCart(string productbarcode);
        ShoppingCart RemoveItemFromCart(string productbarcode);
        void DiscardCart();
    }
}
