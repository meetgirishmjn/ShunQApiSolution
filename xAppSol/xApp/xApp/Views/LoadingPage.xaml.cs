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
        bool isCallbackUsed = false;
        public LoadingPage(OnLoadPageCallback callback,string title="") :this()
        {
            this.callback = callback;
            this.isCallbackUsed = false;
            if (!string.IsNullOrEmpty(title))
                this.Title = title;
        }
        public LoadingPage()
        {
            InitializeComponent();
            callback = null;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (!isCallbackUsed)
            {
                await Task.Delay(3000);
                if (this.callback != null)
                {
                    isCallbackUsed = true;
                    callback(this);
                }
            }
        }
    }

  
}