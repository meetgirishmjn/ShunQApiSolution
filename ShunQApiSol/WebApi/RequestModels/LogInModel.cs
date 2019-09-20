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
        public int OTP { get; set; }
    }

    public class LoginOauthModel
    {
        public string ProviderName { get; set; }
        public string ProfileId { get; set; }
        //public string UserId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; }
    }
}
