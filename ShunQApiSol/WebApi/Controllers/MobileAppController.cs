using BusinessCore.Extensions;
using BusinessCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.RequestModels;
using WebApi.ViewModels;
using System.Linq;
using Microsoft.Extensions.Options;
using BusinessCore;
using Microsoft.AspNetCore.Authorization;
using BusinessCore.Services.Models;

namespace WebApi.Controllers
{
    [Route("api/v1/mobile")]
    [ApiController]
    [Authorize]
    public class MobileAppController : BaseController
    {
        public MobileAppController(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig) : base(serviceProvider, appConfig)
        {
        }

        ShoppingCart setCartImageUrl(ShoppingCart cart)
        {
            if (cart == null || cart.Items == null)
                return cart;

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
            cart.Items.ForEach(o => o.ThumbImage = imageUrl + "Product/" + o.ThumbImage);
            return cart;
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

            var options = new ReadStoreOption
            {
                CategoryId = categoryId,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
            var query = service.ReadStores(options);

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

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
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
                BannerImageUrl= imageUrl+o.BannerImage,
                ImageUrl= imageUrl + o.Image
            }).ToList();

            return result;
        }

        [HttpPost("startCart/{storeId}")]
        public ShoppingCart StartCart(int storeId)
        {
            var cartService = CreateStoreService();
            var cart = cartService.StartShopping(storeId);
            return setCartImageUrl(cart);
        }

        [HttpGet("getCart")]
        public ShoppingCart GetCurrentCart()
        {
            var cartService = CreateStoreService();
            var cart = cartService.GetCart();
            return setCartImageUrl(cart);
        }

        [HttpPost("cart/add/{barCode}")]
        public ShoppingCart addToCart(string barCode)
        {
            var cartService = CreateStoreService();
            var cart = cartService.AddItemToCart(barCode);
            return setCartImageUrl(cart);
        }

        [HttpPost("cart/remove/{barCode}")]
        public ShoppingCart RemoveFromCart(string barCode)
        {
            var cartService = CreateStoreService();
            var cart = cartService.RemoveItemFromCart(barCode);
            return setCartImageUrl(cart);
        }

        [HttpPost("clearCart")]
        public void ClearCurrentCart()
        {
            var cartService = CreateStoreService();
            cartService.DiscardCart();
        }


        [HttpGet("views/home")]
        public HomeViewModel GetHomeViewModel()
        {
            var viewModel = new HomeViewModel();

            var cartService = CreateStoreService();
            viewModel.BannerUrls = new string[]
            {
                "https://image.shutterstock.com/image-vector/special-offer-grocery-store-advertisement-600w-1123205801.jpg",
                "https://image.shutterstock.com/z/stock-vector-special-offer-summer-sale-advertising-banner-label-with-icecream-design-element-and-typography-1469678345.jpg",
                "https://image.shutterstock.com/z/stock-vector-autumn-sale-retail-website-backdrop-banner-advertising-with-texture-of-coloured-leaves-on-backdrop-1481406671.jpg",
                "https://image.shutterstock.com/z/stock-vector-advertising-banner-with-fresh-vegetables-healthy-food-illustration-outlined-hand-drawn-graphic-1037031532.jpg"
            };
            var cart = cartService.GetCart();
            viewModel.Cart = setCartImageUrl(cart);
            viewModel.User = CurrentUser;
            viewModel.HasActiveCart = cart != null;
            return viewModel;
        }


        [HttpGet("Ver")]
        [AllowAnonymous]
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
                Version = "1.0.4",
                AppConfig=this.AppConfig
            };
        }
    }
}
