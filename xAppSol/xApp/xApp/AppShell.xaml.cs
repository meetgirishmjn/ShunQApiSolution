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
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("storeFilterPage", typeof(Views.Store.FilterPage));
            Routing.RegisterRoute("storeAddressSearchPage", typeof(Views.Store.AddressSearchPage));
            Routing.RegisterRoute("storeRoutePage", typeof(Views.Store.StoreRoutePage));
            Routing.RegisterRoute("myOrdersPage", typeof(Views.Orders.MyOrdersPage));
            
            this.BindingContext = AppViewModel.Instance;
        }

        protected override bool OnBackButtonPressed()
        {
            if (Application.Current.MainPage.GetType() == typeof(AppShell) && Shell.Current.Navigation.NavigationStack.Where(x => x != null).Any())
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                return true;
            }
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

        private async void menuMyOrders_Clicked(object sender, EventArgs e)
        {
           //await Current.Navigation.PushAsync(new Views.Orders.MyOrdersPage());
        }
    }
}
