using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.ViewModels.Detail;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage_Slider : ContentView
    {
        public HomePage_Slider()
        {
            InitializeComponent();
            this.BindingContext = new DetailPageViewModel();
        }
    }
}