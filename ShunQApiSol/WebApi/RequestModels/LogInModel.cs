using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RequestModels
{
    public class LogInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
    }

}
