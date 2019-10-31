using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xApp.Models.Detail;

namespace xApp.Views.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreSearchPage : ContentPage
    {
        
        public StoreSearchPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new CatalogPageViewModel();
            }
            catch(Exception ex)
            {

            }
        
        }
    }

    public class CatalogPageViewModel
    {
        private int cartItemCount = 10;
        public int CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }
            set
            {
                this.cartItemCount = value;
            }
        }

        public ObservableCollection<Product> Products
        {
            get; set;
        }

        public CatalogPageViewModel()
        {
            this.Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Id = 1,
                    PreviewImage =App.BaseImageUrl + "Image1.png",
                    Name = "Full-Length Skirt",
                    Summary = "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
                    Description = "This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days.",
                    ActualPrice = 220,
                    DiscountPercent = 15,
                    OverallRating = 5,
                    PreviewImages = new List<string> { "Image1.png", "Image1.png", "Image1.png", "Image1.png", "Image1.png" },
                    Reviews = new ObservableCollection<Review>
                    {
                        new Review
                        {
                            ProfileImage = "ProfileImage10.png",
                            CustomerName = "Serina Williams",
                            Comment = "Greatest purchase I have ever made in my life.",
                            Rating = 5,
                            Images = new List<string> { "Image1.png", "Image1.png", "Image1.png" },
                            ReviewedDate = DateTime.Parse("2019-12-29")
                        },
                    }
                }
            };
        }
    }
}