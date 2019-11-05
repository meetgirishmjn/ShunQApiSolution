using BusinessCore.DataAccess.Contracts;
using BusinessCore.Enums;
using BusinessCore.Extensions;
using BusinessCore.Models;
using BusinessCore.Services.Contracts;
using BusinessCore.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Services
{
    public class StoreService : IStoreService, IDataContextable
    {
        public UserIdentity CurrentUser { get; set; }
        public IDataContextManager ContextManager { get; set; }

        #region "Private Methods"

        private ShoppingCartManager shoppingCart
        {
            get
            {
                return new ShoppingCartManager(CurrentUser.Id, this.ContextManager);
            }
        }
        //private static readonly Random rand = new Random((int)DateTime.Now.Ticks);

        private string getProductId(string productBarcode)
        {
            var code = productBarcode.TrimAll();
            var context = ContextManager.GetContext();
            var productId =context.ProductBarcodes.Where(o => o.Code == code).Select(o=>o.ProductMasterId).FirstOrDefault();

            return productId;
        }

        #endregion "Private Methods"
        public List<StoreCategoryItem> GetAllStoreCategory()
        {
            var context = ContextManager.GetContext();
            var lst = context.StoreCategoryXrefs.Select(o =>
                  new
                  {
                      Id = o.Category.Id,
                      Name = o.Category.Name,
                      StoreId = o.StoreMasterId
                  }).ToList(); ;

            var results = new List<StoreCategoryItem>();

            foreach (var grp in lst.GroupBy(o => o.Id))
            {
                var items = grp.ToArray();
                results.Add(new StoreCategoryItem
                {
                    Id = grp.Key,
                    Name = items[0].Name,
                    StoreCount = items.Count()
                });
            }
            return results;
        }

        public IQueryable<Store> ReadStores()
        {
            var context = ContextManager.GetContext();
            var query = context.StoreMasters.Where(o => o.IsActive).Select(o =>
                new Store
                {
                    Id = o.Id,
                    Code = o.Code,
                    Name = o.Name,
                    ShortName = o.ShortName,
                    Description = o.Description,
                    Image = o.Image,
                    BannerImage = o.BannerImage,
                    IsActive = o.IsActive,
                    Address = new Address
                    {
                        Id = o.Address.Id,
                        AddressLine = o.Address.AddressLine,
                        AddressLine2 = o.Address.AddressLine2,
                        City = o.Address.City,
                        Zip = o.Address.Zip,
                        Locality = o.Address.Locality,
                        Latitude = o.Address.Latitude,
                        Longitude = o.Address.Longitude,
                    }
                }
            );
            return query;
        }

        public IQueryable<Store> ReadStores(int categoryId)
        {
            return this.ReadStores();
        }
        public IQueryable<Store> ReadStores(StoreReadOption options)
        {
            return this.ReadStores();
        }

        public StoreReview StoreReview(int storeId)
        {
            var rand = new Random(storeId);
            var part1 = rand.Next(1, 6);
            var part2 = rand.Next(1, 10);
            return new StoreReview
            {
                StoreId = storeId,
                Value = float.Parse(part1 + "." + part2),
                VoteCount = rand.Next(1, 1000)
            };
        }

        public List<StoreReview> StoreReviews(int[] storeIds)
        {
            var results = new List<StoreReview>();

            foreach (var id in storeIds)
            {
                results.Add(StoreReview(id));
            }

            return results;
        }

        public ShoppingCart StartShopping(string cartDeviceId)
        {
            var cart = shoppingCart.CreateCart(cartDeviceId);
            return cart;
        }

        public ShoppingCart GetCart(string cartId)
        {
            var context = ContextManager.GetContext();
            var userId = context.ShoppingCarts.Where(o => o.Id == cartId).Select(o=>o.UserId).FirstOrDefault();
            var cart = new ShoppingCartManager(userId,ContextManager).GetCart();
            return cart;
        }
        public ShoppingCart GetCart(long userId)
        {
            var cart = new ShoppingCartManager(userId, ContextManager).GetCart();
            return cart;
        }
        public CartView GetCartView()
        {
            var status = (int)ShoppingCartStatus.InProgress;

            var context = ContextManager.GetContext();

            var objDb = context.ShoppingCarts.Include(o=>o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status)
                .Select(o => new
                {
                    ItemCount = o.Items.Count,
                    o.StoreId
                }).SingleOrDefault();

            if (objDb == null)
                return new CartView();

            return new CartView
            {
                HasActiveCart = true,
                CartItemCount = objDb.ItemCount,
                StoreId = objDb.StoreId
            };
        }
        public ShoppingCart GetCart()
        {
            var cart = shoppingCart.GetCart();
            return cart;
        }

        public ShoppingCart AddItemToCart(string productbarcode)
        {
            var productId = getProductId(productbarcode);

            if (string.IsNullOrEmpty(productId))
                throw new BusinessException("Invalid Product Bar-Code: " + productbarcode);

            var cart = shoppingCart.AddItemToCart(productId);
            return cart;
        }

        public ShoppingCart RemoveItemFromCart(string productbarcode)
        {
            var productId = getProductId(productbarcode);
            var cart = shoppingCart.RemoveItemFromCart(productId);
            return cart;
        }

        public  ShoppingCart AddVoucherToCart(string voucherCode)
        {
            var cart = shoppingCart.ApplyVoucher(voucherCode);
            return cart;
        }

        public ShoppingCart RemoveVoucherToCart(string voucherCode)
        {
            var cart = shoppingCart.RemoveVoucher(voucherCode);
            return cart;
        }

        public void DiscardCart()
        {
            shoppingCart.DiscardCart();
        }

        public Store GetStore(int id)
        {
            var result = ReadStores().Where(o => o.Id == id).FirstOrDefault();
            return result;
        }

        public Store GetStore(string qrCode)
        {
            var ids = ReadStores().Select(o => o.Id).ToArray();
            var result = GetStore(ids.First());
            return result;
        }

        public Store GetStoreByDeviceId(string cartDeviceId)
        {
            var context = ContextManager.GetContext();
            var storeId = context.CartDeviceMasters.Where(o => o.IsActive && o.CartDeviceId == cartDeviceId).Select(o => o.StoreMasterId).FirstOrDefault();
            var result = ReadStores().Where(o => o.Id == storeId).FirstOrDefault();
            return result;
        }

        private bool validateCartDeviceEventArg(CartDeviceEventArg arg)
        {

            arg.AppId = arg.AppId.TrimAll();
            arg.DeviceId = arg.DeviceId.TrimAll();
            arg.CartDeviceId = arg.CartDeviceId.TrimAll();
            arg.ProductId = arg.ProductId.TrimAll();

            if (arg.AppId.Length == 0)
                throw new BusinessException("App-Id is required.");

            if (arg.AppId != "App453Avr")
                throw new BusinessException("Invalid AppId: " + arg.AppId);

            if (arg.DeviceId.Length == 0)
                throw new BusinessException("Device-Id is required.");

            if (arg.CartDeviceId.Length == 0)
                throw new BusinessException("Cart-Id is required.");

            if (arg.ProductId.Length == 0)
                throw new BusinessException("Product-Id is required.");


            return true;

        }

        public async Task<CartDeviceEventArg> CartDeviceProductAddedAsync(CartDeviceEventArg arg)
        {
            var context = ContextManager.GetContext();
            validateCartDeviceEventArg(arg);

            var cartId = context.ShoppingCarts.Where(o => o.CartDeviceId == arg.CartDeviceId).Select(o => o.Id).FirstOrDefault();
         
            var id = Guid.NewGuid().ToString();
            var objDb = new DataAccess.DbModels.CartDeviceLog
            {
                Id = id,
                AppId = arg.AppId,
                DeviceId = arg.DeviceId,
                CartDeviceId = arg.CartDeviceId,
                ShoppingCartId= cartId,
                CartWeight = arg.CartWeight,
                ProductId = arg.ProductId,
                LogType = "ADD",
                CreatedOn = DateTime.Now,
                Data = arg.Data
            };

            context.CartDeviceLogs.Add(objDb);

            await context.SaveChangesAsync();

            arg.Id = objDb.Id;
            arg.LogType = objDb.LogType;
            arg.CreatedOn = objDb.CreatedOn;

            return arg;
        }

        public async Task<CartDeviceEventArg> CartDeviceProductRemovedAsync(CartDeviceEventArg arg)
        {
            var context = ContextManager.GetContext();
            validateCartDeviceEventArg(arg);

            var cartId = context.ShoppingCarts.Where(o => o.CartDeviceId == arg.CartDeviceId).Select(o => o.Id).FirstOrDefault();

            var id = Guid.NewGuid().ToString();
            var objDb = new DataAccess.DbModels.CartDeviceLog
            {
                Id = id,
                AppId = arg.AppId,
                DeviceId = arg.DeviceId,
                CartDeviceId = arg.CartDeviceId,
                ShoppingCartId= cartId,
                CartWeight = arg.CartWeight,
                ProductId = arg.ProductId,
                LogType = "REMOVE",
                CreatedOn = DateTime.Now,
                Data = arg.Data
            };

            context.CartDeviceLogs.Add(objDb);

            await context.SaveChangesAsync();

            arg.Id = objDb.Id;
            arg.LogType = objDb.LogType;
            arg.CreatedOn = objDb.CreatedOn;

            return arg;
        }

        public async Task<List<string>> ReadCartDeviceLogsAsync()
        {
            var context = ContextManager.GetContext();
             var lst = await context.CartDeviceLogs.OrderByDescending(o => o.CreatedOn).Take(100).Select(o => new
            {
                o.CartDeviceId,
                o.CartWeight,
                o.DeviceId,
                o.ShoppingCartId,
                o.LogType,
                o.ProductId,
                o.CreatedOn,
            }).ToListAsync();

            var results = new List<string>();
            lst.ForEach(o =>
            {
                results.Add($"Event:{o.LogType} | Device-Id:{o.DeviceId} | Cart-Device-Id:{o.CartDeviceId}| Shopping-Cart-Id:{o.ShoppingCartId} | Product-Id:{o.ProductId} | Cart-Weight:{o.CartWeight} |  Date-Time:{o.CreatedOn.ToLongDateString() }");
            });

            return results;
        }

        public async Task<List<string>> ReadCartDeviceLogsAsync(string cartDeviceId)
        {
            var context = ContextManager.GetContext();
            var lst = await context.CartDeviceLogs.Where(o=>o.DeviceId== cartDeviceId).OrderByDescending(o => o.CreatedOn).Select(o => new
            {
                o.CartDeviceId,
                o.CartWeight,
                o.DeviceId,
                o.ShoppingCartId,
                o.LogType,
                o.ProductId,
                o.CreatedOn,
            }).ToListAsync();

            var results = new List<string>();
            lst.ForEach(o =>
            {
                results.Add($"Event:{o.LogType} | Device-Id:{o.DeviceId} | Cart-Device-Id:{o.CartDeviceId}| Shopping-Cart-Id:{o.ShoppingCartId} | Product-Id:{o.ProductId} | Cart-Weight:{o.CartWeight} |  Date-Time:{o.CreatedOn.ToLongDateString() }");
            });

            return results;
        }

        public async Task<int> RemoveAllCartDeviceLogsAsync(string cartDeviceId)
        {
            var context = ContextManager.GetContext();
            var lst = await context.CartDeviceLogs.Where(o => o.CartDeviceId == cartDeviceId).ToListAsync();

            var count = lst.Count;
            context.RemoveRange(lst);
            context.SaveChanges();
            return count;
        }

        public CartValidationResult ValidateCart(string cartId)
        {
            var result = shoppingCart.ValidateCart(cartId);
            return result;
        }

        public CartValidationResult ValidateCart()
        {
            var status = (int)ShoppingCartStatus.InProgress;

            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("No active cart for user.");

                var cart = shoppingCart.GetCart();
            var result = shoppingCart.ValidateCart(cartId: objDb.Id);
            return result;
        }

        public CartVoucher CreateCartVoucher(CartVoucher voucher)
        {
            var context = ContextManager.GetContext();
            if (voucher.IsSuccess)
            {
                var cartDb = context.ShoppingCarts.Where(o => o.Id == voucher.CartId).FirstOrDefault();
                cartDb.Status = (int)ShoppingCartStatus.Completed;
            }

            var vouchDb = new DataAccess.DbModels.PaymentVoucherMaster()
            {
                CreatedOn = DateTime.Now,
                CartId = voucher.CartId,
                PaymentGatewayName = voucher.PaymentGatewayName,
                GatewayPaymentId = voucher.GatewayPaymentId,
                Status = voucher.Status,
                IsSuccess = voucher.IsSuccess,
                GatewayResponse = voucher.GatewayResponse,
                UserName = voucher.UserEmail,
                HashValidation=voucher.HashValidated
            };

            context.PaymentVoucherMasters.Add(vouchDb);
            context.SaveChanges();
            voucher.VoucherId = vouchDb.Id;
            voucher.CreatedOn = vouchDb.CreatedOn;

            return voucher;
        }

        public CartVoucher GetCartVoucher(string cartId)
        {
            var context = ContextManager.GetContext();
            var vouchDb = context.PaymentVoucherMasters.Where(o => o.CartId == cartId).OrderByDescending(o => o.CreatedOn).FirstOrDefault();
            if(vouchDb==null)
            return null;

            var result = new CartVoucher
            {
                VoucherId = vouchDb.Id,
                CartId = vouchDb.CartId,
                CreatedOn = vouchDb.CreatedOn,
                GatewayPaymentId = vouchDb.GatewayPaymentId,
                PaymentGatewayName = vouchDb.PaymentGatewayName,
                IsSuccess = vouchDb.IsSuccess,
                Status = vouchDb.Status,
                UserEmail = vouchDb.UserName
            };
            return result;
        }
    }
}
