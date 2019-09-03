using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class StoreInfoViewModel
    {
        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string BannerImageUrl { get; set; }
        public StoreReview ReviewRating { get; set; }
        public bool HasActiveCart { get; set; }
        public Address Address { get; set; }
    }
}
