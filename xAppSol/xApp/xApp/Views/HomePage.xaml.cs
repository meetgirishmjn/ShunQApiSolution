using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfCarousel.XForms;
using System.Collections.ObjectModel;
using xApp.ViewModels;
using xApp.ViewModels.Detail;
using xApp.Models.Detail;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public Uri TImg { get; set; }
        public HomePage()
        {
            try
            {
                this.TImg = new Uri("http://i0.wp.com/vanillicon.com/b41c9603fd56030185e177f2c0e43981_200.png");
                InitializeComponent();

                var vm = new DetailPageViewModel();
                vm.Categories = new ObservableCollection<Category>()
            {
                new Category
                {
                    Icon="tab_feed.png",
                     Name="Cate 1", }
                //},
                //  new Category
                //{
                //    Icon="tab_feed.png",
                //     Name="Cate 3",
                //}
            };

                this.BindingContext = vm;
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}