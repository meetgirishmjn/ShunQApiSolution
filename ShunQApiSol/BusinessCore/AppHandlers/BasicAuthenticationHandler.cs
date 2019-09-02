using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using BusinessCore.Services;
using Newtonsoft.Json;
using BusinessCore.Services.Contracts;

namespace BusinessCore.AppHandlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        IAdminService adminService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                                           ILoggerFactory logger,
                                           UrlEncoder encoder,
                                           ISystemClock clock, IAdminService adminService)
             : base(options, logger, encoder, clock)
        {
            this.adminService = adminService;
        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            var user = "";
            var userData = "{}";
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                //var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                //var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                //var username = credentials[0];
                //var password = credentials[1];

                var userInfo = adminService.Authenticate(authHeader.Parameter);

                if(userInfo==null)
                    return AuthenticateResult.Fail("Invalid Authorization Token");

                user = userInfo.Name;
                userData = JsonConvert.SerializeObject(userInfo);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
           
            if (user == "")
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new[] {
                new Claim(ClaimTypes.UserData, userData),
                new Claim(ClaimTypes.Name, user),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
