using BusinessCore.Models;
using BusinessCore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class SearchStoresViewModel
    {
        public List<ListItem> SorOptions { get; set; }
        public List<StoreCategoryItem> StoreCategories { get; set; }
        public StoreListViewModel StoreList { get; set; }
        
        public SearchStoresViewModel()
        {
            this.SorOptions = new List<ListItem>();
            this.StoreCategories = new List<StoreCategoryItem>();
        }
    }
}
