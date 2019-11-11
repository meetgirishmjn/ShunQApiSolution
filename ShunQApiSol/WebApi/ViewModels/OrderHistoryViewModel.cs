using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class OrderHistoryViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }
        public bool HasMore { get; set; }
        public List<OrderItem> OrderList { get; set; }

        public OrderHistoryViewModel()
        {
            OrderList = new List<OrderItem>();
        }
    }

    //public class OrderHistoryItem
    //{
    //    public string OrderId { get; set; }
    //    public string Status { get; set; }
    //    public string IsSuccess { get; set; }
    //    public int StoreId { get; set; }
    //    public int StoreName { get; set; }
    //    public DateTime OrderDate { get; set; }
    //    public float Amount { get; set; }
    //}
}
