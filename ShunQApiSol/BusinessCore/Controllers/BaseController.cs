using BusinessCore.DataAccess.Contracts;
using BusinessCore.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        IServiceProvider serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {
            this.UserName = string.Empty;
            this.serviceProvider = serviceProvider;
        }

        protected IMembershipService CreateMembershipService()
        {
            if (UserId <=0 && Request.Headers.ContainsKey("user-id"))
                UserId = long.Parse( Request.Headers["user-id"].ToString());

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

        protected string ReadAppId()
        {
            var appId = "";
            if (Request.Headers.ContainsKey("app-id"))
                appId = Request.Headers.ContainsKey("appid").ToString();

            return appId;
        }

        protected string ReadDeviceId()
        {
            var deviceId = "";
            if (Request.Headers.ContainsKey("device-id"))
                deviceId = Request.Headers.ContainsKey("device-id").ToString();

            return deviceId;
        }
    }
}
