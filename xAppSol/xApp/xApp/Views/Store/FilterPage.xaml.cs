using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
           this.BindingContext = new FilterPageViewModelEx(ViewModels.AppViewModel.Instance.GetViewModel<SearchStoresViewModel>());
        }

        private async void onApplyFilter_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.Navigation.PopAsync();
                MessagingCenter.Send(this.BindingContext as FilterPageViewModelEx, "storeFilterApplied");

            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error on filter",ex.Message, "Ok");
                });
            }
        }

        private async void btnClear_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.Navigation.PopAsync();
                MessagingCenter.Send(sender, "storeFilterCleared");

            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    DisplayAlert("Error on filter", ex.Message, "Ok");
                });
            }
        }
    }
}