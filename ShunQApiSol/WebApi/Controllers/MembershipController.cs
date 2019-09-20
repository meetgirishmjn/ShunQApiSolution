using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore;
using BusinessCore.Extensions;
using BusinessCore.Models;
using BusinessCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.RequestModels;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/membership")]
    [ApiController]
    [Authorize]
    public class MembershipController : BaseController
    {
        public MembershipController(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig) : base(serviceProvider, appConfig)
        {
        }


        #region "Mobile Actions"

        [HttpPost("app/login")]
        [AllowAnonymous]
        public ActionResult<LoginSuccessModel> LogIn(LogInModel model)
        {
            var appId = base.ReadAppId();
            var deviceId = base.ReadDeviceId();

            if (appId.TrimAll().Length == 0)
                throw new BusinessException("Invalid App Source.");

            if (deviceId.TrimAll().Length==0)
                throw new BusinessException("Invalid Device Id.");
            var membership = base.CreateMembershipService();

            var isValid = membership.ValidateApp(appId);
            if (!isValid)
                throw new BusinessException("Invalid App Source (App-Id).");

            var result = new LoginSuccessModel();
            var user = membership.GetUser(model.UserName, model.Password);
            if (user == null)
            {
                result.IsValid = false;
                return result;
            }

            result.AuthToken = new TokenManager(membership).CreateToken(user.Name, user.Roles);
            
            membership.CreateSession(model.UserName, result.AuthToken, deviceId);

            result.IsValid = true;
            result.UserName = user.Name;
            result.FullName = user.FullName;

            return result;
        }

        [HttpPost("app/oauth/login")]
        [AllowAnonymous]
        public ActionResult<LoginSuccessModel> LoginFromOauth(LoginOauthModel model)
        {
            var appId = base.ReadAppId();
            var deviceId = base.ReadDeviceId();

            if (appId.TrimAll().Length == 0)
                throw new BusinessException("Invalid App Source.");

            if (deviceId.TrimAll().Length == 0)
                throw new BusinessException("Invalid Device Id.");
            var membership = base.CreateMembershipService();

            var isValid = membership.ValidateApp(appId);
            if (!isValid)
                throw new BusinessException("Invalid App Source (App-Id).");

            var result = new LoginSuccessModel();
            var user = new UserOAuthInfo()
            {
                OAuthProvider = model.ProviderName,
                Id = model.ProfileId,
                FullName = model.FullName,
                Email = model.Email,
                MobileNumber = model.Mobile,
            };
            user = membership.CreateOrGet(user);

            result.AuthToken = new TokenManager(membership).CreateToken(user.Id, user.Roles);

            membership.CreateSession(user.Email, result.AuthToken, deviceId);

            result.IsValid = true;
            result.UserName = user.Email;
            result.FullName = user.FullName;

            return result;
        }

        [HttpPost("app/register")]
        [AllowAnonymous]
        public ActionResult<UserInfo> RegisterUser(RegisterUserModel model)
        {

            var appId = base.ReadAppId();
            var deviceId = base.ReadDeviceId();

            var membership = base.CreateMembershipService();

            var isValid = membership.ValidateApp(appId);
            if (!isValid)
                throw new BusinessException("Invalid App Source (App-Id).");

            if (deviceId.TrimAll().Length == 0)
                throw new BusinessException("Invalid Device Id.");

            var user = new UserInfo
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                Email = model.Email,
            };
            user = membership.CreateUser(user, model.Password);

            return user;
        }

        [HttpPost("app/logout")]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            var membership = base.CreateMembershipService();
            membership.EndSession(ReadAuthToken());
            return Ok();
        }
        #endregion "Mobile Actions"


        [HttpGet("user-info")]
        public UserInfo GetCurrentUser()
        {
            if (UserId <= 0 || CurrentUser == null)
                throw new BusinessException("User info not available.");

            return CurrentUser;
        }

        static Random rand = new Random();
        [HttpPost("password/otp/{userName}")]
        [AllowAnonymous]
        public ActionResult CreateOTP(string userName)
        {

            var appId = base.ReadAppId();

            var membership = base.CreateMembershipService();

            var isValid = membership.ValidateApp(appId);
            if (!isValid)
                throw new BusinessException("Invalid App Source (App-Id).");

            var otp = rand.Next(10001, 99999);

            var user = membership.CreateOtp(userName, otp, "CHANGE_PASSWORD");
            if (user == null)
                throw new BusinessException("Invalid User-Name: " + userName);

            CreateEmailService().SendMail(user.Email, "ShunQ-App OTP for your password recovery", "Dear " + user.FullName + ", The One Time Passcode (OT) for your password recorvery is <br/>" + otp + "</br>");

            return Ok();
        }

        [HttpPost("change/password")]
        [AllowAnonymous]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var appId = base.ReadAppId();

            var membership = base.CreateMembershipService();

            var isValid = membership.ValidateApp(appId);
            if (!isValid)
                throw new BusinessException("Invalid App Source (App-Id).");

            var flag=membership.ChangePassword(model.UserName, model.Password, model.OTP);
            if(!flag)
                throw new BusinessException("Failed to change Password.");

            return Ok();
        }


    }
}
