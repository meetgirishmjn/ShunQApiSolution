using BusinessCore.DataAccess.Contracts;
using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessCore.Services.Contracts;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BusinessCore.Services
{
   public class AdminService: IAdminService
    {
        private string connectionString { get; set; }

        public AdminService(string conStr)
        {
            this.connectionString = conStr;
        }

        private DataAccess.CoreDbContext getContext()
        {
            var options = SqlServerDbContextOptionsExtensions.UseSqlServer<DataAccess.CoreDbContext>(new DbContextOptionsBuilder<DataAccess.CoreDbContext>(), this.connectionString).Options;
            return new DataAccess.CoreDbContext(options);
        }


        public UserInfo Authenticate(string authToken)
        {
            var context = getContext();
            var model = (from o in context.LogInSessions
                         where o.AuthToken == authToken && !o.IsDeleted
                         && o.ExpireOn > DateTime.Now   //if not expired
                         && !o.UserMaster.IsDeleted
                         select new UserInfo
                         {
                             Id = o.UserMaster.Id,
                             Name = o.UserMaster.Name,
                             FirstName = o.UserMaster.FirstName,
                             LastName = o.UserMaster.LastName,
                             FullName = o.UserMaster.FullName,
                             MobileNumber = o.UserMaster.MobileNumber,
                             Email = o.UserMaster.Email,
                             Gender = o.UserMaster.Gender,
                             ImageId = o.UserMaster.ImageId,
                             CompanyId = o.UserMaster.CompanyId,
                             EmailVerified = o.UserMaster.EmailVerified,
                             MobileVerified = o.UserMaster.MobileVerified,
                             IsActive = o.UserMaster.IsActive,
                             CreatedOn = o.UserMaster.CreatedOn,
                             CreatedBy = o.UserMaster.CreatedBy,
                             UpdatedBy = o.UserMaster.UpdatedBy,
                             UpdatedOn = o.UserMaster.UpdatedOn,
                             Roles = o.UserMaster.UserRoles.Select(r => r.RoleMaster.Name).ToArray()
                         }).FirstOrDefault();
            return model;
        }
    }
}
