using System;
using System.Collections.Generic;
using System.Text;
using xApp.ViewModels;

namespace xApp.Services
{
    public class StoreRoutePageViewModel
    {
        public StoreListViewModel.StoreListItem Store { get; set; }
        public string AddressLine { get; set; }
        public StoreRoutePageViewModel()
        {
            Store = AppViewModel.Instance.GetViewModel<StoreListViewModel.StoreListItem>();
            Store = Store ?? new StoreListViewModel.StoreListItem();
            this.AddressLine = Store.Address?.Locality + " - " + Store.Address?.Zip;
            AppViewModel.Instance.ClearViewModel<StoreListViewModel.StoreListItem>();
        }
       
    }
}
