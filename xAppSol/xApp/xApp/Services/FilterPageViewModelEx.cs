using System;
using System.Collections.Generic;
using System.Linq;

namespace xApp.Services
{
    public class FilterPageViewModelEx : BaseVM
    {
        public List<ListItem> SortOptions { get; set; }
        public List<CategoryItem> StoreCategories { get; set; }

        public FilterPageViewModelEx(SearchStoresViewModel vm)
        {
            if (vm != null)
            {
                this.SortOptions = vm.SortOptions;
                this.StoreCategories = vm.StoreCategories.Select(o => new CategoryItem { Name = o.Name, IsChecked = o.IsSelected, StoreCount = o.StoreCount }).ToList();
            }
        }

        public class CategoryItem : BaseVM
        {
            public string Name { get; set; }

            bool _isChecked = false;
            public bool IsChecked { get { return _isChecked; } set { _isChecked = value; NotifyPropertyChanged(); } }
            public int StoreCount { get; set; }

            public string DisplayName
            {
                get { return Name + " (" + StoreCount + ")"; }
            }
        }
    }
}
