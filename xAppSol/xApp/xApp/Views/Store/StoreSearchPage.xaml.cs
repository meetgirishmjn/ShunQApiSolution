using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Models.Detail;
using xApp.Services;
using xApp.ViewModels;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("CategoryId", "categoryId")]
    public partial class StoreSearchPage : ContentPage
    {
        public string _categoryId;
        public string CategoryId
        {
            set
            {
                _categoryId = Uri.UnescapeDataString(value);
                onLoad(true);
            }
        }

        public StoreSearchPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new StoreSearchEx();

                Task.Run(() =>
                {
                     Shell.Current.GoToAsync($"//tabStores?categoryId=-1");
                    // Device.BeginInvokeOnMainThread(() => onLoad(true));
                });

                MessagingCenter.Subscribe<StoreSearchLocation>(this, "searchLocationChange", searchLocationChanged);
                MessagingCenter.Subscribe<FilterPageViewModelEx>(this, "storeFilterApplied", storeFilterApplied);
                MessagingCenter.Subscribe<object>(this, "storeFilterCleared", storeFilterCleared);
                ViewModels.AppViewModel.Instance.ClearViewModel<FilterPageViewModelEx>();
            }
            catch (Exception ex)
            {

            }
        
        }

        private async void onLoad(bool isOnLoad=false)
        {
            //wait for _categoryId to be set by route if routed from categories
           // await Task.Delay(250);

            int.TryParse(_categoryId, out int categoryId);

            var location = await getLatLong();

            var searchReq = new StoreListModel
            {
                FilterByCategoryIds = new int[] { categoryId },
                Latitude = location?.Latitude+"",
                Longitude = location?.Longitude + ""
            };

            (this.BindingContext as StoreSearchEx).OnLoad(searchReq, isOnLoad);
        }


        private async void searchLocationChanged(StoreSearchLocation location)
        {
            try
            {
                isEventProcessing = true;
                searchBar1.Text = "";
                await SecureStorage.SetAsync("storeSearchLocation", JsonConvert.SerializeObject(location));

                var searchReq = new StoreListModel
                {
                    Latitude = location.Latitude.ToString(),
                    Longitude = location.Longitude.ToString()
                };

                (this.BindingContext as StoreSearchEx).OnLoad(searchReq);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Filter Error", "Could not update search filters.", "Ok");
            }
            finally
            {
                isEventProcessing = false;
            }
        }

        
        private async void storeFilterApplied(FilterPageViewModelEx vm)
        {
            try
            {
                isEventProcessing = true;
                searchBar1.Text = "";

                int.TryParse(_categoryId, out int categoryId);
                var location = await getLatLong();

                var sort = vm.SortOptions.Where(o => o.IsChecked).FirstOrDefault();
                
                var searchReq = new StoreListModel
                {
                    SortBy =sort?.Name,
                    FilterByCategoryIds =vm.StoreCategories.Where(o=>o.IsChecked).Select(o=>o.Id).ToArray(),
                    Latitude =  location?.Latitude+"",
                    Longitude = location?.Longitude + ""
                };
                
                (this.BindingContext as StoreSearchEx).OnLoad(searchReq);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Filter Error", "Could not update search filters.", "Ok");
            }
            finally
            {
                isEventProcessing = false;
            }
        }

        private async void storeFilterCleared(object sender)
        {
            try
            {
                
                isEventProcessing = true;
                searchBar1.Text = "";

                var location = await getLatLong();

                var searchReq = new StoreListModel
                {
                    Latitude = location?.Latitude + "",
                    Longitude = location.Longitude + ""
                };

                (this.BindingContext as StoreSearchEx).OnLoad(searchReq);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Filter Error", "Could not update search filters.", "Ok");
            }
            finally
            {
                isEventProcessing = false;
            }
        }

        private async Task<StoreSearchLocation> getLatLong()
        {
            StoreSearchLocation result = null;
            try
            {
                //get user preference
                var str = await SecureStorage.GetAsync("storeSearchLocation");
                if (str != null)
                {
                    result = JsonConvert.DeserializeObject< StoreSearchLocation>(str);
                }
                else
                {
                    //demand current lat long
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        result = await  new GoogleMapsApiService().ToSearchLocation(location.Latitude, location.Longitude);
                       await SecureStorage.SetAsync("storeSearchLocation",JsonConvert.SerializeObject(result));
                    }
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                     DisplayAlert("Location Error", "Could not get current location.", "Ok");
                });
            }

            return result; 
        }
        private async void btnFilter_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("storeFilterPage");
        }
        private async void btnChangeLocation_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("storeAddressSearchPage");
        }

        private async void StoreMapRoute_Clicked(object sender, EventArgs e)
        {
            var store = (sender as Xamarin.Forms.Button).CommandParameter as StoreListViewModel.StoreListItem;
            AppViewModel.Instance.SetViewModel(store);
            await Shell.Current.Navigation.PushModalAsync(new StoreRoutePage());
          //  await Shell.c("storeRoutePage");
            //var origin = "12.9360,77.6938";
            //var destination = "12.9169429,77.621934";
            //// Device.OpenUri(new Uri("https://www.google.com/maps/dir/?api=1&origin=" + origin + "&destination=" + destination));
            //Device.OpenUri(new Uri("https://www.google.com/maps/dir/?api=1&origin=Google+Pyrmont+NSW&destination=QVB&destination_place_id=ChIJISz8NjyuEmsRFTQ9Iw7Ear8"));
        }

        bool isEventProcessing = false;
        private void searchBar1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isEventProcessing)
                return;

            var searchTextApplied = (this.BindingContext as StoreSearchEx).IsSearchTextApplied;

            if(searchTextApplied && searchBar1.Text.Trim().Length == 0)
                (this.BindingContext as StoreSearchEx).PerformSearch.Execute("");
        }
    }
}