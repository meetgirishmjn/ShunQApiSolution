using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using xApp.ViewModels;

namespace xApp.Services
{
    public class gMapViewModel : INotifyPropertyChanged
    {
        public ICommand CalculateRouteCommand { get; set; }
        public ICommand UpdatePositionCommand { get; set; }

        public ICommand LoadRouteCommand { get; set; }
        public ICommand StopRouteCommand { get; set; }
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();

        bool _hasRouteRunning;
        string _originLatitud;
        string _originLongitud;
        string _destinationLatitud;
        string _destinationLongitud;

        GooglePlaceAutoCompletePrediction _placeSelected;
        public GooglePlaceAutoCompletePrediction PlaceSelected
        {
            get
            {
                return _placeSelected;
            }
            set
            {
                _placeSelected = value;
                if (_placeSelected != null)
                    GetPlaceDetailCommand.Execute(_placeSelected);
            }
        }
        public ICommand FocusOriginCommand { get; set; }
        public ICommand GetPlacesCommand { get; set; }
        public ICommand GetPlaceDetailCommand { get; set; }

          ObservableCollection<GooglePlaceAutoCompletePrediction> _places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places
        {
            get
            {
                return _places;
            }
            set
            {
                this._places = value;
                this.NotifyPropertyChanged();
            }
        }

        #region "PropertyChanged"
        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion "PropertyChanged"

        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

        public bool ShowRecentPlaces { get; set; }
        bool _isPickupFocused = true;

        string _pickupText;
        public string PickupText
        {
            get
            {
                return _pickupText;
            }
            set
            {
                _pickupText = value;
                if (!string.IsNullOrEmpty(_pickupText))
                {
                    _isPickupFocused = true;
                    GetPlacesCommand.Execute(_pickupText);
                }
            }
        }

        string _originText;
        public string OriginText
        {
            get
            {
                return _originText;
            }
            set
            {
                _originText = value;
                if (!string.IsNullOrEmpty(_originText))
                {
                    _isPickupFocused = false;
                    GetPlacesCommand.Execute(_originText);
                }
            }
        }

        public gMapViewModel()
        {
           // LoadRouteCommand = new Command(async () => await LoadRoute());
            StopRouteCommand = new Command(StopRoute);
            GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
            GetPlaceDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
        }

        //public async Task LoadRoute()
        //{
        //    var positionIndex = 1;
        //    var googleDirection = await googleMapsApi.GetDirections(_originLatitud, _originLongitud, _destinationLatitud, _destinationLongitud);
        //    if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
        //    {
        //        var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
        //        CalculateRouteCommand.Execute(positions);

        //        _hasRouteRunning = true;

        //        //Location tracking simulation
        //        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //        {
        //            if (positions.Count > positionIndex && _hasRouteRunning)
        //            {
        //                UpdatePositionCommand.Execute(positions[positionIndex]);
        //                positionIndex++;
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        });
        //    }
        //    else
        //    {
        //        await App.Current.MainPage.DisplayAlert(":(", "No route found", "Ok");
        //    }

        //}
        public void StopRoute()
        {
            _hasRouteRunning = false;
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
            }

            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (place != null)
            {
                try
                {
                   
                    await SecureStorage.SetAsync("storeSearchLocation", place.Latitude + "," + place.Longitude);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PopAsync();
                        MessagingCenter.Send(place, "searchLocationChange");
                    });
                }
                catch (Exception ex)
                {
                    Device.BeginInvokeOnMainThread(() =>
                   {
                       var toastr = DependencyService.Get<IToastr>();
                       toastr.ShowError("Error occured");
                   });
                }
            }
        }

        void CleanFields()
        {
            PickupText = OriginText = string.Empty;
            ShowRecentPlaces = true;
            PlaceSelected = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
