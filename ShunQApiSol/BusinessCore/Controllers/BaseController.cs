using BusinessCore;
using BusinessCore.DataAccess.Contracts;
using BusinessCore.Enums;
using BusinessCore.Models;
using BusinessCore.Services;
using BusinessCore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public UserInfo CurrentUser { get; set; }

        public AppConfig AppConfig { get; set; }

        IServiceProvider serviceProvider;

        public BaseController(IServiceProvider serviceProvider, IOptions<AppConfig> appConfig)
        {
            this.UserName = string.Empty;
            this.serviceProvider = serviceProvider;
            this.AppConfig = appConfig.Value;
        }

        private void ensureUserAuth()
        {
            if (UserId > 0)
                return;

            if (!this.AppConfig.AuthorizationEnabled)
            {
                UserId = 1;
                UserName = AppConfig.ADMIN_USER_NAME;
                this.CurrentUser = new UserInfo
                {
                    Id = UserId,
                    Name = UserName,
                    Roles = new string[] { RoleNames.Administrator.ToString() }
                };
            }
            else
            {

                var data = Request.HttpContext.User.Claims.FirstOrDefault(o => o.Type == ClaimTypes.UserData);
                this.CurrentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(data.Value);
                UserId = this.CurrentUser.Id;
                UserName = this.CurrentUser.Name;
            }

        }

        protected IMembershipService CreateMembershipService()
        {
            ensureUserAuth();
            var service = (IMembershipService)serviceProvider.GetService(typeof(IMembershipService));
            var dtx = (BusinessCore.DataAccess.CoreDbContext)serviceProvider.GetService(typeof(BusinessCore.DataAccess.CoreDbContext));
            (service as IDataContextable).ContextManager = new BusinessCore.DataAccess.DataContextManager(dtx);
            (service as IDataContextable).CurrentUser = new BusinessCore.Models.UserIdentity
            {
                Id = UserId,
                Name = UserName,
                FullName = string.Empty
            };
            return service;
        }

        protected IStoreService CreateStoreService()
        {
            ensureUserAuth();

            var service = (IStoreService)serviceProvider.GetService(typeof(IStoreService));
            var dtx = (BusinessCore.DataAccess.CoreDbContext)serviceProvider.GetService(typeof(BusinessCore.DataAccess.CoreDbContext));
            (service as IDataContextable).ContextManager = new BusinessCore.DataAccess.DataContextManager(dtx);
            (service as IDataContextable).CurrentUser = new BusinessCore.Models.UserIdentity
            {
                Id = UserId,
                Name = UserName,
                FullName = string.Empty
            };
            return service;
        }

        protected string ReadAppId()
        {
            var appId = "";
            if (Request.Headers.ContainsKey("app-id"))
                appId = Request.Headers["app-id"].ToString();

            return appId;
        }

        protected string ReadDeviceId()
        {
            var deviceId = "";
            if (Request.Headers.ContainsKey("device-id"))
                deviceId = Request.Headers["device-id"].ToString();

            return deviceId;
        }
    }
}
