using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Contracts
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName,string password);
        bool ValidateApp(string appId);
        UserIdentity GetUser(string userName, string password);
        UserInfo GetUserSession(string token);
        UserInfo CreateUser(UserInfo model, string password);
        bool UpdateUser(UserInfo model);
        bool ChangePassword(string userName, string newPassword);
        void DeleteSession(string token);
        void CreateSession(string userName, string token,string deviceId);
        bool Test();
        void EndSession(string token);

        UserOAuthInfo CreateOrGet(UserOAuthInfo model);

        UserInfo GetUserByEmailOrMobile(string emailOrMobile);
        UserInfo GetUserByEmail(string email);
        UserInfo GetUserByMobile(string mobileNumber);
        bool ChangePassword(string userName, string newPassword, int otp);
        UserInfo CreateOtp(string emailOrMobile, int otpNumber, string optType);
        bool VerifyOTP(string emailOrMobile, int otpNumber, string optType);
    }
}
