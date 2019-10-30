using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;
using xApp.ViewModels;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace xApp.Views.StoreShop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreShopPage : ContentPage
    {

        IToastr toastr;
        public StoreShopPage()
        {
            try
            {
                InitializeComponent();
                var zxingView = new ZXingScannerView
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    AutomationId = "zxingScannerView",
                    IsScanning = true,
                    IsAnalyzing = true
                };
                ScannerContainer.Children.Insert(0,zxingView);

                toastr = DependencyService.Get<IToastr>();

                var vm = ViewModels.AppViewModel.Instance.GetViewModel<StoreInfoViewModel>();
                if (vm == null)
                {
                    toastr.ShowError("Store Info not available. Try again.");
                    (App.Current as App).GoToHome();
                }
                else
                {
                    zxingView.ScanResultCommand = vm.ScanResultCommand;
                    this.ProfileImage.Source = vm.BannerImageUrl;
                    this.BindingContext = vm;
                }

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

        private void OnHome_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            return true;
        }

        private void OnCheckout_Clicked(object sender, EventArgs e)
        {
            (App.Current as App).GoToCheckoutPage();
        }

        //public void OnScanResult(Result result)
        //{
        //    if (isAnalysing)
        //        return;

        //    Device.BeginInvokeOnMainThread(async () => {

        //        if (!isAnalysing)
        //        {
        //            isAnalysing = true;
        //            // Show an alert
        //            await DisplayAlert("Scanned Barcode", result.Text, "OK");
        //            isAnalysing = false;
        //        }

        //        // Navigate away
        //        //  await Navigation.PopAsync();
        //    });
        //}

        //  ZXingScannerView zxingView;

        //private void OnScanAdd_Clicked(object sender, EventArgs e)
        //{

        //    if (vm.IsLoading)
        //        return;
        //    if (vm.IsScannerOn)
        //        return;

        //    vm.IsScannerOn = true;
        //    ensureScannerOverlay();
        //}

        //private void OnScanReturn_Clicked(object sender, EventArgs e)
        //{
        //    OnScanCancel_Clicked(sender, e);
        //}

        //private void OnScanCancel_Clicked(object sender, EventArgs e)
        //{
        //    if (vm.IsLoading)
        //        return;

        //    vm.IsScannerOn = false;
        //    ensureScannerOverlay();
        //}



        //private void ensureScannerOverlay()
        //{
        //    if (vm.IsScannerOff)
        //    {
        //        if(ScannerContainer.Children.Count>1)
        //            ScannerContainer.Children.RemoveAt(1);

        //        zxingOverlay = null;
        //    }
        //    else
        //    {
        //        zxingOverlay = new ZXingDefaultOverlay
        //        {
        //            TopText = "Hold your phone up to the barcode",
        //            BottomText = "",
        //            ShowFlashButton = false,
        //            AutomationId = "zxingDefaultOverlay",
        //        };
        //        ScannerContainer.Children.Add(zxingOverlay);
        //        //zxingOverlay.FlashButtonClicked += (sender2, e2) => {
        //        //   // zxingView.IsTorchOn = !zxingView.IsTorchOn;
        //        //};


        //    }
        //}

    }
}