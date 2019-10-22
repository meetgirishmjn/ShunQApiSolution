using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
            try
            {
                var token = await SecureStorage.GetAsync("oAuthToken");
                if (!string.IsNullOrEmpty(token))
                    isLoggedIn = true;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
            await Task.Delay(1000);
            Device.BeginInvokeOnMainThread(() =>
            {
                
                if (!isLoggedIn)
                    App.Current.MainPage = new LoginPage();
                else
                    App.Current.MainPage = new AppShell();
            });
            
        }
    }
}