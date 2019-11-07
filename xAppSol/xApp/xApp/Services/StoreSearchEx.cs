using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
                this.NotifyPropertyChanged(nameof(IsNoRecord));
                
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


            var str = await SecureStorage.GetAsync("storeSearchLocation");
            if (str != null)
            {
                var loc = JsonConvert.DeserializeObject<StoreSearchLocation>(str);
                seachReq.Latitude = (loc?.Latitude) + "";
                seachReq.Longitude = (loc?.Longitude) + "";
            }
            OnLoad(seachReq);
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
        public bool IsNoRecord { get { return !IsLoading && !IsSearching && this.StoreItems.Count == 0; } }
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
                this.IsLoading = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsNotSearching));
            }
        }


        public bool IsNotSearching
        {
            get { return !_isSearching; }
        }

        //public async void OnLoad(string latitude,string longitude,int? categoryId=null)
        //{
        //    this.IsLoading = true;

        //    var api = new ApiService();
        //    var seachReq = new StoreListModel()
        //    {
        //        PageSize = PAGE_SIZE,
        //        Latitude=latitude,
        //        Longitude=longitude,
        //    };

        //    if (categoryId.HasValue && categoryId>0)
        //        seachReq.FilterByCategoryIds = new int[] { categoryId.Value };

        //    var vm = await api.StoreSearch(seachReq);

        //    storeSearchLoaded(vm);

        //    this.IsLoading = false;
        //}

        //private async void updateSearchLocation(StoreListModel searchReq)
        //{
        //    double.TryParse(searchReq.Latitude, out double lat);
        //    double.TryParse(searchReq.Latitude, out double lng);
        //    const string defVal = "Change Location";
        //    if (lat > 0 && lng > 0)
        //    {
        //        var loc = await (new GoogleMapsApiService()).ToSearchLocation(lat, lng);
        //        SearchLocation = loc == null ? defVal : loc.Name;
        //    }
        //    else
        //        SearchLocation = defVal;
        //}

        public async void OnLoad(StoreListModel searchReq,bool isFirstLoad=false)
        {
            this.StoreItems.Clear();
            this.IsLoading = isFirstLoad;
            this.IsSearching = !isFirstLoad;
            await Task.Delay(1000);
            searchReq.PageSize = PAGE_SIZE;

            var str = await SecureStorage.GetAsync("storeSearchLocation");
            if (str != null)
            {
                SearchLocation = JsonConvert.DeserializeObject<StoreSearchLocation>(str).Name;
            }

            var vm = await api.StoreSearch(searchReq);
            storeSearchLoaded(vm);
            this.IsLoading = false;
            this.IsSearching = false;
        }
       async void  storeSearchLoaded(SearchStoresViewModel vm)
        {
            if (vm != null)
            {
                StoreSearchLocation curLoc = null;
                var str = await SecureStorage.GetAsync("storeSearchLocation");
                if (str != null)
                {
                    curLoc = JsonConvert.DeserializeObject<StoreSearchLocation>(str);

                    vm.StoreSearchResult.StoreList.ForEach(o =>
                    {
                        Location l1 = new Location(curLoc.Latitude, curLoc.Longitude);
                        Location l2 = new Location(double.Parse(o.Address.Latitude), double.Parse( o.Address.Longitude));
                        double km = Location.CalculateDistance(l1, l2, DistanceUnits.Kilometers);
                        o.DistanceText= String.Format("{0:0.0}", km)+" km";
                    });
                }
               
                this.StoreItems = new ObservableCollection<StoreListViewModel.StoreListItem>(vm.StoreSearchResult.StoreList);
            }
            
            //used by FilterPage
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
