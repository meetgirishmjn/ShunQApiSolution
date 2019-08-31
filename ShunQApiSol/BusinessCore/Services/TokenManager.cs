using BusinessCore.Services.Contracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessCore.Services
{
   public class TokenManager:IAuthTokenManager
    {
        private IMembershipService _membership;

        public TokenManager(IMembershipService membership)
        {
            this._membership = membership;
        }

        public string CreateToken(string userName, string[] roles)
        {
            try
            {
                roles = roles ?? new string[] { };

                const string sec = "fsdr5ufgdrwr87tsvqf33564576yfdrq4879879gdrwr87tsvqf3355wfdr5ufgdrwr87tdherw436789085642sdr5ufgdrwr87tfdhdr5ufgdrwr87tjghggdrwr87";

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(sec);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var secToken = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(secToken);

                return tokenString;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public ClaimsPrincipal Validate(string token)
        {
            var user = _membership.GetUserSession(token);
            if (user == null)
                return null;

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

            var rolesStr = string.Join(",", user.Roles);
            claims.Add(new Claim(ClaimTypes.Role, rolesStr));

            var claimsIdentity = new ClaimsIdentity(claims, "authtype");

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
