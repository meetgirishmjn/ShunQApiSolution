using BusinessCore.DataAccess.DbModels;
using BusinessCore.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCore.DataAccess
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        { }

        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<LogInSession> LogInSessions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<AddressMaster> AddressMasters { get; set; }
        public DbSet<PriceMaster> PriceMasters { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductMaster> ProductMasters { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }
        public DbSet<StoreMaster> StoreMasters { get; set; }
        public DbSet<StoreCategoryXref> StoreCategoryXrefs { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RoleMaster>()
       .HasData(
           new RoleMaster
           {
               Id = (int)RoleNames.Administrator,
               Name = RoleNames.Administrator.ToString(),
               CompanyId=1,
               Description=string.Empty
           },
           new RoleMaster
           {
               Id = (int)RoleNames.User,
               Name = RoleNames.User.ToString(),
               CompanyId = 1,
               Description = string.Empty
           }
       );

            modelBuilder.Entity<UserMaster>()
      .HasData(
          new UserMaster
          {
              Id = 1,
              Name = AppConfig.ADMIN_USER_NAME,
              CompanyId = 1,
              CreatedBy = 1,
              CreatedOn = DateTime.Now,
              Email = "meetgirish.mjn@gmail.com",
              EmailVerified = true,
              FirstName = "Girish",
              FullName = "Girish Mahajan",
              Gender = "M",
              ImageId = string.Empty,
              IsActive = true,
              IsDeleted = false,
              LastName = " Mahajan",
              MobileNumber = "8871384762",
              MobileVerified = true,
              Password = "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=",
              Props = string.Empty
          });

            modelBuilder.Entity<UserRole>()
     .HasData(
         new UserRole
         {
             Id = 1,
             RoleMasterId= (int)RoleNames.Administrator,
             UserMasterId=1,
             CompanyId=1,
             UpdatedOn=DateTime.Now,
             UpdatedBy=1,
             CreatedBy=1,
             CreatedOn=DateTime.Now,
             IsActive=true
         });

            base.OnModelCreating(modelBuilder);
        }
    }
    }
