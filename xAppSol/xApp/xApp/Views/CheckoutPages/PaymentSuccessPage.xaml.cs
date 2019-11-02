using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using xApp.Services;

namespace xApp.Views.CheckoutPages
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentSuccessPage : ContentPage
    {
        public PaymentSuccessPage()
        {
            InitializeComponent();
            this.BindingContext = new PaySuccessViewModelEx();
            Task.Run(() =>(this.BindingContext as PaySuccessViewModelEx).OnLoad());
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