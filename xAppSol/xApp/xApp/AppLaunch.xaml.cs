using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;
using xApp.Views.LogIn;

namespace xApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLaunch : ContentPage
    {
        public AppLaunch()
        {
            InitializeComponent();
            LoadPageAsync();
        }

        public async void LoadPageAsync()
        {
            var isLoggedIn = false;
            var oAuthToken = "";
            try
            {
                oAuthToken = await SecureStorage.GetAsync("oAuthToken");
                if (!string.IsNullOrEmpty(oAuthToken))
                    isLoggedIn = true;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
            
            Device.BeginInvokeOnMainThread(async () =>
            {

                if (!isLoggedIn)
                    App.Current.MainPage = new LoginPage();
                else
                {
                    var api = new ApiService();
                    ApiService._AuthToken = oAuthToken;
                    var homeViewModel = await api.GetHomeView();

                    if (homeViewModel == null)
                        (App.Current as App).GoToLogIn();
                    else
                        ViewModels.AppViewModel.Instance.SetViewModel(homeViewModel);
                        App.Current.MainPage = new AppShell();
                }
            });
            
        }
    }
}