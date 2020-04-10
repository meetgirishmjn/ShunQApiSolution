using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using xApp.Services;
using xApp.ViewModels;

namespace xApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        IToastr toastr;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("storeFilterPage", typeof(Views.Store.FilterPage));
            Routing.RegisterRoute("storeAddressSearchPage", typeof(Views.Store.AddressSearchPage));
            Routing.RegisterRoute("storeRoutePage", typeof(Views.Store.StoreRoutePage));
            Routing.RegisterRoute("myOrdersPage", typeof(Views.Orders.MyOrdersPage));
            
            this.BindingContext = AppViewModel.Instance;

            toastr = DependencyService.Get<IToastr>();
        }

         bool isBackBtnProcessing = false;
        bool isSecondBackAttempt = false;
        const bool blockExist = true;
       async void  waitForSecondBackAttemp()
        {
           await Task.Delay(2000);
            isSecondBackAttempt = false;
        }
        protected  override bool OnBackButtonPressed()
        {
            if (isBackBtnProcessing)
                return blockExist;

            isBackBtnProcessing = true;
            if (isSecondBackAttempt)
            {
                if (AppViewModel.Instance.HasActiveCart)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Exit!", "Do you want to discard cart?", "Yes", "No");
                        if (result)
                        {
                            await new ApiService().DiscardCart();
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        else
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                    });
                    return blockExist;
                }
                else
                {
                    isBackBtnProcessing = false;
                    return base.OnBackButtonPressed();
                }
            }
            else
            {
                isSecondBackAttempt = true;
                toastr.ShowInfo("Press again to exit");
                waitForSecondBackAttemp();
                isBackBtnProcessing = false;
                return blockExist;
            }
            //if (Application.Current.MainPage.GetType() == typeof(AppShell) && Shell.Current.Navigation.NavigationStack.Where(x => x != null).Any())
            //{
            //    return base.OnBackButtonPressed();
            //}
            //else
            //{
            //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            //    return true;
            //}
        }

      
        private  void menuLogout_Clicked(object sender, EventArgs e)
        {
            try
            {
                var api = new ApiService();

                SecureStorage.Remove("oAuthToken");
                (App.Current as App).GoToLogIn();
                Task.Run(async () =>
                {
                    var flag = await api.Logout();
                });
            }
            catch (Exception ex)
            {
                var toastr = DependencyService.Get<IToastr>();
                toastr.ShowError(ex.Message);
            }
        }

        private   void menuMyOrders_Clicked(object sender, EventArgs e)
        {
            (App.Current as App).GotMyOrders();
        }
    }
}
