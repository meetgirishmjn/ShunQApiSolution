using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class AppViewModel
    {
        public bool HasActiveCart { get; set; }
        public int CartItemCount { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
