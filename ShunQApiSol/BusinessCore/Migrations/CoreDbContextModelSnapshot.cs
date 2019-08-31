﻿// <auto-generated />
using System;
using BusinessCore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusinessCore.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    partial class CoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.AddressMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Latitude");

                    b.Property<string>("Locality");

                    b.Property<string>("Longitude");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("AddressMasters");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.LogInSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken");

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DeviceId");

                    b.Property<DateTime>("ExpireOn");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<long>("UserMasterId");

                    b.HasKey("Id");

                    b.HasIndex("UserMasterId");

                    b.ToTable("LogInSessions");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.PriceMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<float>("Discount");

                    b.Property<string>("DiscountText");

                    b.Property<bool>("IsActive");

                    b.Property<float>("MRP");

                    b.Property<float>("Price");

                    b.Property<string>("ProductId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("PriceMasters");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.ProductBarcode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<string>("ProductId");

                    b.Property<string>("ProductMasterId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ProductMasterId");

                    b.ToTable("ProductBarcodes");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ProductMasterId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("ProductMasterId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.ProductMaster", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BannerImage");

                    b.Property<string>("Code");

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<string>("ThumbImage");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("ProductMasters");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.RoleMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleMasters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Description = "",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 1,
                            Description = "",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.StoreCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("StoreCategories");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.StoreCategoryXref", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StoreCategoryId");

                    b.Property<int>("StoreMasterId");

                    b.HasKey("Id");

                    b.HasIndex("StoreCategoryId");

                    b.HasIndex("StoreMasterId");

                    b.ToTable("StoreCategoryXrefs");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.StoreMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("BannerImage");

                    b.Property<string>("Code");

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("StoreMasters");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.UserMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailVerified");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<string>("Gender");

                    b.Property<string>("ImageId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("MobileNumber");

                    b.Property<bool>("MobileVerified");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Props");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("UserMasters");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<long>("RoleId");

                    b.Property<int?>("RoleMasterId");

                    b.Property<long?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<long>("UserId");

                    b.Property<long?>("UserMasterId");

                    b.HasKey("Id");

                    b.HasIndex("RoleMasterId");

                    b.HasIndex("UserMasterId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.LogInSession", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.UserMaster", "UserMaster")
                        .WithMany()
                        .HasForeignKey("UserMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.ProductBarcode", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.ProductMaster")
                        .WithMany("BarCodes")
                        .HasForeignKey("ProductMasterId");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.ProductCategory", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.ProductMaster")
                        .WithMany("Categories")
                        .HasForeignKey("ProductMasterId");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.StoreCategoryXref", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.StoreCategory", "Category")
                        .WithMany()
                        .HasForeignKey("StoreCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusinessCore.DataAccess.DbModels.StoreMaster", "Store")
                        .WithMany()
                        .HasForeignKey("StoreMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.StoreMaster", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.AddressMaster", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("BusinessCore.DataAccess.DbModels.UserRole", b =>
                {
                    b.HasOne("BusinessCore.DataAccess.DbModels.RoleMaster", "RoleMaster")
                        .WithMany()
                        .HasForeignKey("RoleMasterId");

                    b.HasOne("BusinessCore.DataAccess.DbModels.UserMaster", "UserMaster")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserMasterId");
                });
#pragma warning restore 612, 618
        }
    }
}
