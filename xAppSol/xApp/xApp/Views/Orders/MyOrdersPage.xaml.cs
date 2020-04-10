using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.Orders
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOrdersPage : ContentPage
    {
        public MyOrdersPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new MyOrdersViewModel();
                Task.Run(() =>
                {
                    (this.BindingContext as MyOrdersViewModel).OnLoad();
                });
            }catch(Exception ex)
            {

            }
        }


        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            return true;
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
        }

        bool isTabProcessing = false;
        bool isTabProcessed = false;
        private  void SfTabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
            try
            {
                if (e.Index != 1)
                    return;

                if (isTabProcessing || isTabProcessed)
                    return;

                isTabProcessing = true;
                myDiscardedOrderList.IsBusy = true;
                (this.BindingContext as MyOrdersViewModel).LoadDiscarded();
                isTabProcessed = true;
            }
            catch (Exception ex)
            {
                //  DisplayAlert(ex.Message);
                DependencyService.Get<IToastr>().ShowError(ex.Message);
            }
            finally
            {
                myDiscardedOrderList.IsBusy = false;
                isTabProcessing = false;
            }
        }
    }
}