using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCore.Models;
using BusinessCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestModels;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/membership")]
    [ApiController]
    public class MembershipController : BaseController
    {
        public MembershipController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }


        #region "Mobile Actions"

        // GET api/values
        [HttpPost("app/login")]
        [AllowAnonymous]
        public ActionResult<LoginSuccessModel> LogIn(LogInModel model)
        {
            if (string.IsNullOrWhiteSpace(model.AppId))
                throw new BusinessException("Invalid App Source.");

            var membership = base.CreateMembershipService();

            //var appObj = membership.ReadOAuthApps().Where(o => o.AppId == credential.AppId).FirstOrDefault();
            //if (appObj == null)
            //{
            //    throw new BusinessException("Invalid App Source.");
            //}

            var result = new LoginSuccessModel();
            var user = membership.GetUser(model.UserName, model.Password);
            if (user == null)
            {
                result.IsValid = false;
                return result;
            }

            var token = new TokenManager(membership).CreateToken(user.Name, user.Roles);

            membership.CreateSession(model.UserName, token);

            result.UserName = user.Name;

            return result;
        }
        #endregion "Mobile Actions"
    }
}
