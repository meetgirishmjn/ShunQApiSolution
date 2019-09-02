using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Services.Contracts
{
   public interface IAdminService
    {
        UserInfo Authenticate(string authToken);
    }
}
