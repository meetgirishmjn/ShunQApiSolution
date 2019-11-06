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
            var vm = ViewModels.AppViewModel.Instance.GetViewModel<FilterPageViewModelEx>();
           
            if (vm == null)
                vm =  new FilterPageViewModelEx(ViewModels.AppViewModel.Instance.GetViewModel<SearchStoresViewModel>());
           
           this.BindingContext = vm;
        }

        private async void onApplyFilter_Clicked(object sender, EventArgs e)
        {
            try
            {
                var vm = this.BindingContext as FilterPageViewModelEx;
                ViewModels.AppViewModel.Instance.SetViewModel(vm);
                await Shell.Current.Navigation.PopAsync();
                MessagingCenter.Send(vm, "storeFilterApplied");

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
                ViewModels.AppViewModel.Instance.ClearViewModel<FilterPageViewModelEx>();
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