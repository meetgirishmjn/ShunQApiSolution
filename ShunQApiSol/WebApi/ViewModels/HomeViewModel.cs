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
        public bool HasActiveCart { get; set; }
        public ShoppingCart Cart { get; set; }
        public UserInfo User { get; set; }

        public HomeViewModel()
        {
            this.BannerUrls = new string[] { };
        }
    }
}
