using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.Contracts
{
    public interface IMembershipService
    {
        bool ValidateUser(string userName,string password);
        User GetUser(string userName, string password);
        User GetUserSession(string token);
        void CreateSession(string userName, string token);
        bool Test();
    }
}
