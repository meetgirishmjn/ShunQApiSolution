using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BusinessCore.Services.Contracts
{
    public interface IAuthTokenManager
    {
        ClaimsPrincipal Validate(string token);
        string CreateToken(string userName, string[] roles);
    }
}
