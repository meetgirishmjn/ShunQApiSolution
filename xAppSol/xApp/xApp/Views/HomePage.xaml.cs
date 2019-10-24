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
using xApp.Views.Store;
using xApp.Views.StoreShop;

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            try
            {
                InitializeComponent();

                var vm = new DetailPageViewModel();
                vm.Categories = new ObservableCollection<CategoryTemp>()
            {
                new CategoryTemp
                {
                    Icon="https://cdn0storage0shunq0dev.blob.core.windows.net/images/Promos/Cat1.jpg",
                     Name="Cate 1",
                },
                  new CategoryTemp
                {
                   Icon="https://cdn0storage0shunq0dev.blob.core.windows.net/images/Promos/Cat2.jpg",
                     Name="Cate 2",
                },
                   new CategoryTemp
                {
                    Icon="https://cdn0storage0shunq0dev.blob.core.windows.net/images/Promos/Cat3.jpg",
                     Name="Cate 3",
                },
                  new CategoryTemp
                {
                   Icon="https://cdn0storage0shunq0dev.blob.core.windows.net/images/Promos/Cat4.jpg",
                     Name="Cate 4",
                }
            };

                this.BindingContext = vm;
            }
            catch(Exception ex)
            {

            }
            
        }

        private void OnStartShoppingClicked(object sender, EventArgs e)
        {
            App.Current.MainPage =  new NavigationPage(new StoreShopPage());
        }
    }
}