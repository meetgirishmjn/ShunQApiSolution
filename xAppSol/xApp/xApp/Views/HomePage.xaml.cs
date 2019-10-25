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
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = AppViewModel.Instance.GetViewModel<HomeViewResult>();
        }

        private void OnStartShoppingClicked(object sender, EventArgs e)
        {
            App.Current.MainPage =  new NavigationPage(new StoreShopPage());
        }
    }


}