using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.ViewModels;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace xApp.Views.StoreShop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreShopPage : ContentPage
    {
        public StoreShopPage()
        {
            try
            {
                InitializeComponent();
                renderScannerImage();
                //this.ProfileImage.Source = App.BaseImageUrl + "ContactProfileImage.png";
                this.ProfileImage.Source = "store_1001.jpg";
                Task.Run(async () =>
                {
                    await Task.Delay(2000);
                    var context = this.BindingContext as ContactProfileViewModel;
                    context.IsLoading = false;
                });
            }
            catch(Exception ex)
            {

            }
        }

        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", result.Text, "OK");
            });
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            return true;
        }


        ZXingScannerView zxingView;
        ZXingDefaultOverlay zxingOverlay;

        private void OnScanAdd_Clicked(object sender, EventArgs e)
        {
            var context = this.BindingContext as ContactProfileViewModel;

            if (context.IsScannerOn)
                return;

            context.IsScannerOn = true;
            context.IsScannerOff = false;

            zxingView = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
                IsScanning=true,
                IsAnalyzing=true
            };

            zxingView.OnScanResult += OnScanResult;

            zxingOverlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "",
                ShowFlashButton = false,
                AutomationId = "zxingDefaultOverlay",
            };

            zxingOverlay.FlashButtonClicked += (sender2, e2) => {
                zxingView.IsTorchOn = !zxingView.IsTorchOn;
            };

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            ScannerContainer.Children.Add(zxingView);
            ScannerContainer.Children.Add(zxingOverlay);
        }

        bool isAnalysing = false;
       public void OnScanResult(Result result)
        {
            if (isAnalysing)
                return;

            Device.BeginInvokeOnMainThread(async () => {

                if (!isAnalysing)
                {
                    isAnalysing = true;
                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    isAnalysing = false;
                }

                // Navigate away
                //  await Navigation.PopAsync();
            });
        }

        private void OnScanReturn_Clicked(object sender, EventArgs e)
        {
            OnScanCancel_Clicked(sender, e);
        }

        private void OnScanCancel_Clicked(object sender, EventArgs e)
        {
            var context = this.BindingContext as ContactProfileViewModel;
            if (context.IsScannerOff)
                return;


            context.IsScannerOn = false;
            context.IsScannerOff = true;
            zxingView = null;
            zxingOverlay = null;
            renderScannerImage();
        }
        
        private void renderScannerImage()
        {
            ScannerContainer.Children.Clear();
            var img = new Image()
            {
                Margin = 0,
                Aspect = Aspect.AspectFill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Source = "scan2.jpg"
            };
            ScannerContainer.Children.Add(img);
        }
    }
}