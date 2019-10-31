using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.CheckoutPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new CheckoutViewModelEx();
                Task.Run(() =>
                {
                    (this.BindingContext as CheckoutViewModelEx).OnLoad();
                });
            }
            catch(Exception ex)
            {

            }
        }

        private void ContentPage_MeasureInvalidated(object sender, EventArgs e)
        {

        }
    }
}