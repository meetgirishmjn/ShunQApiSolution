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
                    Device.BeginInvokeOnMainThread(() => onLoad());
                });

                MessagingCenter.Subscribe<GooglePlace>(this, "searchLocationChange", searchLocationChanged);
                MessagingCenter.Subscribe<FilterPageViewModelEx>(this, "storeFilterApplied", storeFilterApplied);
                
            }
            catch (Exception ex)
            {

            }
        
        }

        private async void onLoad()
        {
            string lat = "", lng = "";
            int categoryId = 0;

            //wait for _categoryId to be set by route if routed from categories
            await Task.Delay(250);

            int.TryParse(_categoryId, out categoryId);

            var location = await getLatLong();
            lat = location.Latitude;
            lng = location.Longitude;

            (this.BindingContext as StoreSearchEx).OnLoad(lat, lng, categoryId);
        }

        private void searchLocationChanged(GooglePlace place)
        {
            (this.BindingContext as StoreSearchEx).OnLoad(place.Latitude+"", place.Longitude+"");
        }
        private async void storeFilterApplied(FilterPageViewModelEx vm)
        {
            try
            {

                int.TryParse(_categoryId, out int categoryId);
                var location = await getLatLong();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Location Error", "Could not get current location.", "Ok");
            }
        }
        
        private async Task<(string Latitude, string Longitude)> getLatLong()
        {
            string lat = "", lng = "";
            try
            {

                //get user preference
                var latCommaLng = await SecureStorage.GetAsync("storeSearchLocation");
                if (latCommaLng != null && latCommaLng.Contains(","))
                {
                    lat = latCommaLng.Split(',')[0];
                    lng = latCommaLng.Split(',')[1];
                }
                else
                {
                    //demand current lat long
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);

                    if (location != null)
                    {
                        lat = location.Latitude.ToString();
                        lng = location.Longitude.ToString();
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

            return (Latitude : lat, Longitude : lng ); 
        }
        private async void SfButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("storeFilterPage");
        }
        private async void SfButton1_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("storeAddressSearchPage");
        }
    }

    //public class CatalogPageViewModel
    //{
    //    private int cartItemCount = 10;
    //    public int CartItemCount
    //    {
    //        get
    //        {
    //            return this.cartItemCount;
    //        }
    //        set
    //        {
    //            this.cartItemCount = value;
    //        }
    //    }

    //    public ObservableCollection<Product> Products
    //    {
    //        get; set;
    //    }

    //    public CatalogPageViewModel()
    //    {
    //        this.Products = new ObservableCollection<Product>
    //        {
    //            new Product
    //            {
    //                Id = 1,
    //                PreviewImage =App.BaseImageUrl + "Image1.png",
    //                Name = "Full-Length Skirt",
    //                Summary = "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
    //                Description = "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
    //                ActualPrice = 220,
    //                DiscountPercent = 15,
    //                OverallRating = 5,
    //                PreviewImages = new List<string> { "Image1.png", "Image1.png", "Image1.png", "Image1.png", "Image1.png" },
    //                Reviews = new ObservableCollection<Review>
    //                {
    //                    new Review
    //                    {
    //                        ProfileImage = "ProfileImage10.png",
    //                        CustomerName = "Serina Williams",
    //                        Comment = "Greatest purchase I have ever made in my life.",
    //                        Rating = 5,
    //                        Images = new List<string> { "Image1.png", "Image1.png", "Image1.png" },
    //                        ReviewedDate = DateTime.Parse("2019-12-29")
    //                    },
    //                }
    //            }
    //        };
    //    }
    //}
}