using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xApp.Views
{
    public delegate void OnLoadPageCallback(Page sender);

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        OnLoadPageCallback callback;
        public LoadingPage(OnLoadPageCallback callback) :this()
        {
            this.callback = callback;
        }
        public LoadingPage()
        {
            InitializeComponent();
            callback = null;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000);
            if (this.callback != null)
                callback(this);
        }
    }

  
}