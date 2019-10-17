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

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreScanPage : ContentPage
    {
        public StoreScanPage()
        {
            try
            {
                InitializeComponent();
                renderScannerImage();
                this.ProfileImage.Source = App.BaseImageUrl + "ContactProfileImage.png";
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
            };

            zxingView.OnScanResult += (result) =>
               Device.BeginInvokeOnMainThread(async () => {

                   // Stop analysis until we navigate away so we don't keep reading barcodes
                   zxingView.IsAnalyzing = false;

                    // Show an alert
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");

                    // Navigate away
                  //  await Navigation.PopAsync();
               });

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