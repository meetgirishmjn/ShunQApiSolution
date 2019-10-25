using System;
using System.Collections.Generic;
using System.Text;
using xApp.Models;

namespace xApp.Services
{
    public partial class HomeViewResult
    {
        public List<ServiceItem> AllServices { get; set; }= new List<ServiceItem>
            {
                new ServiceItem
                {
                    Name = "History",
                    Icon = "\uf1da"
                },
                new ServiceItem
                {
                    Name = "Notification",
                    Icon = "\uf0f3"
                },
                new ServiceItem
                {
                    Name = "Categories",
                    Icon = "\uf5fd"
                },
                new ServiceItem
                {
                    Name = "Reward",
                    Icon = "\uf091"
                },
                new ServiceItem
                {
                    Name = "Review Expenses",
                    Icon = "\uf3d1"
                },
                 new ServiceItem
                {
                    Name = "Offers",
                    Icon = "\uf79c"
                }
            };
    }
}
