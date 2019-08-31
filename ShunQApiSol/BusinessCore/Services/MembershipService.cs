using BusinessCore.Contracts;
using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BusinessCore.Services
{
    public class MembershipService : IMembershipService, IDataContextable
    {
        public User CurrentUser { get; set; }
        public IDataContextManager ContextManager { get; set; }

        private const string PWD_ENCRYPTION_KEY = "4309newk43DJE";
        public const int TOKEN_EXPIRATION_SEC = 172800 * 100;

        public bool ValidateUser(string userName, string password)
        {
            var context = ContextManager.GetContext();

                var userDb = context.UserMasters.Where(o => !o.IsDeleted && o.Name == userName)
                     .Select(o => new
                     {
                         o.Name,
                         o.Password
                     }).FirstOrDefault();

                if (userDb == null)
                    return false;

                if (userDb.Password == encryptPassword(password))
                    return true;

            return false;
        }

        public User GetUser(string userName, string password)
        {
            var context = ContextManager.GetContext();
            userName = userName.TrimAll();
            var encryptedPassword = encryptPassword(password);
            var userDb = context.UserMasters.Where(o => !o.IsDeleted && o.Name.ToLower() == userName.ToLower() && o.Password == encryptedPassword)
                .Select(o => new
                {
                    o.Id,
                    o.Name,
                    o.FullName,
                    o.CompanyId,
                    Roles = o.UserRoles.Select(r => r.RoleMaster.Name).ToArray()
                }).SingleOrDefault();

            if (userDb == null)
                return null;

            var user = new User()
            {
                Id = userDb.Id,
                Name = userDb.Name,
                FullName = userDb.FullName,
                CompanyId = userDb.CompanyId,
                Roles = userDb.Roles
            };

            return user;
        }

        public void CreateSession(string userName, string token)
        {
            var context = ContextManager.GetContext();

            var modelDb = context.UserMasters.Where(o => o.Name == userName).FirstOrDefault();
            if (modelDb == null)
                throw new BusinessException("User does not exists.");

            var objDb = new DataAccess.Models.LogInSession();
            objDb.Id = Guid.NewGuid();
            objDb.UserMasterId = modelDb.Id;
            objDb.CompanyId = modelDb.CompanyId;
            objDb.AuthToken = token;
            objDb.ExpireOn = DateTime.MaxValue;
            objDb.CreatedOn = DateTime.Now;
            objDb.IsDeleted = false;

            context.LogInSessions.Add(objDb);
            context.SaveChanges();
        }

        public User GetUserSession(string token)
        {
            throw new NotImplementedException();
        }

        public bool Test()
        {
            var context = ContextManager.GetContext();
            // return context.Products.Any();
            return true;
        }

        #region "private Methods"
        private string encryptPassword(string password)
        {
            var encryptedPassword = "";
            string EncryptionKey = PWD_ENCRYPTION_KEY;  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (var encryptor = System.Security.Cryptography.Aes.Create())
            {
                var pdb = new System.Security.Cryptography.Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new System.Security.Cryptography.CryptoStream(ms, encryptor.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptedPassword = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptedPassword;
        }

        #endregion "private Methods"

    }
}
