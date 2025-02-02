﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RequestModels
{
    public class RegisterUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string EmailOTP { get; set; }
        public string MobileOTP { get; set; }
        public string Password { get; set; }
        public string ReferralCode { get; set; }
    }
}
