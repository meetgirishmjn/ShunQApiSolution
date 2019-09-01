using BusinessCore.DataAccess.Contracts;
using BusinessCore.Models;
using BusinessCore.Services.Contracts;
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

        public StoreReview StoreReview(int storeId)
        {
            var rand = new Random(storeId);
            var part1 = rand.Next(1, 6);
            var part2 = rand.Next(1, 10);
            return new StoreReview
            {
                StoreId=storeId,
                Value = float.Parse(part1 + "." + part2),
                VoteCount = rand.Next(1, 1000)
            };
        }

        public List<StoreReview> StoreReviews(int[] storeIds)
        {
            var results = new List<StoreReview>();

            foreach(var id in storeIds)
            {
                results.Add(StoreReview(id));
            }

            return results;
        }
    }
}
