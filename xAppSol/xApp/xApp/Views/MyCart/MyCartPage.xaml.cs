using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Services;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace xApp.Views.MyCart
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCartPage : ContentPage
    {
        public string PrevPage { get; set; }
        public MyCartPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new MyCartViewModelEx();
            }
            catch (Exception ex)
            {

            }
        }

        public MyCartPage(string prevPage) : this()
        {
            this.PrevPage = prevPage;
        }
        /// <summary>
        /// Invoked when view size is changed.
        /// </summary>
        /// <param name="width">The Width</param>
        /// <param name="height">The Height</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                   // ErrorImage.IsVisible = false;
                }
            }
            else
            {
               // ErrorImage.IsVisible = true;
            }
        }
    }

    //public class MyCartViewModel
    //{
    //    public bool IsCartEmpty
    //    {
    //        get { return Items.Count == 0; }
    //    }
    //    public bool IsCartNotEmpty { get {   return Items.Count>0; } }

    //    public List<CartItem> Items { get; set; } = new List<CartItem>();
    //}
    //public class CartItem
    //{
    //   public float TotalPrice { get; set; }
    //    public string ImageUrl { get; set; }
    //    public string Name { get; set; }
    //    public string Description { get; set; }

    //    public float ActualPrice { get; set; }
    //    public float DiscountAmount { get; set; }
    //    public float DiscountPercent { get; set; }
    //}
}