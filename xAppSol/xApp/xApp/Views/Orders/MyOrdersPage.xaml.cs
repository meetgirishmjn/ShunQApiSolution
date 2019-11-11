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
            InitializeComponent();
            this.BindingContext = new MyOrdersViewModel();
            Task.Run(() =>
            {
                (this.BindingContext as MyOrdersViewModel).OnLoad();
            });
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
    }
}