using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            }catch(Exception ex)
            {

            }
        }

        private void ContentPage_MeasureInvalidated(object sender, EventArgs e)
        {

        }
    }
}