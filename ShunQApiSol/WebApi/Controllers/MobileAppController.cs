using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/mobile")]
    [ApiController]
    public class MobileAppController : BaseController
    {
        public MobileAppController(IServiceProvider serviceProvider):base(serviceProvider)
        {
        }

        [HttpGet("Ver")]
        public VersionViewModel Ver()
        {
            var membsership = base.CreateMembershipService();

            var dbStatus = "ok";
            try
            {
                membsership.Test();
            }catch(Exception ex)
            {
                dbStatus = ex.Message + ex.InnerException?.Message;
            }

            return new VersionViewModel
            {
                DbStatus = dbStatus,
                Status = "ok",
                Version = "1.0.0",
                Values = new Dictionary<string, string>()
                {
                    
                }
            };
        }
    }
}
