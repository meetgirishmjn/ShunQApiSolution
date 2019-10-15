using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;
using xApp.Views;

namespace xApp
{
    public partial class App : Application
    {
        const string SYNCFUSION_LICENSE_KEY = "MTU2NTgxQDMxMzcyZTMzMmUzMFZGUExvMkRXTys5cXliMkc3U2FzRS9IQXE3VVpaY2V4VFBkdDlxa2lCSXM9";
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
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
    }
}
