using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class HomeViewModel
    {
        public string[] BannerUrls { get; set; }
        public TileSection[] TileSections { get; set; }
        public bool HasActiveCart { get; set; }
        public ShoppingCart Cart { get; set; }
        public UserInfo User { get; set; }

        public HomeViewModel()
        {
            this.BannerUrls = new string[] { };
            this.TileSections = new TileSection[] { };
        }

        public class TileSection
        {
            public string Title { get; set; }
            public Tile[] Tiles { get; set; }
        }

        public class Tile
        {
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string DetailUrl { get; set; }
        }

        
    }
}
