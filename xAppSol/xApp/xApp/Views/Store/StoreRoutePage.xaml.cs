using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreRoutePage : ContentPage
    {
        public StoreRoutePage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new StoreRoutePageViewModel();
               // this.ProductImage.Source = App.BaseImageUrl + "ReviewShoe.png";
                //webView.Source = "https://www.google.com/maps/dir/?api=1&origin=Google+Pyrmont+NSW&destination=QVB&destination_place_id=ChIJISz8NjyuEmsRFTQ9Iw7Ear8";
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = getHtml();
                webView.Source = htmlSource;
            }
            catch (Exception ex)
            {

            }
        }

        string getHtml()
        {

            return @"<!DOCTYPE html><html> <head>   <meta name='viewport' content='initial-scale=1.0, user-scalable=no'>   <meta charset='utf-8'>
                     <title>Disabling the Default UI</title>   <style>
                      #map {
                           height: 100%;
                         }
                    html, body {
                           height: 100%;
                           margin: 0;
                           padding: 0;
                         }
                     </style>
                     </head>
                     <body>
                       <div id='map'></div>
                       <script>
                         function  initMap() {
                            var fromCord = { latitude: 12.9360, longitude: 77.6938 };
                            var toCord = { latitude: 12.9169429, longitude: 77.621934 };
                            var directionsDisplay = new google.maps.DirectionsRenderer;
                            var directionsService = new google.maps.DirectionsService;
                            var map = new google.maps.Map(document.getElementById('map'), {
                                zoom: 16,
                                disableDefaultUI: true,
                                center: { lat: fromCord.latitude, lng: fromCord.longitude }
                            });
                            directionsDisplay.setMap(map);
                            calculateAndDisplayRoute(directionsService, directionsDisplay, fromCord, toCord);
                            }
                                function calculateAndDisplayRoute(directionsService, directionsDisplay, fromLoc, toLoc) {
                                                    directionsService.route({
                                                        origin: { lat: fromLoc.latitude, lng: fromLoc.longitude },  // Haight.
                                                        destination: { lat: toLoc.latitude, lng: toLoc.longitude },  // Ocean Beach.
                                                        // Note that Javascript allows us to access the constant
                                                        // using square brackets and a string value as its
                                                        travelMode: google.maps.TravelMode['DRIVING']
                                                    }, function(response, status)
                                    {
                                        if (status == 'OK')
                                        {
                                            directionsDisplay.setDirections(response);
                                            //var min = Math.round(response.routes[0].legs[0].duration.value / 60);
                                            //that.timeStr = min+ ' min';
                                            //var km = response.routes[0].legs[0].distance.value / 1000;
                                            //that.distanceStr = km.toFixed(1) + ' km'; // 1613.8 km
                                        }
                                        else
                                        {
                                            // that.routeError = 'No Route found for Travel-Mode';
                                        }
                                    });
                                }
                       </script>
                       <script 
                       src='https://maps.googleapis.com/maps/api/js?key=AIzaSyANlnLEfxFvmCcy2-BreuMlH97Q2zaDONA&callback=initMap'>
                       </script>
                     </body>
                    </html>";
        }
    }
}