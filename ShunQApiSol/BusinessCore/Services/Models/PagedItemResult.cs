using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Models
{

    public class PagedItemRead
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }
    }

   public class PagedItemResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPageCount { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }

        public List<T> Items { get; set; }
    }

    
}
