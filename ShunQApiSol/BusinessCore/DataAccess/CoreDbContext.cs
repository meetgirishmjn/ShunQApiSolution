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
            base.OnModelCreating(modelBuilder);
        }
    }
    }
