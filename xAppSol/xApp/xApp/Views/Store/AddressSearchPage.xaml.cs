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
                    await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() => searchEntry.Focus());
                });
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var gotLocation = false;
            try
            {
                //demand current lat long
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    await SecureStorage.SetAsync("storeSearchLocation", location.Latitude + "," + location.Longitude);
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.Navigation.PopAsync();
                        MessagingCenter.Send(new GooglePlace { Latitude = location.Latitude, Longitude = location.Longitude }, "searchLocationChange");
                    });
                }
            }
            catch (Exception ex)
            {

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