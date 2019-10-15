using System;
using System.Collections.Generic;
using System.Text;

namespace xApp.ViewModels
{
    public class CarouselViewModel
    {
        public CarouselViewModel()
        {
            ImageCollection.Add(new CarouselModel("Promo1.png"));
            ImageCollection.Add(new CarouselModel("Promo2.jpg"));
            ImageCollection.Add(new CarouselModel("Promo3.jpg"));
            ImageCollection.Add(new CarouselModel("Promo4.jpg"));
        }
        private List<CarouselModel> imageCollection = new List<CarouselModel>();
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
    }

    public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
