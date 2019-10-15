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

namespace xApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            ObservableCollection<SfCarouselItem> carouselItems = new ObservableCollection<SfCarouselItem>();
            carouselItems.Add(new SfCarouselItem() { ImageName = "Promo1.png" });
            carouselItems.Add(new SfCarouselItem() { ImageName = "Promo2.jpg" });
            carouselItems.Add(new SfCarouselItem() { ImageName = "Promo3.jpg" });
            carouselItems.Add(new SfCarouselItem() { ImageName = "Promo4.jpg" });

            var carouselModel = new List<CarouselModel>
            {
                new CarouselModel("Promo1.png"),
                new CarouselModel("Promo2.jpg"),
                new CarouselModel("Promo3.jpg"),
                new CarouselModel("Promo4.jpg"),
            };

            //var dataTemplate = new DataTemplate(() =>
            //{
            //    var grid = new Grid();
            //    var nameLabel = new Image();
            //    nameLabel.SetBinding(Image.SourceProperty, "Image");
            //    grid.Children.Add(nameLabel);
            //    return grid;
            //});

            //carousel1.ItemWidth = 170;
            //carousel1.ItemHeight = 200;

            //////carousel1.ItemTemplate = dataTemplate;
            //carousel1.ItemsSource = carouselModel;
            //var vm = new CarouselViewModel()
            //{
            //    ImageCollection = carouselModel
            //};

            //this.BindingContext = vm;
        }
    }
}