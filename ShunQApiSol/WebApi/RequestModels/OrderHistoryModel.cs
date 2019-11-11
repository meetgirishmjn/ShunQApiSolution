using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RequestModels
{
    public class OrderHistoryModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string OrderStatus { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }
    }
}
