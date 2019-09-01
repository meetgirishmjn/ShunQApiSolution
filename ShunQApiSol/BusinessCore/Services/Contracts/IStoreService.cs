using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessCore.Services.Contracts
{
   public interface IStoreService
    {
        List<ListItem> GetAllStoreCategory();
        IQueryable<Store> ReadStores();
        IQueryable<Store> ReadStores(int categoryId);
        StoreReview StoreReview(int storeId);
        List<StoreReview> StoreReviews(int[] storeIds);
    }
}
