using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xApp.Views.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        // public ObservableCollection<CategoryItem> CategoryList { get; } = new ObservableCollection<CategoryItem>();
        public List<CategoryItem> CategoryList;

        public CategoryPage()
        {
            try
            {
                this.CategoryList = new List<CategoryItem>()
            {

                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
                new CategoryItem{ Name="Favourites",Description = "MY ALBUM",ImageUrl = "Album1.png" ,ItemCount=21 },
                new CategoryItem{ Name="People",Description = "OTHER ALBUM",ImageUrl = "Album2.png" ,ItemCount=12 },
            };
                InitializeComponent();
               ListView.ItemsSource = CategoryList;
              //  EmployeeView.ItemsSource = CategoryList;
            }
            catch(Exception ex)
            {

            }
           
        }
    }

    public class CategoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ItemCount { get; set; }
    }
}