using BusinessCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessCore.Extensions;
using Microsoft.EntityFrameworkCore;
using BusinessCore.Services.Contracts;
using BusinessCore.DataAccess.Contracts;

namespace BusinessCore.Services
{
    public class MembershipService : IMembershipService, IDataContextable
    {
        public UserIdentity CurrentUser { get; set; }
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

        public UserIdentity GetUser(string userName, string password)
        {
            var context = ContextManager.GetContext();
            userName = userName.TrimAll();

            if (userName.Length == 0 || string.IsNullOrEmpty(password))
                return null;

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

            var user = new UserIdentity()
            {
                Id = userDb.Id,
                Name = userDb.Name,
                FullName = userDb.FullName,
                CompanyId = userDb.CompanyId,
                Roles = userDb.Roles
            };

            return user;
        }

        public void CreateSession(string userName, string token,string deviceId="BROWSER")
        {
            var context = ContextManager.GetContext();

            var modelDb = context.UserMasters.Where(o => o.Name == userName).FirstOrDefault();
            if (modelDb == null)
                throw new BusinessException("User does not exists.");

            var objDb = new DataAccess.DbModels.LogInSession();
            objDb.Id = Guid.NewGuid();
            objDb.UserMasterId = modelDb.Id;
            objDb.DeviceId = deviceId;
            objDb.CompanyId = modelDb.CompanyId;
            objDb.AuthToken = token;
            objDb.ExpireOn = DateTime.MaxValue;
            objDb.CreatedOn = DateTime.Now;
            objDb.IsDeleted = false;

            context.LogInSessions.Add(objDb);
            context.SaveChanges();
        }

        public void DeleteSession(string token)
        {
            var context = ContextManager.GetContext();

            var objDb = context.LogInSessions.Where(o => o.AuthToken == token).FirstOrDefault();
            if (objDb != null)
            {
                objDb.IsDeleted = true;
                objDb.UpdatedOn = DateTime.Now;
                context.SaveChanges();
            }
        }

        public UserInfo GetUserSession(string token)
        {
            var context = ContextManager.GetContext();

            var model = (from o in context.LogInSessions
                         where o.AuthToken == token && !o.IsDeleted
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


        public UserInfo CreateUser(UserInfo model,string password)
        {
            var valResults = validatePassword(password);
            if (valResults.Any())
                throw new BusinessException(valResults[0].Message);

            valResults = validate(model, false);
            if (valResults.Any())
                throw new BusinessException(valResults[0].Message);

            var context = ContextManager.GetContext();

            var objDb = new DataAccess.DbModels.UserMaster();
            objDb.Name = model.MobileNumber;
            objDb.FirstName = model.FirstName.ToAlphaNum();
            objDb.LastName = model.LastName.ToAlphaNum();
            objDb.FullName = objDb.FirstName + " " + objDb.LastName;
            objDb.Email = model.Email;
            objDb.MobileNumber = model.MobileNumber;
            objDb.IsActive = true;
            objDb.Password = encryptPassword(password);
            objDb.CreatedOn = DateTime.Now;
            objDb.CreatedBy = 1;
            objDb.IsDeleted = false;
            objDb.Gender = objDb.ImageId = string.Empty;
            context.UserMasters.Add(objDb);

            context.SaveChanges();
            model.Id = objDb.Id;

            return model;
        }

        public bool UpdateUser(UserInfo model)
        {
            var valResults = validate(model, true);
            if (valResults.Any())
                throw new BusinessException(valResults[0].Message);

            var context = ContextManager.GetContext();

            var isUpdated = false;
            var firstName = model.FirstName.ToAlphaNum();
            var lastName = model.LastName.ToAlphaNum();

            var objDb = context.UserMasters.Where(o => o.Id == model.Id).FirstOrDefault();
            if(objDb==null)
                throw new BusinessException("User not found by id:"+model.Id);

            if (firstName.Length != 0)
            {
                objDb.FirstName = firstName;
                objDb.FullName = objDb.FirstName + " " + objDb.LastName;
                isUpdated = true;
            }
            
            if (lastName.Length != 0)
            {
                objDb.LastName = lastName;
                objDb.FullName = objDb.FirstName + " " + objDb.LastName;
                isUpdated = true;
            }

            if (objDb.MobileNumber != model.MobileNumber)
            {
                objDb.MobileNumber = model.MobileNumber;
                objDb.Name = model.MobileNumber;
                isUpdated = true;
            }

            if (objDb.Email != model.Email)
            {
                objDb.Email = model.Email;
                isUpdated = true;
            }

            if (isUpdated)
            {
                objDb.UpdatedOn = DateTime.Now;
                objDb.UpdatedBy = 1;
                context.SaveChanges();
            }

            return isUpdated;
        }

        public bool ChangePassword(long userId,string password)
        {
            var valResults = validatePassword(password);
            if (valResults.Any())
                throw new BusinessException(valResults[0].Message);

            var context = ContextManager.GetContext();

            var objDb = context.UserMasters.Where(o => o.Id == userId).FirstOrDefault();
            if (objDb == null)
                throw new BusinessException("User not found by id:" + userId);

            objDb.Password = encryptPassword(password);
            objDb.UpdatedOn = DateTime.Now;
            objDb.UpdatedBy = 1;
            context.SaveChanges();

            return true;
        }

      
        public bool Test()
        {
            var context = ContextManager.GetContext();
            var flag = context.RoleMasters.Any();
            return true;
        }

        public bool ValidateApp(string appId)
        {
            return true;
        }


        #region "private Methods"
        private List<ValidationResult> validate(UserInfo model,bool isEdit)
        {
            var results = new List<ValidationResult>();

            model.MobileNumber = model.MobileNumber.TrimAll();
            model.Email = model.Email.TrimAll();

            if (model.FirstName.TrimAll().Length == 0 || model.LastName.TrimAll().Length == 0)
                results.Add( new ValidationResult("First Name & Last Name are required."));

            if (model.MobileNumber.Length == 0)
                results.Add(new ValidationResult("Mobile-Number is required."));

            if (!model.MobileNumber.IsMobileNumber())
                results.Add(new ValidationResult("Mobile-Number is invalid."));

            if (model.Email.Length > 0 && !model.Email.IsEmail())
                results.Add(new ValidationResult("Email is invalid."));

            if (results.Count == 0)
            {
                var context = ContextManager.GetContext();
                var userExists = true;
                if (!isEdit)
                    userExists = context.UserMasters.Where(o => o.MobileNumber == model.MobileNumber).Any();
                else
                    userExists = context.UserMasters.Where(o => o.Id!=model.Id && o.MobileNumber == model.MobileNumber).Any();

                if(userExists)
                    results.Add(new ValidationResult("Mobile-Number is already registered."));
                else if (model.Email.TrimAll().Length > 0)
                {
                    if (!isEdit)
                        userExists = context.UserMasters.Where(o => o.Email == model.Email).Any();
                    else
                        userExists = context.UserMasters.Where(o => o.Id != model.Id && o.Email == model.Email).Any();

                    if (userExists)
                        results.Add(new ValidationResult("Email is already registered."));
                }
            }
           
            return results;

        }

        private List<ValidationResult> validatePassword(string password)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(password))
                results.Add(new ValidationResult("Password is required."));
            else if (password.Length<6)
                results.Add(new ValidationResult("Password must be at-least 6 characters long"));

            return results;
        }

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
