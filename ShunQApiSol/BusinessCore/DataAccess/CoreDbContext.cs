using BusinessCore.DataAccess.DbModels;
using BusinessCore.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessCore.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        { }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<LogInSession> LogInSessions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<AddressMaster> AddressMasters { get; set; }
        public DbSet<PriceMaster> PriceMasters { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }
        public DbSet<StoreMaster> StoreMasters { get; set; }
        public DbSet<StoreCategoryXref> StoreCategoryXrefs { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ProductCategoryXref> ProductCategoryXrefs { get; set; }
        public DbSet<UserMasterOAuth> UserMasterOAuths { get; set; }
        public DbSet<OTPCode> OTPCodes { get; set; }
        public DbSet<CartVoucher> CartVouchers { get; set; }
        public DbSet<DiscountVoucherMaster> DiscountVoucherMasters { get; set; }
        public DbSet<CartDeviceLog> CartDeviceLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceMaster>().HasIndex(o => o.ProductId);
           // modelBuilder.Entity<AddressMaster>().HasMany(o => o.Stores).WithOne(o=>o.Address).IsRequired(); 

            modelBuilder.Entity<RoleMaster>()
       .HasData(
           new RoleMaster
           {
               Id = (int)RoleNames.Administrator,
               Name = RoleNames.Administrator.ToString(),
               CompanyId=1,
               Description=string.Empty
           },
           new RoleMaster
           {
               Id = (int)RoleNames.User,
               Name = RoleNames.User.ToString(),
               CompanyId = 1,
               Description = string.Empty
           }
       );

            modelBuilder.Entity<UserMaster>()
      .HasData(
          new UserMaster
          {
              Id = 1,
              Name = AppConfig.ADMIN_USER_NAME,
              CompanyId = 1,
              CreatedBy = 1,
              CreatedOn = DateTime.Now,
              Email = "meetgirish.mjn@gmail.com",
              EmailVerified = true,
              FirstName = "Girish",
              FullName = "Girish Mahajan",
              Gender = "M",
              ImageId = string.Empty,
              IsActive = true,
              IsDeleted = false,
              LastName = " Mahajan",
              MobileNumber = "8871384762",
              MobileVerified = true,
              Password = "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=",//admin@mjngrs
              Props = string.Empty
          });

            modelBuilder.Entity<UserRole>()
     .HasData(
         new UserRole
         {
             Id = 1,
             RoleMasterId= (int)RoleNames.Administrator,
             UserMasterId=1,
             CompanyId=1,
             UpdatedOn=DateTime.Now,
             UpdatedBy=1,
             CreatedBy=1,
             CreatedOn=DateTime.Now,
             IsActive=true
         });

            #region "StoreData"
            var addressData = new List<AddressMaster>();
            addressData.Add(new AddressMaster { Id = 1001, AddressLine = "No 12, Evergreen Layout, Byrathi, Near to RK Gowtham College", Locality = "Evergreen Layout", City = "Bangalore", Zip = "560077", Latitude = "13.0581", Longitude = "77.6501" });
            addressData.Add(new AddressMaster { Id = 1002, AddressLine = "agadur Main Road, Whitefield, Near Bashveshwara Temple", Locality = "Whitefield", City = "Bangalore", Zip = "560066", Latitude = "12.969769", Longitude = "77.755636" });
            addressData.Add(new AddressMaster { Id = 1003, AddressLine = "No 26, &26/2, Sarjapura Main Road, Attibele, Near Lakshmi Convention Hall ", Locality = "Sarjapura Main Road", City = "Bangalore", Zip = "562107", Latitude = "12.786873", Longitude = "77.773229" });
            addressData.Add(new AddressMaster { Id = 1004, AddressLine = "No.21, Flat No.112, Konappana Agrahara, Begur, Electronic City", Locality = "Electronic City", City = "Bangalore", Zip = "560100", Latitude = "12.844235", Longitude = "77.674169" });
            addressData.Add(new AddressMaster { Id = 1005, AddressLine = "Salapuria Gateway , 45, A Block, J.P. Nagar, 2Nd Stage, Ward No - 57, 9Th Block, Near Ragiguddu, Kottapalya, Jayanagar", Locality = "Jayanagar", City = "Bangalore", Zip = "560041", Latitude = "12.917188", Longitude = "77.592353" });
            addressData.Add(new AddressMaster { Id = 1006, AddressLine = "Mango Garden Layout, Bikasipura, JP Nagar", Locality = "JP Nagar", City = "Bangalore", Zip = "560078", Latitude = "12.893121", Longitude = "77.565897" });
            addressData.Add(new AddressMaster { Id = 1007, AddressLine = "No 1381/100/93, Neeladri Nagar, Phase 1, Electronic City", Locality = "Electronic City", City = "Bangalore", Zip = "560100", Latitude = "12.841791", Longitude = "77.646292" });
            addressData.Add(new AddressMaster { Id = 1008, AddressLine = "30/1, Main Rd, Koramangala 7Th Block, Koramangala, Chikku Lakshmaiah Layout, Adugodi", Locality = "Adugodi", City = "Bangalore", Zip = "560029", Latitude = "12.936745", Longitude = "77.610425" });
           
            modelBuilder.Entity<AddressMaster>().HasData(addressData);

            modelBuilder.Entity<StoreCategory>().HasData(new List<StoreCategory>()
            {
                new  StoreCategory{Id=1001,Name="Departmental Stores",Description=string.Empty,CompanyId=1,CreatedBy=1,CreatedOn=DateTime.Now},
                new  StoreCategory{Id=1002,Name="Grocery",Description=string.Empty,CompanyId=1,CreatedBy=1,CreatedOn=DateTime.Now,},
                new  StoreCategory{Id=1003,Name="Kid Care/Toys",Description=string.Empty,CompanyId=1,CreatedBy=1,CreatedOn=DateTime.Now,},
                new  StoreCategory{Id=1004,Name="Stationery",Description=string.Empty,CompanyId=1,CreatedBy=1,CreatedOn=DateTime.Now,},
                new  StoreCategory{Id=1005,Name="Electronics",Description=string.Empty,CompanyId=1,CreatedBy=1,CreatedOn=DateTime.Now,}
            });

            var storeData = new List<StoreMaster>()
            {
                new StoreMaster
                {
                    Id = 1001,
                    Code = "STR-1",
                    Name = "AB Supermarket",
                    ShortName = "AB Supermarket",
                    Description = "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers",
                    Image = "STR-1-Thumb.jpg",
                    BannerImage = "STR-1-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1002,
                    Code = "STR-2",
                    Name = "Imperio Market",
                    ShortName = "Imperio Market",
                    Description = "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-2-Thumb.jpg",
                    BannerImage = "STR-2-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1003,
                    Code = "STR-3",
                    Name = "The Big Market",
                    ShortName = "The Big Market",
                    Description = "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-3-Thumb.jpg",
                    BannerImage = "STR-3-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1004,
                    Code = "STR-4",
                    Name = "D Mart",
                    ShortName = "D Mart",
                    Description = "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.",
                    Image = "STR-4-Thumb.jpg",
                    BannerImage = "STR-4-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1005,
                    Code = "STR-5",
                    Name = "Big Bazaar",
                    ShortName = "Big Bazaar",
                    Description = "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.",
                    Image = "STR-5-Thumb.jpg",
                    BannerImage = "STR-5-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1006,
                    Code = "STR-6",
                    Name = "Metro Cash And Carry",
                    ShortName = "Metro Cash And Carry",
                    Description = "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.",
                    Image = "STR-6-Thumb.jpg",
                    BannerImage = "STR-6-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1007,
                    Code = "STR-7",
                    Name = "Village Hyper Market",
                    ShortName = "Village Hyper Market",
                    Description = "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.",
                    Image = "STR-7-Thumb.jpg",
                    BannerImage = "STR-7-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                },
                new StoreMaster
                {
                    Id = 1008,
                    Code = "STR-8",
                    Name = "Star Bazaar",
                    ShortName = "Star Bazaar",
                    Description = "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.",
                    Image = "STR-8-Thumb.jpg",
                    BannerImage = "STR-8-Banner.jpg",
                    IsActive = true,
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1
                }
        };

            for (var a = 0; a < storeData.Count; a++)
            {
                storeData[a].AddressId = addressData[a].Id;
            }
            modelBuilder.Entity<StoreMaster>().HasData(storeData);

            modelBuilder.Entity<StoreCategoryXref>().HasData(new List<StoreCategoryXref>()
            {
                new StoreCategoryXref{Id=1001,StoreCategoryId=1001,StoreMasterId=1001 },
                new StoreCategoryXref{Id=1002,StoreCategoryId=1001,StoreMasterId=1002 },
                new StoreCategoryXref{Id=1003,StoreCategoryId=1001,StoreMasterId=1003 },

                new StoreCategoryXref{Id=1004,StoreCategoryId=1002,StoreMasterId=1001 },
                new StoreCategoryXref{Id=1005,StoreCategoryId=1002,StoreMasterId=1005 },
                new StoreCategoryXref{Id=1006,StoreCategoryId=1002,StoreMasterId=1007 },

                new StoreCategoryXref{Id=1007,StoreCategoryId=1003,StoreMasterId=1001 },
                new StoreCategoryXref{Id=1008,StoreCategoryId=1003,StoreMasterId=1002 },
                new StoreCategoryXref{Id=1009,StoreCategoryId=1003,StoreMasterId=1003 },
                new StoreCategoryXref{Id=1010,StoreCategoryId=1003,StoreMasterId=1004 },
                new StoreCategoryXref{Id=1011,StoreCategoryId=1003,StoreMasterId=1005 },
                new StoreCategoryXref{Id=1012,StoreCategoryId=1003,StoreMasterId=1006 },

                new StoreCategoryXref{Id=1013,StoreCategoryId=1004,StoreMasterId=1006 },
                new StoreCategoryXref{Id=1014,StoreCategoryId=1004,StoreMasterId=1007 },
                new StoreCategoryXref{Id=1015,StoreCategoryId=1004,StoreMasterId=1008},
                                                                  
                new StoreCategoryXref{Id=1016,StoreCategoryId=1005,StoreMasterId=1001 },
                new StoreCategoryXref{Id=1017,StoreCategoryId=1005,StoreMasterId=1002 },
                new StoreCategoryXref{Id=1018,StoreCategoryId=1005,StoreMasterId=1003 },
                new StoreCategoryXref{Id=1019,StoreCategoryId=1005,StoreMasterId=1004 },
                new StoreCategoryXref{Id=1020,StoreCategoryId=1005,StoreMasterId=1005 },
                new StoreCategoryXref{Id=1021,StoreCategoryId=1005,StoreMasterId=1006 },
                new StoreCategoryXref{Id=1022,StoreCategoryId=1005,StoreMasterId=1007 },
                new StoreCategoryXref{Id=1023,StoreCategoryId=1005,StoreMasterId=1008 }
            });
            #endregion

            #region "ProductCategory"
            var kProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<kProduct>>(ProductJson);

            var kCats = kProducts.Select(o => o.Category).ToLookup(o => o.CategoryID);
            var ProductCategoryList = kCats.Select(o => new ProductCategory
            {
                Id = o.First().CategoryID,
                Name = o.First().CategoryName,
                Description = o.First().Description,
                CompanyId = 1,
                CreatedBy = 1,
                CreatedOn = DateTime.Now
            }).ToList();

            modelBuilder.Entity<ProductCategory>().HasData(ProductCategoryList);
            #endregion "ProductCategory"

            #region "ProductMaster"
            var productList = new List<ProductMaster>();
            var productCategoryXrefs = new List<ProductCategoryXref>();
            var categoryLookup = ProductCategoryList.ToLookup(o => o.Id);
            foreach(var kp in kProducts)
            {
                var product = new ProductMaster
                {
                    Id = kp.ProductID.ToString(),
                    Name = kp.ProductName,
                    ThumbImage = kp.ProductID + ".jpg",
                    BannerImage = kp.ProductID + ".jpg",
                    Code = kp.ProductID.ToString(),
                    CompanyId=1,
                    CreatedOn=DateTime.Now,
                    CreatedBy=1,
                    Description=string.Empty,
                    IsActive=true,
                    ShortName=string.Empty
                };
                productCategoryXrefs.Add(new ProductCategoryXref
                {
                    Id= productCategoryXrefs.Count+1,
                    ProductCategoryId = kp.CategoryID,
                    ProductMasterId = kp.ProductID.ToString(),
                });
                productList.Add(product);
            }
            modelBuilder.Entity<ProductMaster>().HasData(productList);
            modelBuilder.Entity<ProductCategoryXref>().HasData(productCategoryXrefs);
            #endregion "ProductMaster"

            #region "PriceMaster"
            var rand = new Random();
            var priceList = new List<PriceMaster>();
            productList.ForEach(o =>
            {
                var paisa = rand.Next(1, 20) * 5;
                var mrp = rand.Next(10, 1000);
                var price = rand.Next(10, mrp);
                var disc = rand.Next(1, 11);

                priceList.Add(new PriceMaster
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId=o.Id,
                    MRP = (float)Math.Round(float.Parse(mrp + "." + paisa), 2),
                    Price = (float)Math.Round(float.Parse(price + "." + paisa), 2),
                    Discount = (float)Math.Round(float.Parse((mrp - price).ToString()), 2),
                    DiscountText = disc + "% Discount",
                    CompanyId = 1,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1,
                    IsActive = true
                });
            });
            modelBuilder.Entity<PriceMaster>().HasData(priceList);
            #endregion "PriceMaster"

            var vouchers = new List<DiscountVoucherMaster>() {
                new DiscountVoucherMaster { Id = Guid.NewGuid().ToString(), Code = "BBVISA200", Title = "Rs.200 off", Description = "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800" },
                new DiscountVoucherMaster { Id = Guid.NewGuid().ToString(), Code = "DIP20", Title = " Flat 20% Off", Description = "Festival fever – On Order Of Rs.800 & Above" },
                new DiscountVoucherMaster { Id = Guid.NewGuid().ToString(), Code = "ICICIGTSEP", Title = "10% off", Description = "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500" },
            };
            modelBuilder.Entity<DiscountVoucherMaster>().HasData(vouchers);

            base.OnModelCreating(modelBuilder);
        }

        #region ProductJson
        string ProductJson = "[{\"ProductID\":1,\"ProductName\":\"Chai\",\"SupplierID\":1,\"CategoryID\":1,\"QuantityPerUnit\":\"10 boxes x 20 bags\",\"UnitPrice\":18,\"UnitsInStock\":39,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":2,\"ProductName\":\"Chang\",\"SupplierID\":1,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 12 oz bottles\",\"UnitPrice\":19,\"UnitsInStock\":17,\"UnitsOnOrder\":40,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":3,\"ProductName\":\"Aniseed Syrup\",\"SupplierID\":1,\"CategoryID\":2,\"QuantityPerUnit\":\"12 - 550 ml bottles\",\"UnitPrice\":10,\"UnitsInStock\":13,\"UnitsOnOrder\":70,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":4,\"ProductName\":\"Chef Anton's Cajun Seasoning\",\"SupplierID\":2,\"CategoryID\":2,\"QuantityPerUnit\":\"48 - 6 oz jars\",\"UnitPrice\":22,\"UnitsInStock\":53,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":5,\"ProductName\":\"Chef Anton's Gumbo Mix\",\"SupplierID\":2,\"CategoryID\":2,\"QuantityPerUnit\":\"36 boxes\",\"UnitPrice\":21.35,\"UnitsInStock\":0,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":6,\"ProductName\":\"Grandma's Boysenberry Spread\",\"SupplierID\":3,\"CategoryID\":2,\"QuantityPerUnit\":\"12 - 8 oz jars\",\"UnitPrice\":25,\"UnitsInStock\":120,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":7,\"ProductName\":\"Uncle Bob's Organic Dried Pears\",\"SupplierID\":3,\"CategoryID\":7,\"QuantityPerUnit\":\"12 - 1 lb pkgs.\",\"UnitPrice\":30,\"UnitsInStock\":15,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":7,\"CategoryName\":\"Produce\",\"Description\":\"Dried fruit and bean curd\"}},{\"ProductID\":8,\"ProductName\":\"Northwoods Cranberry Sauce\",\"SupplierID\":3,\"CategoryID\":2,\"QuantityPerUnit\":\"12 - 12 oz jars\",\"UnitPrice\":40,\"UnitsInStock\":6,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":9,\"ProductName\":\"Mishi Kobe Niku\",\"SupplierID\":4,\"CategoryID\":6,\"QuantityPerUnit\":\"18 - 500 g pkgs.\",\"UnitPrice\":97,\"UnitsInStock\":29,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":10,\"ProductName\":\"Ikura\",\"SupplierID\":4,\"CategoryID\":8,\"QuantityPerUnit\":\"12 - 200 ml jars\",\"UnitPrice\":31,\"UnitsInStock\":31,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":11,\"ProductName\":\"Queso Cabrales\",\"SupplierID\":5,\"CategoryID\":4,\"QuantityPerUnit\":\"1 kg pkg.\",\"UnitPrice\":21,\"UnitsInStock\":22,\"UnitsOnOrder\":30,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":12,\"ProductName\":\"Queso Manchego La Pastora\",\"SupplierID\":5,\"CategoryID\":4,\"QuantityPerUnit\":\"10 - 500 g pkgs.\",\"UnitPrice\":38,\"UnitsInStock\":86,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":13,\"ProductName\":\"Konbu\",\"SupplierID\":6,\"CategoryID\":8,\"QuantityPerUnit\":\"2 kg box\",\"UnitPrice\":6,\"UnitsInStock\":24,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":14,\"ProductName\":\"Tofu\",\"SupplierID\":6,\"CategoryID\":7,\"QuantityPerUnit\":\"40 - 100 g pkgs.\",\"UnitPrice\":23.25,\"UnitsInStock\":35,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":7,\"CategoryName\":\"Produce\",\"Description\":\"Dried fruit and bean curd\"}},{\"ProductID\":15,\"ProductName\":\"Genen Shouyu\",\"SupplierID\":6,\"CategoryID\":2,\"QuantityPerUnit\":\"24 - 250 ml bottles\",\"UnitPrice\":15.5,\"UnitsInStock\":39,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":16,\"ProductName\":\"Pavlova\",\"SupplierID\":7,\"CategoryID\":3,\"QuantityPerUnit\":\"32 - 500 g boxes\",\"UnitPrice\":17.45,\"UnitsInStock\":29,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":17,\"ProductName\":\"Alice Mutton\",\"SupplierID\":7,\"CategoryID\":6,\"QuantityPerUnit\":\"20 - 1 kg tins\",\"UnitPrice\":39,\"UnitsInStock\":0,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":18,\"ProductName\":\"Carnarvon Tigers\",\"SupplierID\":7,\"CategoryID\":8,\"QuantityPerUnit\":\"16 kg pkg.\",\"UnitPrice\":62.5,\"UnitsInStock\":42,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":19,\"ProductName\":\"Teatime Chocolate Biscuits\",\"SupplierID\":8,\"CategoryID\":3,\"QuantityPerUnit\":\"10 boxes x 12 pieces\",\"UnitPrice\":9.2,\"UnitsInStock\":25,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":20,\"ProductName\":\"Sir Rodney's Marmalade\",\"SupplierID\":8,\"CategoryID\":3,\"QuantityPerUnit\":\"30 gift boxes\",\"UnitPrice\":81,\"UnitsInStock\":40,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":21,\"ProductName\":\"Sir Rodney's Scones\",\"SupplierID\":8,\"CategoryID\":3,\"QuantityPerUnit\":\"24 pkgs.x 4 pieces\",\"UnitPrice\":10,\"UnitsInStock\":3,\"UnitsOnOrder\":40,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":22,\"ProductName\":\"Gustaf's Knäckebröd\",\"SupplierID\":9,\"CategoryID\":5,\"QuantityPerUnit\":\"24 - 500 g pkgs.\",\"UnitPrice\":21,\"UnitsInStock\":104,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":23,\"ProductName\":\"Tunnbröd\",\"SupplierID\":9,\"CategoryID\":5,\"QuantityPerUnit\":\"12 - 250 g pkgs.\",\"UnitPrice\":9,\"UnitsInStock\":61,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":24,\"ProductName\":\"Guaraná Fantástica\",\"SupplierID\":10,\"CategoryID\":1,\"QuantityPerUnit\":\"12 - 355 ml cans\",\"UnitPrice\":4.5,\"UnitsInStock\":20,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":25,\"ProductName\":\"NuNuCa Nuß-Nougat-Creme\",\"SupplierID\":11,\"CategoryID\":3,\"QuantityPerUnit\":\"20 - 450 g glasses\",\"UnitPrice\":14,\"UnitsInStock\":76,\"UnitsOnOrder\":0,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":26,\"ProductName\":\"Gumbär Gummibärchen\",\"SupplierID\":11,\"CategoryID\":3,\"QuantityPerUnit\":\"100 - 250 g bags\",\"UnitPrice\":31.23,\"UnitsInStock\":15,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":27,\"ProductName\":\"Schoggi Schokolade\",\"SupplierID\":11,\"CategoryID\":3,\"QuantityPerUnit\":\"100 - 100 g pieces\",\"UnitPrice\":43.9,\"UnitsInStock\":49,\"UnitsOnOrder\":0,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":28,\"ProductName\":\"Rössle Sauerkraut\",\"SupplierID\":12,\"CategoryID\":7,\"QuantityPerUnit\":\"25 - 825 g cans\",\"UnitPrice\":45.6,\"UnitsInStock\":26,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":7,\"CategoryName\":\"Produce\",\"Description\":\"Dried fruit and bean curd\"}},{\"ProductID\":29,\"ProductName\":\"Thüringer Rostbratwurst\",\"SupplierID\":12,\"CategoryID\":6,\"QuantityPerUnit\":\"50 bags x 30 sausgs.\",\"UnitPrice\":123.79,\"UnitsInStock\":0,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":30,\"ProductName\":\"Nord-Ost Matjeshering\",\"SupplierID\":13,\"CategoryID\":8,\"QuantityPerUnit\":\"10 - 200 g glasses\",\"UnitPrice\":25.89,\"UnitsInStock\":10,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":31,\"ProductName\":\"Gorgonzola Telino\",\"SupplierID\":14,\"CategoryID\":4,\"QuantityPerUnit\":\"12 - 100 g pkgs\",\"UnitPrice\":12.5,\"UnitsInStock\":0,\"UnitsOnOrder\":70,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":32,\"ProductName\":\"Mascarpone Fabioli\",\"SupplierID\":14,\"CategoryID\":4,\"QuantityPerUnit\":\"24 - 200 g pkgs.\",\"UnitPrice\":32,\"UnitsInStock\":9,\"UnitsOnOrder\":40,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":33,\"ProductName\":\"Geitost\",\"SupplierID\":15,\"CategoryID\":4,\"QuantityPerUnit\":\"500 g\",\"UnitPrice\":2.5,\"UnitsInStock\":112,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":34,\"ProductName\":\"Sasquatch Ale\",\"SupplierID\":16,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 12 oz bottles\",\"UnitPrice\":14,\"UnitsInStock\":111,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":35,\"ProductName\":\"Steeleye Stout\",\"SupplierID\":16,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 12 oz bottles\",\"UnitPrice\":18,\"UnitsInStock\":20,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":36,\"ProductName\":\"Inlagd Sill\",\"SupplierID\":17,\"CategoryID\":8,\"QuantityPerUnit\":\"24 - 250 g  jars\",\"UnitPrice\":19,\"UnitsInStock\":112,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":37,\"ProductName\":\"Gravad lax\",\"SupplierID\":17,\"CategoryID\":8,\"QuantityPerUnit\":\"12 - 500 g pkgs.\",\"UnitPrice\":26,\"UnitsInStock\":11,\"UnitsOnOrder\":50,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":38,\"ProductName\":\"Côte de Blaye\",\"SupplierID\":18,\"CategoryID\":1,\"QuantityPerUnit\":\"12 - 75 cl bottles\",\"UnitPrice\":263.5,\"UnitsInStock\":17,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":39,\"ProductName\":\"Chartreuse verte\",\"SupplierID\":18,\"CategoryID\":1,\"QuantityPerUnit\":\"750 cc per bottle\",\"UnitPrice\":18,\"UnitsInStock\":69,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":40,\"ProductName\":\"Boston Crab Meat\",\"SupplierID\":19,\"CategoryID\":8,\"QuantityPerUnit\":\"24 - 4 oz tins\",\"UnitPrice\":18.4,\"UnitsInStock\":123,\"UnitsOnOrder\":0,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":41,\"ProductName\":\"Jack's New England Clam Chowder\",\"SupplierID\":19,\"CategoryID\":8,\"QuantityPerUnit\":\"12 - 12 oz cans\",\"UnitPrice\":9.65,\"UnitsInStock\":85,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":42,\"ProductName\":\"Singaporean Hokkien Fried Mee\",\"SupplierID\":20,\"CategoryID\":5,\"QuantityPerUnit\":\"32 - 1 kg pkgs.\",\"UnitPrice\":14,\"UnitsInStock\":26,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":43,\"ProductName\":\"Ipoh Coffee\",\"SupplierID\":20,\"CategoryID\":1,\"QuantityPerUnit\":\"16 - 500 g tins\",\"UnitPrice\":46,\"UnitsInStock\":17,\"UnitsOnOrder\":10,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":44,\"ProductName\":\"Gula Malacca\",\"SupplierID\":20,\"CategoryID\":2,\"QuantityPerUnit\":\"20 - 2 kg bags\",\"UnitPrice\":19.45,\"UnitsInStock\":27,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":45,\"ProductName\":\"Rogede sild\",\"SupplierID\":21,\"CategoryID\":8,\"QuantityPerUnit\":\"1k pkg.\",\"UnitPrice\":9.5,\"UnitsInStock\":5,\"UnitsOnOrder\":70,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":46,\"ProductName\":\"Spegesild\",\"SupplierID\":21,\"CategoryID\":8,\"QuantityPerUnit\":\"4 - 450 g glasses\",\"UnitPrice\":12,\"UnitsInStock\":95,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":47,\"ProductName\":\"Zaanse koeken\",\"SupplierID\":22,\"CategoryID\":3,\"QuantityPerUnit\":\"10 - 4 oz boxes\",\"UnitPrice\":9.5,\"UnitsInStock\":36,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":48,\"ProductName\":\"Chocolade\",\"SupplierID\":22,\"CategoryID\":3,\"QuantityPerUnit\":\"10 pkgs.\",\"UnitPrice\":12.75,\"UnitsInStock\":15,\"UnitsOnOrder\":70,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":49,\"ProductName\":\"Maxilaku\",\"SupplierID\":23,\"CategoryID\":3,\"QuantityPerUnit\":\"24 - 50 g pkgs.\",\"UnitPrice\":20,\"UnitsInStock\":10,\"UnitsOnOrder\":60,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":50,\"ProductName\":\"Valkoinen suklaa\",\"SupplierID\":23,\"CategoryID\":3,\"QuantityPerUnit\":\"12 - 100 g bars\",\"UnitPrice\":16.25,\"UnitsInStock\":65,\"UnitsOnOrder\":0,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":51,\"ProductName\":\"Manjimup Dried Apples\",\"SupplierID\":24,\"CategoryID\":7,\"QuantityPerUnit\":\"50 - 300 g pkgs.\",\"UnitPrice\":53,\"UnitsInStock\":20,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":7,\"CategoryName\":\"Produce\",\"Description\":\"Dried fruit and bean curd\"}},{\"ProductID\":52,\"ProductName\":\"Filo Mix\",\"SupplierID\":24,\"CategoryID\":5,\"QuantityPerUnit\":\"16 - 2 kg boxes\",\"UnitPrice\":7,\"UnitsInStock\":38,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":53,\"ProductName\":\"Perth Pasties\",\"SupplierID\":24,\"CategoryID\":6,\"QuantityPerUnit\":\"48 pieces\",\"UnitPrice\":32.8,\"UnitsInStock\":0,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":true,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":54,\"ProductName\":\"Tourtière\",\"SupplierID\":25,\"CategoryID\":6,\"QuantityPerUnit\":\"16 pies\",\"UnitPrice\":7.45,\"UnitsInStock\":21,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":55,\"ProductName\":\"Pâté chinois\",\"SupplierID\":25,\"CategoryID\":6,\"QuantityPerUnit\":\"24 boxes x 2 pies\",\"UnitPrice\":24,\"UnitsInStock\":115,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":6,\"CategoryName\":\"Meat/Poultry\",\"Description\":\"Prepared meats\"}},{\"ProductID\":56,\"ProductName\":\"Gnocchi di nonna Alice\",\"SupplierID\":26,\"CategoryID\":5,\"QuantityPerUnit\":\"24 - 250 g pkgs.\",\"UnitPrice\":38,\"UnitsInStock\":21,\"UnitsOnOrder\":10,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":57,\"ProductName\":\"Ravioli Angelo\",\"SupplierID\":26,\"CategoryID\":5,\"QuantityPerUnit\":\"24 - 250 g pkgs.\",\"UnitPrice\":19.5,\"UnitsInStock\":36,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":58,\"ProductName\":\"Escargots de Bourgogne\",\"SupplierID\":27,\"CategoryID\":8,\"QuantityPerUnit\":\"24 pieces\",\"UnitPrice\":13.25,\"UnitsInStock\":62,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":59,\"ProductName\":\"Raclette Courdavault\",\"SupplierID\":28,\"CategoryID\":4,\"QuantityPerUnit\":\"5 kg pkg.\",\"UnitPrice\":55,\"UnitsInStock\":79,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":60,\"ProductName\":\"Camembert Pierrot\",\"SupplierID\":28,\"CategoryID\":4,\"QuantityPerUnit\":\"15 - 300 g rounds\",\"UnitPrice\":34,\"UnitsInStock\":19,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":61,\"ProductName\":\"Sirop d'érable\",\"SupplierID\":29,\"CategoryID\":2,\"QuantityPerUnit\":\"24 - 500 ml bottles\",\"UnitPrice\":28.5,\"UnitsInStock\":113,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":62,\"ProductName\":\"Tarte au sucre\",\"SupplierID\":29,\"CategoryID\":3,\"QuantityPerUnit\":\"48 pies\",\"UnitPrice\":49.3,\"UnitsInStock\":17,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":63,\"ProductName\":\"Vegie-spread\",\"SupplierID\":7,\"CategoryID\":2,\"QuantityPerUnit\":\"15 - 625 g jars\",\"UnitPrice\":43.9,\"UnitsInStock\":24,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":64,\"ProductName\":\"Wimmers gute Semmelknödel\",\"SupplierID\":12,\"CategoryID\":5,\"QuantityPerUnit\":\"20 bags x 4 pieces\",\"UnitPrice\":33.25,\"UnitsInStock\":22,\"UnitsOnOrder\":80,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":5,\"CategoryName\":\"Grains/Cereals\",\"Description\":\"Breads, crackers, pasta, and cereal\"}},{\"ProductID\":65,\"ProductName\":\"Louisiana Fiery Hot Pepper Sauce\",\"SupplierID\":2,\"CategoryID\":2,\"QuantityPerUnit\":\"32 - 8 oz bottles\",\"UnitPrice\":21.05,\"UnitsInStock\":76,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":66,\"ProductName\":\"Louisiana Hot Spiced Okra\",\"SupplierID\":2,\"CategoryID\":2,\"QuantityPerUnit\":\"24 - 8 oz jars\",\"UnitPrice\":17,\"UnitsInStock\":4,\"UnitsOnOrder\":100,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}},{\"ProductID\":67,\"ProductName\":\"Laughing Lumberjack Lager\",\"SupplierID\":16,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 12 oz bottles\",\"UnitPrice\":14,\"UnitsInStock\":52,\"UnitsOnOrder\":0,\"ReorderLevel\":10,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":68,\"ProductName\":\"Scottish Longbreads\",\"SupplierID\":8,\"CategoryID\":3,\"QuantityPerUnit\":\"10 boxes x 8 pieces\",\"UnitPrice\":12.5,\"UnitsInStock\":6,\"UnitsOnOrder\":10,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":3,\"CategoryName\":\"Confections\",\"Description\":\"Desserts, candies, and sweet breads\"}},{\"ProductID\":69,\"ProductName\":\"Gudbrandsdalsost\",\"SupplierID\":15,\"CategoryID\":4,\"QuantityPerUnit\":\"10 kg pkg.\",\"UnitPrice\":36,\"UnitsInStock\":26,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":70,\"ProductName\":\"Outback Lager\",\"SupplierID\":7,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 355 ml bottles\",\"UnitPrice\":15,\"UnitsInStock\":15,\"UnitsOnOrder\":10,\"ReorderLevel\":30,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":71,\"ProductName\":\"Flotemysost\",\"SupplierID\":15,\"CategoryID\":4,\"QuantityPerUnit\":\"10 - 500 g pkgs.\",\"UnitPrice\":21.5,\"UnitsInStock\":26,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":72,\"ProductName\":\"Mozzarella di Giovanni\",\"SupplierID\":14,\"CategoryID\":4,\"QuantityPerUnit\":\"24 - 200 g pkgs.\",\"UnitPrice\":34.8,\"UnitsInStock\":14,\"UnitsOnOrder\":0,\"ReorderLevel\":0,\"Discontinued\":false,\"Category\":{\"CategoryID\":4,\"CategoryName\":\"Dairy Products\",\"Description\":\"Cheeses\"}},{\"ProductID\":73,\"ProductName\":\"Röd Kaviar\",\"SupplierID\":17,\"CategoryID\":8,\"QuantityPerUnit\":\"24 - 150 g jars\",\"UnitPrice\":15,\"UnitsInStock\":101,\"UnitsOnOrder\":0,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":8,\"CategoryName\":\"Seafood\",\"Description\":\"Seaweed and fish\"}},{\"ProductID\":74,\"ProductName\":\"Longlife Tofu\",\"SupplierID\":4,\"CategoryID\":7,\"QuantityPerUnit\":\"5 kg pkg.\",\"UnitPrice\":10,\"UnitsInStock\":4,\"UnitsOnOrder\":20,\"ReorderLevel\":5,\"Discontinued\":false,\"Category\":{\"CategoryID\":7,\"CategoryName\":\"Produce\",\"Description\":\"Dried fruit and bean curd\"}},{\"ProductID\":75,\"ProductName\":\"Rhönbräu Klosterbier\",\"SupplierID\":12,\"CategoryID\":1,\"QuantityPerUnit\":\"24 - 0.5 l bottles\",\"UnitPrice\":7.75,\"UnitsInStock\":125,\"UnitsOnOrder\":0,\"ReorderLevel\":25,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":76,\"ProductName\":\"Lakkalikööri\",\"SupplierID\":23,\"CategoryID\":1,\"QuantityPerUnit\":\"500 ml\",\"UnitPrice\":18,\"UnitsInStock\":57,\"UnitsOnOrder\":0,\"ReorderLevel\":20,\"Discontinued\":false,\"Category\":{\"CategoryID\":1,\"CategoryName\":\"Beverages\",\"Description\":\"Soft drinks, coffees, teas, beers, and ales\"}},{\"ProductID\":77,\"ProductName\":\"Original Frankfurter grüne Soße\",\"SupplierID\":12,\"CategoryID\":2,\"QuantityPerUnit\":\"12 boxes\",\"UnitPrice\":13,\"UnitsInStock\":32,\"UnitsOnOrder\":0,\"ReorderLevel\":15,\"Discontinued\":false,\"Category\":{\"CategoryID\":2,\"CategoryName\":\"Condiments\",\"Description\":\"Sweet and savory sauces, relishes, spreads, and seasonings\"}}]";
        #endregion

        private class kProduct
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public float UnitPrice { get; set; }
            public kCategory Category { get; set; }
        }

        private class kCategory
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }

        }
    }
}
