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
            cart.StoreImage = imageUrl +"stores/"+ cart.StoreImage;
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
            //result.SearchLocation = "Thanisandra main road - 560077";
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
                ImageUrl = imageUrl + "stores/" +  o.Image,
                Address = o.Address,
                
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
            var store = service.GetStore(code);

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
            var cartDeviceId = code;
            var service = CreateStoreService();

            //temp
            cartDeviceId = "temp";

            var cart  = service.StartShopping(cartDeviceId);
            var storeVm = GetStoreByCode(cart.StoreCode);

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
            throw new NotImplementedException("use store/startShopping/");
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

            var cart = cartService.GetCart();
            viewModel.Cart = setCartImageUrl(cart);
            viewModel.User = CurrentUser;
            viewModel.HasActiveCart = cart != null;
            return viewModel;
        }

        private CheckoutViewModel getCheckoutViewModel(ShoppingCart cart=null)
        {
            var viewModel = new CheckoutViewModel();
            
            viewModel.Currency = CurrencyRef.India;

            var cartService = CreateStoreService();
            cart = cart ?? cartService.GetCart();
            if (cart == null)
                throw new BusinessException("Cart does not exists.");
            if (cart.ItemCount == 0)
                throw new BusinessException("Cart is empty.");

            setCartImageUrl(cart);

            viewModel.CartId = cart.Id;
            viewModel.IsCartValid = true;
            viewModel.ValidationCaption = "Total " + cart.Items.Count + " Items verified.";
            viewModel.ValidationTitle = "Cart Validation";

            var lineItemGroups = cart.Items.GroupBy(o => o.ProductId);
            foreach (var grp in lineItemGroups)
            {
                var items = grp.ToList();
                viewModel.LineItems.Add(new CheckoutViewModel.LineItem
                {
                    Id = grp.Key,
                    ImageUrl = items[0].ThumbImage,
                    Amount = items.Sum(o => o.Price),
                    Quantity = items.Count,
                    Title = items[0].ProductName,
                    SubTitle = items[0].DiscountText,
                    MRP = items.Sum(o=>o.MRP),
                    HasDiscount = items[0].Discount > 0
                });
            }

            cart.Vouchers.ForEach(o =>
            {
                viewModel.AppliedVouchers.Add(new CheckoutViewModel.VoucherItem
                {
                    Amount = o.Amount,
                    Code = o.VoucherCode,
                    CodeDescription = o.Description,
                });
            });

            viewModel.TotalLineItem = cart.LineItemCount;
            viewModel.TotalItem = cart.ItemCount;
            viewModel.TotalAmount = cart.TotalAmount;
            viewModel.TotalDiscount = cart.TotalItemDiscount;
            viewModel.TotalVoucherDiscount = cart.TotalVoucherDiscount;
            viewModel.OrderTotal = cart.NetAmount;
            viewModel.AmountBeforeVoucherDiscount = cart.AmountBeforeVoucherDiscount;


            //cart validation
            var validationResult = cartService.ValidateCart(cart.Id);
            viewModel.IsCartValid = validationResult.IsValid;
            if (!viewModel.IsCartValid)
            {
                viewModel.ValidationCaption = "Cart is not valid. Please verify Cart Items with App Items";
                viewModel.ValidationMessages = validationResult.Messages;
            }

            return viewModel;
        }

        [HttpGet("views/checkout")]
        public CheckoutViewModel GetCheckoutViewModel()
        {
            var viewModel = getCheckoutViewModel();

            return viewModel;
        }

        [HttpPost("checkout/add/voucher/{code}")]
        public CheckoutViewModel ApplyCheckoutVoucher(string code)
        {
            var cartService = CreateStoreService();
            var cart = cartService.AddVoucherToCart(code);
            return getCheckoutViewModel(cart);
        }


        [HttpPost("checkout/remove/voucher/{code}")]
        public CheckoutViewModel RemoveCheckoutVoucher(string code)
        {
            var cartService = CreateStoreService();
            var cart = cartService.RemoveVoucherToCart(code);
            return getCheckoutViewModel(cart);
        }

        [HttpPost("views/searchStores")]
        public SearchStoresViewModel GetSearchStoresViewModel(StoreListModel model)
        {
            var viewModel = new SearchStoresViewModel();

            viewModel.SortOptions = GetStoreSortList();
            viewModel.StoreCategories = GetStoreCategories();
            viewModel.StoreSearchResult = SearchStores(model);

            return viewModel;
        }

       private void setImage(IEnumerable<OrderItem> items)
        {
            var imageUrl = this.AppConfig.ImageSrcEndpoint;
           foreach(var o in items)
                o.StoreImage = imageUrl + "stores/" + o.StoreImage;
        }

        [HttpPost("order/history")]
        public PagedItemResult<OrderItem> GetOrderHistory(PagedItemRead option)
        {
            var cartService = CreateStoreService();

            var result = cartService.ReadFinishedOrders(option);
            setImage(result.Items);
            return result;
        }

        [HttpPost("order/history/discarded")]
        public PagedItemResult<OrderItem> GetDiscardedOrderHistory(PagedItemRead option)
        {
            var cartService = CreateStoreService();

            var result = cartService.ReadDiscardedOrders(option);
            setImage(result.Items);

            return result;
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

            var cacheStatus = "";
            try
            {
               // Cache.Test();
               // cacheStatus = "ok";
            }
            catch (Exception ex)
            {
                cacheStatus = ex.Message + ex.InnerException?.Message;
            }

            return new VersionViewModel
            {
                DbStatus = dbStatus,
                CacheStatus= cacheStatus,
                Status = "ok",
                Version = "1.0.1",
                VersionDesc= "appV3",
                AppConfig =this.AppConfig 
                //OS=new
                //{
                //    OSArchitecture = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString(),
                //    System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                //    System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
                //}
            };
        }
    }
}
