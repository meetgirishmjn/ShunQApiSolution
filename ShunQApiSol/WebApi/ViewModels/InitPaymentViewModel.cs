using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class InitPaymentViewModel
    {

    }

    public class InitPayUViewModel
    {
        public float Amount { get; set; }
        public string TxnId { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public string firstName { get; set; }
        public string Email { get; set; }
        public string surl { get; set; }
        public string furl { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public bool IsDebug { get; set; }
        public string Key { get; set; }
        public string HashCode { get; set; }
        public string LogoUrl { get; set; }
        public string ColorCode { get; set; }
    }
}
