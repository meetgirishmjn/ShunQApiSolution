using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class StoreListViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public List<StoreListItem> StoreList { get; set; }
        public bool HasActiveCart { get; set; }
        public int? ActiveStoreId { get; set; }
        public StoreListViewModel()
        {
            this.StoreList = new List<StoreListItem>();
        }

        public class StoreListItem
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
        }
    }
}
