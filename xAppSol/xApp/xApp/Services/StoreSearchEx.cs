﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xApp.Services
{
    public partial class StoreSearchEx : INotifyPropertyChanged
    {
        const int PAGE_SIZE = 50;
        private ObservableCollection<StoreListViewModel.StoreListItem> _storeItems;
        public ObservableCollection<StoreListViewModel.StoreListItem> StoreItems
        {
            get
            {
                return _storeItems;
            }
            set
            {
                this._storeItems = value;
                this.NotifyPropertyChanged();
            }
        }

        public IToastr toastr { get; set; }
        public ApiService api { get; set; }

        public ICommand ItemTapCommand { get; set; }


        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            var seachReq = new StoreListModel()
            {
                PageSize = PAGE_SIZE,
                SearchKey=query
            };
            this.IsSearching = true;
            var vm = await api.StoreSearch(seachReq);

            storeSearchLoaded(vm);
            this.IsSearching = false;
        });

        public StoreSearchEx()
        {
            this.IsLoading = true;
            this.StoreItems = new ObservableCollection<StoreListViewModel.StoreListItem>();
            this.ItemTapCommand = new Command<Syncfusion.ListView.XForms.ItemTappedEventArgs>(onItemTapCommand);
            toastr = DependencyService.Get<IToastr>();
            api = new ApiService();
        }

        #region "PropertyChanged"
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion "PropertyChanged"

        #region "IsLoading"
        bool _isLoading = false;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                this._isLoading = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotLoading));
            }
        }

        string _searchLocation="";
        public string SearchLocation
        {
            get { return _searchLocation; }
            set { _searchLocation = value; this.NotifyPropertyChanged(); }
        }

        public bool IsNotLoading
        {
            get { return !_isLoading; }
        }
        #endregion "IsLoading"

        bool _isSearching = false;
        public bool IsSearching
        {
            get { return _isSearching; }
            set
            {
                this._isSearching = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotSearching));
            }
        }


        public bool IsNotSearching
        {
            get { return !_isSearching; }
        }

        public async void OnLoad(string latitude,string longitude,int? categoryId=null)
        {
            this.IsLoading = true;

            var api = new ApiService();
            var seachReq = new StoreListModel()
            {
                PageSize = PAGE_SIZE,
                Latitude=latitude,
                Longitude=longitude,
            };

            if (categoryId.HasValue && categoryId>0)
                seachReq.FilterByCategoryIds = new int[] { categoryId.Value };

            var vm = await api.StoreSearch(seachReq);

            storeSearchLoaded(vm);

            this.IsLoading = false;
        }

        public async void OnLoad(StoreListModel searchReq)
        {
            this.IsLoading = true;
            searchReq.PageSize = PAGE_SIZE;
            var vm = await api.StoreSearch(searchReq);
            storeSearchLoaded(vm);
            this.IsLoading = false;
        }
            void storeSearchLoaded(SearchStoresViewModel vm)
        {
            if (vm != null)
            {
                SearchLocation = vm.StoreSearchResult.SearchLocation;
                this.StoreItems = new ObservableCollection<StoreListViewModel.StoreListItem>(vm.StoreSearchResult.StoreList);
            }
            ViewModels.AppViewModel.Instance.SetViewModel(vm);
        }
        private async void onItemTapCommand(Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            try
            {
                var item = (e.ItemData as StoreCategoryItem);
                await Shell.Current.GoToAsync($"//Stores");
            }
            catch (Exception ex)
            {

            }
        }


        List<string> _searchResults = new List<string>() { "abc", "xyz", "pgr" };
        public List<string> SearchResults
        {
            get
            {
                return _searchResults;
            }
            set
            {
                _searchResults = value;
                NotifyPropertyChanged();
            }
        }
    }

    public class StoreSearchHandler : SearchHandler
    {
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = new List<string>
                {
                    "strings will be URL encoded for navigation",
                    "URL encoded for navigation",
                    "for navigation",
                    "encoded for ",
                    " be URL  for navigation"
                };
            }
        }

        //protected override async void OnItemSelected(object item)
        //{
        //    base.OnItemSelected(item);

        //    // Note: strings will be URL encoded for navigation (e.g. "Blue Monkey" becomes "Blue%20Monkey"). Therefore, decode at the receiver.
        //   // await (App.Current.MainPage as Xamarin.Forms.Shell).GoToAsync($"monkeydetails?name={((Animal)item).Name}");
        //}
    }

}
