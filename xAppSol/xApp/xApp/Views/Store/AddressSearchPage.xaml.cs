using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressSearchPage : ContentPage
    {
        public AddressSearchPage()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                Task.Run(async () =>
                {
                    await Task.Delay(500);
                    Device.BeginInvokeOnMainThread(() => searchEntry.Focus());
                });
            }
        }

        bool isInProcess = false;
        private async void btnCurrentLocation_Clicked(object sender, EventArgs e)
        {
            if (isInProcess)
                return;
            isInProcess = true;
            var gotLocation = false;
            try
            {
                //demand current lat long
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    gotLocation = true;
                    var loc =await (new GoogleMapsApiService()).ToSearchLocation(location.Latitude, location.Longitude);
                     await SecureStorage.SetAsync("storeSearchLocation", Newtonsoft.Json.JsonConvert.SerializeObject(loc));
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PopAsync();
                        MessagingCenter.Send(loc, "searchLocationChange");
                    });
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                isInProcess = false;
            }

            if (!gotLocation)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Location Error", "Could not get current location.", "Ok");

                });
            }
        }
    }
}