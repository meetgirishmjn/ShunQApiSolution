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
        private ShoppingCart toModel(DataAccess.DbModels.ShoppingCart objDb)
        {
            if (objDb == null)
                return null;

            //temp
            var prodDescList = new string[]
            {
                "200 gram",
                "1 kg",
                "500 gram",
                "1 pc - 200 g - 1 kg",
                "1 box (12 pieces)",
                "1 dozen (12 qty)"
            };

            //temp
            var model = new ShoppingCart
            {
                Id = objDb.Id,
                StoreId = objDb.StoreId,
                UserId = objDb.UserId,
                Status = ((ShoppingCartStatus)objDb.Status).ToString()
            };
            if (objDb.Items != null)
            {
                var pids = objDb.Items.Select(o => o.ProductId).ToArray();
                var context = ContextManager.GetContext();
                var products = context.ProductMasters.Where(o => pids.Contains(o.Id)).ToLookup(o => o.Id);
                var prices = getProductPrices(pids);
                foreach (var dbItem in objDb.Items)
                {
                    var p = products.Contains(dbItem.ProductId) ? products[dbItem.ProductId].FirstOrDefault() : null;
                    var price = prices.FirstOrDefault(o => o.ProductId == dbItem.ProductId);

                    var pDescIndex = rand.Next(0, prodDescList.Length);
                    var pDesc = prodDescList[pDescIndex];

                    var item = new ShoppingCart.Item
                    {
                        ProductId = dbItem.ProductId,
                        Quantity = dbItem.Quantity,
                        SortOrder = dbItem.SortOrder
                    };

                    if (p != null)
                    {
                        item.ProductName = p.Name;
                        item.Description = pDesc;
                        item.ShortName = p.ShortName;
                        item.ThumbImage = p.ThumbImage;
                    }

                    if (price != null)
                    {
                        item.MRP = price.MRP;
                        item.Price = price.Price;
                        item.Discount = price.Discount;
                        item.DiscountText = price.DiscountText;
                    }
                    model.Items.Add(item);
                }
            }

            return model;
        }

        private static readonly Random rand = new Random();

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

        private DataAccess.DbModels.PriceMaster getProductPrice(string productId)
        {
            var paisa = rand.Next(1, 20) * 5;
            var mrp = rand.Next(10, 1000);
            var price = rand.Next(10, mrp);
            var disc = rand.Next(1, 11);

            return new DataAccess.DbModels.PriceMaster
            {
                ProductId = productId,
                MRP =(float) Math.Round( float.Parse(mrp + "." + paisa),2),
                Price = (float) Math.Round(float.Parse(price + "." + paisa),2),
                Discount = mrp - price,
                DiscountText = disc+"% Discount",
            };
        }
        private List<DataAccess.DbModels.PriceMaster> getProductPrices(string[] productIds)
        {
            var list = new List<DataAccess.DbModels.PriceMaster>();
            productIds.ToList().ForEach(o => list.Add(getProductPrice(o)));
            return list;
        }

        #endregion "Private Methods"
        public List<ListItem> GetAllStoreCategory()
        {
            return new List<ListItem>
            {
                new ListItem
                {
                    Id=1001,
                    Name="Departmental Stores"
                },
                 new ListItem
                {
                    Id=1002,
                    Name="Grocery"
                }, new ListItem
                {
                    Id=1003,
                    Name="Kid Care/Toys"
                }, new ListItem
                {
                    Id=1004,
                    Name="Stationery"
                }, new ListItem
                {
                    Id=1005,
                    Name="Electronics"
                }
            };
        }

        public IQueryable<Store> ReadStores()
        {
            var results = new List<Store>()
            {
                new Store
                {
                    Id = 1001,
                    Code = "STR-1",
                    Name = "AB Supermarket",
                    ShortName = "AB Supermarket",
                    Description = "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers",
                    Image = "STR-1-Thumb.jpg",
                    BannerImage = "STR-1-Banner.jpg",
                    Address = new Address { AddressLine = "No 12, Evergreen Layout, Byrathi, Near to RK Gowtham College",Locality="Evergreen Layout", City = "Bangalore", Zip = "560077", Id = 1, Latitude = "13.0581", Longitude = "77.6501" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1002,
                    Code = "STR-2",
                    Name = "Imperio Market",
                    ShortName = "Imperio Market",
                    Description = "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-2-Thumb.jpg",
                    BannerImage = "STR-2-Banner.jpg",
                    Address = new Address { AddressLine = "agadur Main Road, Whitefield, Near Bashveshwara Temple",Locality="Whitefield", City = "Bangalore", Zip = "560066", Id = 2, Latitude = "12.969769", Longitude = "77.755636" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1003,
                    Code = "STR-3",
                    Name = "The Big Market",
                    ShortName = "The Big Market",
                    Description = "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-3-Thumb.jpg",
                    BannerImage = "STR-3-Banner.jpg",
                    Address = new Address { AddressLine = "No 26, &26/2, Sarjapura Main Road, Attibele, Near Lakshmi Convention Hall ",Locality="Sarjapura Main Road", City = "Bangalore", Zip = "562107", Id = 3, Latitude = "12.786873", Longitude = "77.773229" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1004,
                    Code = "STR-4",
                    Name = "D Mart",
                    ShortName = "D Mart",
                    Description = "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.",
                    Image = "STR-4-Thumb.jpg",
                    BannerImage = "STR-4-Banner.jpg",
                    Address = new Address { AddressLine = "No.21, Flat No.112, Konappana Agrahara, Begur, Electronic City",Locality="Electronic City", City = "Bangalore", Zip = "560100", Id = 4, Latitude = "12.844235", Longitude = "77.674169" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1005,
                    Code = "STR-5",
                    Name = "Big Bazaar",
                    ShortName = "Big Bazaar",
                    Description = "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.",
                    Image = "STR-5-Thumb.jpg",
                    BannerImage = "STR-5-Banner.jpg",
                    Address = new Address { AddressLine = "Salapuria Gateway , 45, A Block, J.P. Nagar, 2Nd Stage, Ward No - 57, 9Th Block, Near Ragiguddu, Kottapalya, Jayanagar",Locality="Jayanagar", City = "Bangalore", Zip = "560041", Id = 5, Latitude = "12.917188", Longitude = "77.592353" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1006,
                    Code = "STR-6",
                    Name = "Metro Cash And Carry",
                    ShortName = "Metro Cash And Carry",
                    Description = "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.",
                    Image = "STR-6-Thumb.jpg",
                    BannerImage = "STR-6-Banner.jpg",
                    Address = new Address { AddressLine = "Mango Garden Layout, Bikasipura, JP Nagar",Locality="JP Nagar", City = "Bangalore", Zip = "560078", Id = 6, Latitude = "12.893121", Longitude = "77.565897" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1007,
                    Code = "STR-7",
                    Name = "Village Hyper Market",
                    ShortName = "Village Hyper Market",
                    Description = "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.",
                    Image = "STR-7-Thumb.jpg",
                    BannerImage = "STR-7-Banner.jpg",
                    Address = new Address { AddressLine = "No 1381/100/93, Neeladri Nagar, Phase 1, Electronic City",Locality="Electronic City", City = "Bangalore", Zip = "560100", Id = 7, Latitude = "12.841791", Longitude = "77.646292" },
                    IsActive = true
                },
                new Store
                {
                    Id = 1008,
                    Code = "STR-8",
                    Name = "Star Bazaar",
                    ShortName = "Star Bazaar",
                    Description = "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-8-Thumb.jpg",
                    BannerImage = "STR-8-Banner.jpg",
                    Address = new Address { AddressLine = "30/1, Main Rd, Koramangala 7Th Block, Koramangala, Chikku Lakshmaiah Layout, Adugodi",Locality="Adugodi", City = "Bangalore", Zip = "560029", Id = 8, Latitude = "12.936745", Longitude = "77.610425" },
                    IsActive = true
                }
        };
            return results.AsQueryable();
        }

        public IQueryable<Store> ReadStores(int categoryId)
        {
            return this.ReadStores();
        }
        public IQueryable<Store> ReadStores(ReadStoreOption options)
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
            var context = ContextManager.GetContext();
            var status = (int)ShoppingCartStatus.InProgress;

            var storeExists = ReadStores().Where(o => o.Id == storeId).Any();
            if (!storeExists)
                throw new ApplicationException("Invalid Store-Id.");

            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            if (objDb != null)
                throw new ApplicationException("Finish Shopping or Clear Current Cart.");

            objDb = new DataAccess.DbModels.ShoppingCart()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = CurrentUser.CompanyId,
                CreatedOn = DateTime.Now,
                Status = (int)ShoppingCartStatus.InProgress,
                StoreId = storeId,
                UserId = CurrentUser.Id
            };
            context.ShoppingCarts.Add(objDb);
            context.SaveChanges();

            return toModel(objDb);
        }

        public ShoppingCart GetCart(string cartId)
        {
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.Id == cartId).FirstOrDefault();
            return toModel(objDb);
        }

        public ShoppingCart GetCart()
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            return toModel(objDb);
        }

        public ShoppingCart AddItemToCart(string productbarcode)
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var productId = getProductId(productbarcode);
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            var max = 0;
            if (objDb.Items.Any())
                max = objDb.Items.Max(o => o.SortOrder);

            objDb.Items.Add(new DataAccess.DbModels.ShoppingCartItem
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = productId,
                Quantity = 1,
                SortOrder = max + 1
            });

            context.SaveChanges();

            return toModel(objDb);
        }

        public ShoppingCart RemoveItemFromCart(string productbarcode)
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var productId = getProductId(productbarcode);
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            if (objDb.Items == null || objDb.Items.Count==0)
                throw new BusinessException("Shopping-cart is empty");

            //var itemDb = objDb.Items.Where(o => o.ProductId == productId).OrderByDescending(o => o.SortOrder).FirstOrDefault();

            //temp
            var index = rand.Next(0, objDb.Items.Count);
            var itemDb = objDb.Items.ToList()[index];
            //temp

            objDb.Items.Remove(itemDb);

            context.SaveChanges();

            return toModel(objDb);
        }

        public void DiscardCart()
        {
            var status = (int)ShoppingCartStatus.InProgress;
            var context = ContextManager.GetContext();
            var objDb = context.ShoppingCarts.Include(o => o.Items).Where(o => o.UserId == CurrentUser.Id && o.Status == status).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("Shopping-cart does not exist");

            objDb.Status = (int)ShoppingCartStatus.Discarded;

            context.SaveChanges();
        }

        
    }
}
