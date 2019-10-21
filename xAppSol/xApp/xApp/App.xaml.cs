using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;
using xApp.Views;
using xApp.Views.CheckoutPages;

namespace xApp
{
    public partial class App : Application
    {
        const string SYNCFUSION_LICENSE_KEY = "MTU2NTgxQDMxMzcyZTMzMmUzMFZGUExvMkRXTys5cXliMkc3U2FzRS9IQXE3VVpaY2V4VFBkdDlxa2lCSXM9";
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public static string PAYU_LAUNCH_URL { get; } = "https://shunq-api-dev.azurewebsites.net/api/v1/merchant/pay/checkout-launch/v2";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SYNCFUSION_LICENSE_KEY);
            InitializeComponent();

            //Application.Current.Resources["Gray-200"] = "#ebecef";
            //Application.Current.Resources["Gray-900"] = "#333942";
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void onLoadPage(Page sender)
        {

        }

        public void GoToCheckoutPage()
        {

            MainPage = new NavigationPage(new LoadingPage(async (Page sender) =>
            {
                await MainPage.Navigation.PushAsync(new CheckoutPage());
            },"Checkout"));
        }

        public void GoToPayULaunch()
        {
             MainPage.Navigation.PushAsync( new WebViewPage());
        }
    }

    public class NavigationWorkGrs
    {
        private static NavigationPage _currentNavigationPage
        {
            get
            {
                return ((App)Application.Current).MainPage as NavigationPage;
            }
        }

        public static async Task ReplaceRoot(ContentPage page)
        {
            var root = _currentNavigationPage.Navigation.NavigationStack[0];
            _currentNavigationPage.Navigation.InsertPageBefore(page, root);
            await PopToRootAsync();
        }
        private static async Task PopToRootAsync()
        {
            while (_currentNavigationPage.Navigation.ModalStack.Count > 0)
            {
                await _currentNavigationPage.Navigation.PopModalAsync(false);
            }
            while (_currentNavigationPage.CurrentPage != _currentNavigationPage.Navigation.NavigationStack[0])
            {
                await _currentNavigationPage.PopAsync(false);
            }
        }
    }
}
