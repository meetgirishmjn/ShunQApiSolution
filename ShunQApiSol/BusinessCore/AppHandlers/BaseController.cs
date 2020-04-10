using BusinessCore;
using BusinessCore.AppHandlers.Contracts;
using BusinessCore.DataAccess.Contracts;
using BusinessCore.Enums;
using BusinessCore.Infrastructure.Caching;
using BusinessCore.Models;
using BusinessCore.Services;
using BusinessCore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;

namespace BusinessCore.AppHandlers
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

        protected void EnsureUserAuth()
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
                if (data?.Value != null)//for allowAnonymouse actions
                {
                    this.CurrentUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(data.Value);
                    UserId = this.CurrentUser.Id;
                    UserName = this.CurrentUser.Name;
                }
            }

        }

        protected IMembershipService CreateMembershipService()
        {
            return CreateService<IMembershipService>();
        }

        protected IEmailGateway CreateEmailService()
        {
            return CreateService<IEmailGateway>();
        }
        protected ISmsGateway CreateSMSService()
        {
            return CreateService<ISmsGateway>();
        }

        protected T CreateService<T>()
        {
            EnsureUserAuth();
            var type = typeof(T);

            var service = (T)serviceProvider.GetService(type);

            if (service is IDataContextable)
            {
                var dtx = (BusinessCore.DataAccess.CoreDbContext)serviceProvider.GetService(typeof(BusinessCore.DataAccess.CoreDbContext));

                (service as IDataContextable).ContextManager = new BusinessCore.DataAccess.DataContextManager(dtx);
                (service as IDataContextable).CurrentUser = new BusinessCore.Models.UserIdentity
                {
                    Id = UserId,
                    Name = UserName,
                    FullName = string.Empty
                };
            }

            return service;
        }

        protected IStoreService CreateStoreService()
        {
            return CreateService<IStoreService>();
        }
        protected ILoggerManager CreateLogger()
        {
            return CreateService<ILoggerManager>();
        }

        private ICacheManager _cache;
        protected ICacheManager Cache { get { return _cache != null ? _cache : CreateCacheService(); } }
        protected ICacheManager CreateCacheService()
        {
            _cache = CreateService<ICacheManager>();
            return _cache;
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

        protected string ReadAuthToken()
        {
            var token = "";
            if (Request.Headers.ContainsKey("Authorization"))
            {
                token = Request.Headers["Authorization"].ToString().Trim();
                if( token.StartsWith("bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = token.Substring(6).Trim();
                }
            }

            return token;
        }
    }
}
