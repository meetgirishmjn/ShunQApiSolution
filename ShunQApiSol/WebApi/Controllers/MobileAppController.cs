using BusinessCore.Extensions;
using BusinessCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.RequestModels;
using WebApi.ViewModels;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/v1/mobile")]
    [ApiController]
    public class MobileAppController : BaseController
    {
        public MobileAppController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet("store/category")]
        public List<ListItem> GetStoreCategories()
        {
            var service = CreateStoreService();
            var results = service.GetAllStoreCategory();

            return results;
        }
        [HttpPost("store/search")]
        public StoreListViewModel SearchStores(StoreListModel model)
        {
            var result = new StoreListViewModel();

            var categoryId = 0;

            model.PageIndex  = model.PageIndex <= 0 ? 1 : model.PageIndex;
            model.PageSize  = model.PageSize <= 0 ? 1 : model.PageSize;

            if (model.FilterBy != null)
            {
                categoryId = model.FilterBy.CategoryId.HasValue ? model.FilterBy.CategoryId.Value : 0;
            }
            var service = CreateStoreService();

            var query = categoryId > 0 ? service.ReadStores(categoryId) : service.ReadStores();

            var searchKey = model.SearchKey.TrimAll().ToLower();

            if (searchKey.Length != 0)
            {
                if (searchKey.Length == 1)
                    query = query.Where(o => o.ShortName.ToLower().IndexOf(searchKey) == 0);
                else
                    query = query.Where(o => o.ShortName.ToLower().IndexOf(searchKey) != -1);
            }

            var totalCount = query.Count();

            query = query.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize);

            var stores = query.ToList();

            result.PageSize = model.PageSize;
            result.PageIndex = model.PageIndex;
            result.PageCount = stores.Count;
            result.TotalCount = totalCount;

            var storeReviews = service.StoreReviews(stores.Select(o => o.Id).ToArray()).ToLookup(o => o.StoreId);
            result.StoreList = stores.Select(o => new StoreListViewModel.StoreListItem
            {
                StoreId = o.Id,
                StoreCode = o.Code,
                ShortName = o.ShortName,
                Description = o.Description,
                StoreName = o.Name,
                HasActiveCart = false,
                ReviewRating= storeReviews.Contains(o.Id)?storeReviews[o.Id].FirstOrDefault():new StoreReview { StoreId=o.Id},
                BannerImageUrl=o.BannerImage,
                ImageUrl=o.Image
            }).ToList();

            return result;
        }

        [HttpGet("Ver")]
        public VersionViewModel Ver()
        {
            var membsership = base.CreateMembershipService();

            var dbStatus = "ok";
            try
            {
                membsership.Test();
            }
            catch (Exception ex)
            {
                dbStatus = ex.Message + ex.InnerException?.Message;
            }

            return new VersionViewModel
            {
                DbStatus = dbStatus,
                Status = "ok",
                Version = "1.0.0",
                Values = new Dictionary<string, string>()
                {

                }
            };
        }
    }
}
