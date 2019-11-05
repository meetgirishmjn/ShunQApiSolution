using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;
using xApp.ViewModels;
using xApp.ViewModels.Detail;
using xApp.Models.Detail;
using xApp.Views.Store;
using xApp.Views.StoreShop;
using xApp.Services;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewResult2 viewModel = null;
        IToastr toastr;
        public HomePage()
        {
            try
            {
                InitializeComponent();
                popupInProgress.Dismiss();
                this.viewModel= AppViewModel.Instance.GetViewModel<HomeViewResult2>();
                this.viewModel.AppView = AppViewModel.Instance;
                this.viewModel.IsQRCodeAnalysing = false;
                this.BindingContext = this.viewModel;
                //   this.ZXingScannerView1.OnScanResult+=
                this.viewModel.CartQRCodePopup = CartQRCodePopup;
                toastr = DependencyService.Get<IToastr>();
            }
            catch(Exception ex)
            {

            }
        }

        bool isClickProcessing = false;
        private async void OnStartShoppingClicked(object sender, EventArgs e)
        {
            if (isClickProcessing)
                return;
            isClickProcessing = true;
            try
            {

                var hasActiveCart = AppViewModel.Instance.HasActiveCart;
                if (!hasActiveCart)
                {
                    isClickProcessing = false;
                    CartQRCodePopup.Show();
                }
                else
                {
                    popupInProgress.Show();
                    var api = new ApiService();

                    var delayTask = Task.Delay(1000);
                    var app = api.RefreshAppViewModel();
                    await Task.WhenAll(delayTask, app);
                   
                    if (app == null)
                    {
                        isClickProcessing = false;
                        popupInProgress.Dismiss();
                        await DisplayAlert("Server not available", "Internal error occured. Try again.", "Ok");
                    }
                    else
                    {
                        var vm = ViewModels.AppViewModel.Instance.GetViewModel<StoreInfoViewModel>();
                        if (vm == null)
                        {
                            vm = await api.GetActiveStore();
                            ViewModels.AppViewModel.Instance.SetViewModel(vm);
                        }
                        isClickProcessing = false;
                        popupInProgress.Dismiss();
                        App.Current.MainPage = new NavigationPage(new StoreShopPage());
                    }
                }
            }
            catch (Exception ex)
            {
                isClickProcessing = false;
                popupInProgress.Dismiss();
                toastr.ShowError(ex.Message);
            }
        }

    }


}