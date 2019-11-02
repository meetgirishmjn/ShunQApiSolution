using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.ViewModels;
using xApp.Views.CheckoutPages;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
      //  public ExtendedWebView WebView;
        public WebViewPage()
        {
            try
            {
                InitializeComponent();

                //Browser.BackgroundColor = Color.FromRgba(0, 0, 0, 0.75);
                //this.BackgroundColor = Browser.BackgroundColor;

                //activity_indicator.IsVisible = false;
                // activity_indicator.IsRunning = true;
                webView.IsVisible = true;
                webView.Source = xApp.App.PAYU_LAUNCH_URL;
            }catch(Exception ex)
            {

            }
        }

        private void webView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            try
            {
                activity_indicator.IsVisible = activity_indicator.IsRunning = false;
                activity_indicator.Margin = 0;
                if (e.Url.EndsWith("merchant/pay/callback/failure"))
                {
                    App.Current.MainPage.Navigation.InsertPageBefore(new PaymentFailedPage(), this);
                    App.Current.MainPage.Navigation.PopAsync();
                }
                else if (e.Url.EndsWith("merchant/pay/callback/success"))
                {
                    (App.Current as App).GoToPaymentSuccessPage();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}