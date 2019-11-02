using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.ViewModels;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public ExtendedWebView WebView;
        public WebViewPage()
        {
            try
            {
                InitializeComponent();

                //Browser.BackgroundColor = Color.FromRgba(0, 0, 0, 0.75);
                //this.BackgroundColor = Browser.BackgroundColor;

                //activity_indicator.IsVisible = false;
                // activity_indicator.IsRunning = true;
                Browser.IsVisible = true;
                Browser.Source = xApp.App.PAYU_LAUNCH_URL;
            }catch(Exception ex)
            {

            }
        }
    }
}