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
        public HomePage()
        {
            try
            {
                InitializeComponent();
                this.viewModel= AppViewModel.Instance.GetViewModel<HomeViewResult2>();
                this.viewModel.AppView = AppViewModel.Instance;
                this.viewModel.IsQRCodeAnalysing = false;
                this.BindingContext = this.viewModel;
                //   this.ZXingScannerView1.OnScanResult+=
                this.viewModel.CartQRCodePopup = CartQRCodePopup;
            }
            catch(Exception ex)
            {

            }
        }

        private void OnStartShoppingClicked(object sender, EventArgs e)
        {
            var hasActiveCart = AppViewModel.Instance.HasActiveCart;
            if (!hasActiveCart)
            {
                CartQRCodePopup.Show();
            }
            else
            {
                var app = new ApiService().RefreshAppViewModel();
                if (app == null)
                {
                    DisplayAlert("Server not available", "Internal error occured. Try again.", "Ok");
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(new StoreShopPage());
                }
            }
        }

    }


}