using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace xApp.Views.CheckoutPages
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentFailedPage : ContentPage
    {
        public PaymentFailedPage()
        {
            InitializeComponent();
        }

        private void btnGoback_Clicked(object sender, System.EventArgs e)
        {
            (App.Current as App).GoBack();
        }
    }
}