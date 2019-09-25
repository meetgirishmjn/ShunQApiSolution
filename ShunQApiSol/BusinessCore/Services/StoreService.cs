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
        private static readonly Random rand = new Random((int)DateTime.Now.Ticks);

        private string getProductId(string productBarcode)
        {
            var code = productBarcode.TrimAll();
            var context = ContextManager.GetContext();
            //  var productId =context.ProductBarcodes.Where(o => o.Code == code).Select(o=>o.ProductMasterId).FirstOrDefault();

            //temp
            var ids = context.ProductMasters.Select(o => o.Id).ToArray();
            var productId = rand.Next(1, ids.Length);
            //temp

            return productId + "";
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

        public ShoppingCart StartShopping(int storeId)
        {
            var cart = shoppingCart.CreateCart(storeId);
            return cart;
        }

        public ShoppingCart GetCart(string cartId)
        {
            var context = ContextManager.GetContext();
            var userId = context.ShoppingCarts.Where(o => o.Id == cartId).Select(o=>o.UserId).FirstOrDefault();
            var cart = new ShoppingCartManager(userId,ContextManager).GetCart();
            return cart;
        }

        public ShoppingCart GetCart()
        {
            var cart = shoppingCart.GetCart();
            return cart;
        }

        public ShoppingCart AddItemToCart(string productbarcode)
        {
            var productId = getProductId(productbarcode);
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
            var index =rand.Next(0, ids.Length);
            var result = GetStore(ids[index]);
            return result;
        }
    }
}
