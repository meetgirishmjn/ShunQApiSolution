using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RequestModels
{
    public class StoreListModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SortBy { get; set; }

        public StoreFilter FilterBy { get; set; }

        public class StoreFilter
        {
            public int? CategoryId { get; set; }
        }
    }
}
