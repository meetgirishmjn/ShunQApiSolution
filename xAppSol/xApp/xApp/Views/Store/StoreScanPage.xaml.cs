using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreScanPage : ContentPage
    {
        public StoreScanPage()
        {
            try
            {
                InitializeComponent();
                this.ProfileImage.Source = App.BaseImageUrl + "ContactProfileImage.png";
            }
            catch(Exception ex)
            {

            }
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new AppShell();
            return true;
        }

    }
}