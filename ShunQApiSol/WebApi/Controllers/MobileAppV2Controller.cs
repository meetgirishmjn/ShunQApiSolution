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

        [HttpGet("store/{code}")]
        public StoreInfoViewModel GetStoreByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new BusinessException("Invalid code");

            var storeId = 0;
            int.TryParse(code, out storeId);

            var service = CreateStoreService();
            var store = service.GetStore(code);

            if (store == null)
                throw new BusinessException("Store not found for " + code);

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
    }
}
