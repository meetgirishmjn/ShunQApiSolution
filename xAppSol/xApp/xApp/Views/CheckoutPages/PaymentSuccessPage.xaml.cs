using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace xApp.Views.CheckoutPages
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentSuccessPage : ContentPage
    {
        public PaymentSuccessPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            (App.Current as App).GoToHome();
            return true;
        }
        private void btnGoHome_Clicked(object sender, System.EventArgs e)
        {
            (App.Current as App).GoToHome();
        }
    }
}