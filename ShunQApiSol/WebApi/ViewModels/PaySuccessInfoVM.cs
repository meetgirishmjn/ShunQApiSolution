using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class PaySuccessInfoVM
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string CheckoutCode { get; set; }
    }
}
