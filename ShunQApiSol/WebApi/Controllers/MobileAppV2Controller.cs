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
using BusinessCore.AppHandlers;

namespace WebApi.Controllers
{
    [Route("api/v2/mobile")]
    [ApiController]
    [Authorize]
    public class MobileAppV2Controller : BaseController
    {
        public MobileAppV2Controller(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig) : base(serviceProvider, appConfig)
        {
        }

        ShoppingCart setCartImageUrl(ShoppingCart cart)
        {
            if (cart == null || cart.Items == null)
                return cart;

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
            cart.StoreImage = imageUrl + "stores/" + cart.StoreImage;
            cart.StoreBannerImage = imageUrl + "stores/" + cart.StoreBannerImage;
            cart.Items.ForEach(o => o.ThumbImage = imageUrl + "products/" + o.ThumbImage);
            return cart;
        }

        [HttpGet("store/category")]
        public List<StoreCategoryItem> GetStoreCategories()
        {
            var service = CreateStoreService();
            var results = service.GetAllStoreCategory();

            return results;
        }

        [HttpGet("app/view")]
        public AppViewModel GetAppViewModel()
        {
            var service = CreateStoreService();
            var cart = service.GetCartView();
            var viewModel = new AppViewModel
            {
                UserName = CurrentUser.Name,
                FullName = CurrentUser.FullName,
                HasActiveCart = cart.HasActiveCart,
                CartItemCount = cart.CartItemCount
            };
            return viewModel;
        }

        [HttpGet("views/home")]
        public HomeViewModel2 GetHomeViewModel()
        {
            var viewModel = new HomeViewModel2();
            const string URL = "https://cdn0storage0shunq0dev.blob.core.windows.net/images/app/";
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
                          ImageUrl = URL + "category/" + "vegetables.jpg",
                      },
                        new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL + "category/" + "Biscuits.jpg",
                      },
                          new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL + "category/" + "Crockery.jpg",
                      },
                            new HomeViewModel.Tile
                      {
                          Title="",
                          ImageUrl = URL + "category/" + "Fruits.jpg",
                      }
                  }
                }
            };

            var cart = cartService.GetCartView();
            viewModel.AppView = new AppViewModel
            {
                UserName = CurrentUser.Name,
                FullName = CurrentUser.FullName,
                CartItemCount = cart.CartItemCount,
                HasActiveCart = cart.HasActiveCart
            };

            return viewModel;
        }

        [HttpPost("store/startShopping/{code}")]
        public StoreInfoViewModel StartShopping(string code)
        {
            var cartDeviceId = code;
            var service = CreateStoreService();

            //temp
            cartDeviceId = "temp";

            var cart = service.StartShopping(cartDeviceId);
            var storeVm = GetStoreByCode(cart.StoreCode);

            storeVm.HasActiveCart = true;

            storeVm.AppView = new AppViewModel
            {
                UserName = CurrentUser.Name,
                FullName = CurrentUser.FullName,
                CartItemCount = cart.ItemCount,
                HasActiveCart = storeVm.HasActiveCart
            };

            return storeVm;
        }

        [HttpGet("active/store")]
        public StoreInfoViewModel GetActiveStore()
        {
            var service = CreateStoreService();


            var cart = service.GetCartView();
            var storeVm = getStoreById(cart.StoreId);

            storeVm.HasActiveCart = storeVm.HasActiveCart;

            storeVm.AppView = new AppViewModel
            {
                UserName = CurrentUser.Name,
                FullName = CurrentUser.FullName,
                CartItemCount = cart.CartItemCount,
                HasActiveCart = storeVm.HasActiveCart
            };

            return storeVm;
        }

        [HttpGet("store/{code}")]
        public StoreInfoViewModel GetStoreByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new BusinessException("Invalid code");

            int.TryParse(code, out int storeId);

            var result = getStoreById(storeId);

            return result;
        }

        private StoreInfoViewModel getStoreById(int storeId)
        {
            var service = CreateStoreService();
            var store = service.GetStore(storeId);

            if (store == null)
                throw new BusinessException("Store not found for " + storeId);

            var imageUrl = this.AppConfig.ImageSrcEndpoint;
            // var storeReview = service.StoreReview(store.Id);

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
                //ReviewRating = storeReview != null ? storeReview : new StoreReview { StoreId = store.Id },
                ReviewRating = new StoreReview { StoreId = store.Id },
                BannerImageUrl = imageUrl + "stores/" + store.BannerImage,
                ImageUrl = imageUrl + "stores/" + store.Image
            };

            return result;
        }

        [HttpPost("cart/add/{barCode}")]
        public AppViewModel addToCart(string barCode)
        {
            var cartService = CreateStoreService();
            var cart = cartService.AddItemToCart(barCode);
            var result = new AppViewModel
            {
                CartItemCount = cart.ItemCount,
                HasActiveCart = true,
                FullName = CurrentUser.FullName,
                UserName = CurrentUser.Name
            };

            return result;
        }

        [HttpPost("cart/remove/{barCode}")]
        public AppViewModel RemoveFromCart(string barCode)
        {
            var cartService = CreateStoreService();
            var cart = cartService.RemoveItemFromCart(barCode);
            var result = new AppViewModel
            {
                CartItemCount = cart.ItemCount,
                HasActiveCart = true,
                FullName = CurrentUser.FullName,
                UserName = CurrentUser.Name
            };

            return result;
        }

        [HttpGet("current/cart")]
        public ShoppingCart GetCurrentCart()
        {
            var cartService = CreateStoreService();
            var cart = cartService.GetCart();
            cart = setCartImageUrl(cart);

            cart.UserName = CurrentUser.Name;
            cart.FullName = CurrentUser.FullName;

            return cart;
        }

        [HttpPost("store/search")]
        public StoreListViewModel SearchStores(StoreListModel model)
        {
            var result = new StoreListViewModel();

            var categoryId = 0;

            model.PageIndex = model.PageIndex <= 0 ? 1 : model.PageIndex;
            model.PageSize = model.PageSize <= 0 ? 1 : model.PageSize;

            //if (model.FilterBy != null)
            //{
            //    categoryId = model.FilterBy.CategoryId.HasValue ? model.FilterBy.CategoryId.Value : 0;
            //}
            var service = CreateStoreService();
            var cart = service.GetCart();

            var options = new StoreReadOption
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
            result.PageCount = (int)Math.Ceiling((double)totalCount / model.PageSize);
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
                BannerImageUrl = imageUrl + "stores/" + o.BannerImage,
                ImageUrl = imageUrl + "stores/" + o.Image,
                Address = new Address
                {
                    AddressLine = "Survey No. 132(P) wide Thanisandra main road",
                    AddressLine2 = " 5th Block, MS Ramaiah North City",
                    City = "Bengaluru",
                    Locality = "Thanisandra main road",
                    Zip = "560077",
                    Latitude = "13.046126",
                    Longitude = "77.626621"
                }
            }).ToList();

            return result;
        }

    }
}
