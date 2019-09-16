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
            cart.StoreImage = imageUrl + cart.StoreImage;
            cart.StoreBannerImage = imageUrl + cart.StoreBannerImage;
            cart.Items.ForEach(o => o.ThumbImage = imageUrl + "Product/" + o.ThumbImage);
            return cart;
        }
        [HttpGet("store/category")]
        public List<StoreCategoryItem> GetStoreCategories()
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

            //if (model.FilterBy != null)
            //{
            //    categoryId = model.FilterBy.CategoryId.HasValue ? model.FilterBy.CategoryId.Value : 0;
            //}
            var service = CreateStoreService();
            var cart = service.GetCart();

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


            if (cart != null)
            {
                result.HasActiveCart = true;
                result.ActiveStoreId = cart.StoreId;
            }

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
            var storeReviews = service.StoreReviews(stores.Select(o => o.Id).ToArray()).ToLookup(o => o.StoreId);
            result.StoreList = stores.Select(o => new StoreListViewModel.StoreListItem
            {
                StoreId = o.Id,
                StoreCode = o.Code,
                ShortName = o.ShortName,
                Description = o.Description,
                StoreName = o.Name,
                HasActiveCart = o.Id == result.ActiveStoreId,
                ReviewRating = storeReviews.Contains(o.Id) ? storeReviews[o.Id].FirstOrDefault() : new StoreReview { StoreId = o.Id },
                BannerImageUrl = imageUrl + o.BannerImage,
                ImageUrl = imageUrl + o.Image
            }).ToList();

            return result;
        }

        [HttpGet("store/{code}")]
        public StoreInfoViewModel GetStoreByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new BusinessException("Invalid code");

            var storeId = 0;
            int.TryParse(code, out storeId);

            var service = CreateStoreService();
            Store store = null;
          //  if (storeId > 0)
          //      store = service.GetStore(storeId);
          //  else
                store = service.GetStore(code);

            if (store==null)
                throw new BusinessException("Store not found for "+code);

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
            var storeReview = service.StoreReview(store.Id);

            var hasActiveCart = false;
            var cart = service.GetCart();

            if (cart != null && cart.StoreId == store.Id)
                hasActiveCart = true;

            var result = new StoreInfoViewModel()
            {
                StoreId = store.Id,
                StoreCode = store.Code,
                ShortName = store.ShortName,
                Description = store.Description,
                StoreName = store.Name,
                HasActiveCart = hasActiveCart,
                ReviewRating = storeReview!=null ? storeReview : new StoreReview { StoreId = store.Id },
                BannerImageUrl = imageUrl + store.BannerImage,
                ImageUrl = imageUrl + store.Image
            };

            return result;
        }

        [HttpPost("store/startShopping/{code}")]
        public StoreInfoViewModel StartShopping(string code)
        {
            var storeVm = GetStoreByCode(code);
            var service = CreateStoreService();
            service.StartShopping(storeVm.StoreId);
            storeVm.HasActiveCart = true;
            return storeVm;
        }


        [HttpGet("store/search/sort-options")]
        public List<ListItem> GetStoreSortList()
        {
            return new List<ListItem>
            {
                 new ListItem{Id=1,Name="Category"},
                 new ListItem{Id=2,Name="Distance"},
                 new ListItem{Id=3,Name="Rating"}
            };
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
            const string URL = "https://cdn0storage0shunq0dev.blob.core.windows.net/images/Promos/";
            var cartService = CreateStoreService();
            viewModel.BannerUrls = new string[]
            {
                URL+"Promo1.png",
                URL+"Promo2.jpg",
                URL+ "Promo3.jpg",
                URL+"Promo4.jpg"
            };
            viewModel.TileSections = new HomeViewModel.TileSection[]
            {
                new HomeViewModel.TileSection
                {
                    Title="Store By Category",
                    Tiles = new HomeViewModel.Tile[]
                  {
                      new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL+"Cat1.jpg",
                      },
                        new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL+"Cat2.jpg",
                      },
                          new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL+"Cat3.jpg",
                      },
                            new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL+"Cat4.jpg",
                      }
                  }
                }
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
                Version = "1.0.12",
                VersionDesc= "StoreBannerImage",
                AppConfig =this.AppConfig
            };
        }
    }
}
