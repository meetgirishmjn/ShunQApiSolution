using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class LoginSuccessModel
    {
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string AuthToken { get; set; }
        public string[] Roles { get; set; }

        public LoginSuccessModel()
        {
            this.Roles = new string[] { };
        }
    }
}
