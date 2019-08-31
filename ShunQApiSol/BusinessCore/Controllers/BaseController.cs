using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string UserId { get; set; }
        IServiceProvider serviceProvider;

        public BaseController(IServiceProvider serviceProvider)
        {
            this.UserId = string.Empty;
            this.serviceProvider = serviceProvider;
        }

        protected IMembershipService CreateMembershipService()
        {
            if (UserId == string.Empty && Request.Headers.ContainsKey("user-id"))
                UserId = Request.Headers["user-id"].ToString();

            var service = (IMembershipService)serviceProvider.GetService(typeof(IMembershipService));
            var dtx = (BusinessCore.DataAccess.CoreDbContext)serviceProvider.GetService(typeof(BusinessCore.DataAccess.CoreDbContext));
            (service as IDataContextable).ContextManager = new BusinessCore.DataAccess.DataContextManager(dtx);
            (service as IServiceIdentity).CurrentUser = new BusinessCore.Models.User
            {
                Id = UserId,
                Name = string.Empty,
                FullName = string.Empty
            };
            return service;
        }

    }
}
