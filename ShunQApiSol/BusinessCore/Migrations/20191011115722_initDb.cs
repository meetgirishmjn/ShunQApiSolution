using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountVoucherMasters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Expression = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountVoucherMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceMasters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    MRP = table.Column<float>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    DiscountText = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    WeightUnit = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMasters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ThumbImage = table.Column<string>(nullable: true),
                    BannerImage = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    CartDeviceId = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMasterOAuths",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ImageId = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    EmailVerified = table.Column<bool>(nullable: false),
                    MobileVerified = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasterOAuths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMasters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ImageId = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    EmailVerified = table.Column<bool>(nullable: false),
                    MobileVerified = table.Column<bool>(nullable: false),
                    Props = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    BannerImage = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    AddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreMasters_AddressMasters_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductBarcodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductMasterId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBarcodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBarcodes_ProductMasters_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryXrefs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductMasterId = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryXrefs_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryXrefs_ProductMasters_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartVouchers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VoucherId = table.Column<string>(nullable: true),
                    AppliedOn = table.Column<DateTime>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartVouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartVouchers_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartVouchers_DiscountVoucherMasters_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "DiscountVoucherMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogInSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserMasterId = table.Column<long>(nullable: false),
                    AuthToken = table.Column<string>(nullable: true),
                    ExpireOn = table.Column<DateTime>(nullable: false),
                    DeviceId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogInSessions_UserMasters_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTPCodes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserMasterId = table.Column<long>(nullable: false),
                    OTP = table.Column<string>(nullable: true),
                    OTPType = table.Column<string>(nullable: true),
                    ExpireOn = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTPCodes_UserMasters_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserMasterId = table.Column<long>(nullable: false),
                    RoleMasterId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleMasters_RoleMasterId",
                        column: x => x.RoleMasterId,
                        principalTable: "RoleMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserMasters_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDeviceMasters",
                columns: table => new
                {
                    CartDeviceId = table.Column<string>(nullable: false),
                    StoreMasterId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    StatusRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDeviceMasters", x => x.CartDeviceId);
                    table.ForeignKey(
                        name: "FK_CartDeviceMasters_StoreMasters_StoreMasterId",
                        column: x => x.StoreMasterId,
                        principalTable: "StoreMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreCategoryXrefs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StoreMasterId = table.Column<int>(nullable: false),
                    StoreCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategoryXrefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreCategoryXrefs_StoreCategories_StoreCategoryId",
                        column: x => x.StoreCategoryId,
                        principalTable: "StoreCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreCategoryXrefs_StoreMasters_StoreMasterId",
                        column: x => x.StoreMasterId,
                        principalTable: "StoreMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDeviceLogs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AppId = table.Column<string>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    CartDeviceId = table.Column<string>(nullable: true),
                    LogType = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    CartWeight = table.Column<float>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDeviceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDeviceLogs_CartDeviceMasters_CartDeviceId",
                        column: x => x.CartDeviceId,
                        principalTable: "CartDeviceMasters",
                        principalColumn: "CartDeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartDeviceLogs_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AddressMasters",
                columns: new[] { "Id", "AddressLine", "AddressLine2", "City", "CompanyId", "CreatedBy", "CreatedOn", "Latitude", "Locality", "Longitude", "UpdatedBy", "UpdatedOn", "Zip" },
                values: new object[,]
                {
                    { 1001, "No 12, Evergreen Layout, Byrathi, Near to RK Gowtham College", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13.0581", "Evergreen Layout", "77.6501", null, null, "560077" },
                    { 1002, "agadur Main Road, Whitefield, Near Bashveshwara Temple", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.969769", "Whitefield", "77.755636", null, null, "560066" },
                    { 1003, "No 26, &26/2, Sarjapura Main Road, Attibele, Near Lakshmi Convention Hall ", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.786873", "Sarjapura Main Road", "77.773229", null, null, "562107" },
                    { 1004, "No.21, Flat No.112, Konappana Agrahara, Begur, Electronic City", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.844235", "Electronic City", "77.674169", null, null, "560100" },
                    { 1005, "Salapuria Gateway , 45, A Block, J.P. Nagar, 2Nd Stage, Ward No - 57, 9Th Block, Near Ragiguddu, Kottapalya, Jayanagar", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.917188", "Jayanagar", "77.592353", null, null, "560041" },
                    { 1006, "Mango Garden Layout, Bikasipura, JP Nagar", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.893121", "JP Nagar", "77.565897", null, null, "560078" },
                    { 1007, "No 1381/100/93, Neeladri Nagar, Phase 1, Electronic City", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.841791", "Electronic City", "77.646292", null, null, "560100" },
                    { 1008, "30/1, Main Rd, Koramangala 7Th Block, Koramangala, Chikku Lakshmaiah Layout, Adugodi", null, "Bangalore", 0, 0L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.936745", "Adugodi", "77.610425", null, null, "560029" }
                });

            migrationBuilder.InsertData(
                table: "DiscountVoucherMasters",
                columns: new[] { "Id", "Code", "Description", "Expression", "Title" },
                values: new object[,]
                {
                    { "2b3be70f-705f-4bd2-a7c5-9149d0a77cc3", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "7f87c95f-0274-40a4-ab3e-f0c68b8c2408", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" },
                    { "ceee59e5-13bb-488a-a589-d0cdd5fa8175", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" }
                });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn", "Weight", "WeightUnit" },
                values: new object[,]
                {
                    { "1795efc0-7845-4160-9dcc-1606e28a2a80", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6827), 684f, "3% Discount", true, 846.4f, 162.4f, "57", null, null, 100f, "gm" },
                    { "6ccb44dd-472b-42c6-a5ce-0f69bd6ba4ce", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6793), 101f, "9% Discount", true, 179.2f, 78.2f, "56", null, null, 100f, "gm" },
                    { "5c4000f9-7576-4438-ba65-cdd272368e1a", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6766), 422f, "7% Discount", true, 848.3f, 426.3f, "55", null, null, 100f, "gm" },
                    { "1abde162-3481-4568-b43f-d9ad4703be3f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6742), 43f, "2% Discount", true, 105.9f, 62.9f, "54", null, null, 100f, "gm" },
                    { "3a7d6478-f12d-42b7-9fb3-55d35a2f2b69", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6715), 119f, "2% Discount", true, 741.9f, 622.9f, "53", null, null, 100f, "gm" },
                    { "b21e4203-ad20-4b26-8cea-cbbd226b7eaa", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6689), 155f, "8% Discount", true, 233.65f, 78.65f, "52", null, null, 100f, "gm" },
                    { "fcfac6e0-5025-43dc-bfde-cebd6452850f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6663), 308f, "9% Discount", true, 405.95f, 97.95f, "51", null, null, 100f, "gm" },
                    { "95f9fc1e-807b-4b03-a79f-a70d5b2a4f95", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6635), 542f, "4% Discount", true, 679.65f, 137.65f, "50", null, null, 100f, "gm" },
                    { "3de9576d-86a1-49f7-806b-47f28f7908c0", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6492), 102f, "7% Discount", true, 276.8f, 174.8f, "45", null, null, 100f, "gm" },
                    { "130ef6be-81c4-4b2a-a232-22e40863181e", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6573), 230f, "5% Discount", true, 933.9f, 703.9f, "48", null, null, 100f, "gm" },
                    { "ff620797-7770-4b9a-954e-04cc9e556b9c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6544), 267f, "5% Discount", true, 331.4f, 64.4f, "47", null, null, 100f, "gm" },
                    { "f16f1b81-1ae7-4f0a-8e3a-8852d9364e9c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6520), 447f, "9% Discount", true, 621.7f, 174.7f, "46", null, null, 100f, "gm" },
                    { "0c322c94-8350-4bb6-87b4-68bfa04e2242", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6855), 502f, "2% Discount", true, 790.5f, 288.5f, "58", null, null, 100f, "gm" },
                    { "7eb3c768-0c39-495d-9ba2-9d3ed2be475d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6380), 82f, "10% Discount", true, 98.8f, 16.8f, "44", null, null, 100f, "gm" },
                    { "b613c474-49a9-4bd5-ac93-fabc47bdfe9b", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6350), 114f, "6% Discount", true, 178.75f, 64.75f, "43", null, null, 100f, "gm" },
                    { "99204e32-6247-4263-814a-2b031193aae0", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6321), 112f, "4% Discount", true, 342.95f, 230.95f, "42", null, null, 100f, "gm" },
                    { "c8681a11-309c-489d-9ce1-42ef27f71888", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6607), 250f, "3% Discount", true, 606.35f, 356.35f, "49", null, null, 100f, "gm" },
                    { "16731efa-089e-41c6-9eed-3d8d26c48aa4", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6883), 59f, "3% Discount", true, 239.1f, 180.1f, "59", null, null, 100f, "gm" },
                    { "04b92eab-124a-4d7e-9f9b-898b2d258316", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7106), 409f, "8% Discount", true, 534.2f, 125.2f, "64", null, null, 100f, "gm" },
                    { "67758436-8303-45ca-948f-c91948952045", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7023), 166f, "3% Discount", true, 396.5f, 230.5f, "61", null, null, 100f, "gm" },
                    { "3f94e132-a4df-41ee-b39d-0258122f8340", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(8781), 166f, "9% Discount", true, 199.75f, 33.75f, "77", null, null, 100f, "gm" },
                    { "2fb49ecd-b338-4547-9337-bcfe0318375d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(8753), 107f, "8% Discount", true, 880.5f, 773.5f, "76", null, null, 100f, "gm" },
                    { "e0e8eda2-9ee4-4d8c-bdb0-3265328e692a", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(8712), 78f, "5% Discount", true, 443.15f, 365.15f, "75", null, null, 100f, "gm" },
                    { "73419ec2-e1a5-4f51-8b5d-34a874848764", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7589), 314f, "10% Discount", true, 360.5f, 46.5f, "74", null, null, 100f, "gm" },
                    { "513369fe-7677-4da0-b210-25750cade8e5", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7551), 670f, "1% Discount", true, 965.5f, 295.5f, "73", null, null, 100f, "gm" },
                    { "4ec4320f-2868-47d7-914d-12f7048856ca", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7330), 20f, "6% Discount", true, 565.75f, 545.75f, "72", null, null, 100f, "gm" },
                    { "ebdeccdb-65ea-4e5a-a2f2-ec28cd63e437", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7302), 787f, "1% Discount", true, 955.3f, 168.3f, "71", null, null, 100f, "gm" },
                    { "242692d6-8292-4806-b7a3-8bb5f93e3d68", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6996), 368f, "2% Discount", true, 455.4f, 87.4f, "60", null, null, 100f, "gm" },
                    { "2d8bea9b-fb16-43b9-b6e3-0372bf80ed59", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7273), 48f, "9% Discount", true, 208.6f, 160.6f, "70", null, null, 100f, "gm" },
                    { "47c66798-98bf-414c-8368-d1af10110071", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7222), 74f, "9% Discount", true, 260.35f, 186.35f, "68", null, null, 100f, "gm" },
                    { "f545bed6-c9e3-4f42-9412-80182e7ccabc", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7195), 635f, "7% Discount", true, 696.4f, 61.4f, "67", null, null, 100f, "gm" },
                    { "771e97dc-6f05-4ce8-9a2a-39a50a835dc2", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7170), 64f, "2% Discount", true, 97.5f, 33.5f, "66", null, null, 100f, "gm" },
                    { "5b78b0dc-478a-4dca-b2d8-7c1f6359e879", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7140), 218f, "9% Discount", true, 372.95f, 154.95f, "65", null, null, 100f, "gm" },
                    { "148c8331-7ac1-4851-9123-a81a228730a1", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6292), 168f, "9% Discount", true, 545.7f, 377.7f, "41", null, null, 100f, "gm" },
                    { "8dc34a4b-603d-4ae2-ba70-5d3dacdae4bf", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7079), 468f, "8% Discount", true, 484.1f, 16.1f, "63", null, null, 100f, "gm" },
                    { "7c9e9eff-c1e4-48e3-b3b8-6e0a89a7f99c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7051), 258f, "3% Discount", true, 602.1f, 344.1f, "62", null, null, 100f, "gm" },
                    { "f46f4387-c0a8-4428-b81b-e1c4fbf138c7", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(7247), 123f, "8% Discount", true, 356.65f, 233.65f, "69", null, null, 100f, "gm" },
                    { "6e592e10-9f86-4ba2-8c67-606c702c8fca", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6261), 109f, "3% Discount", true, 538.45f, 429.45f, "40", null, null, 100f, "gm" },
                    { "9d262670-5ef1-4a58-bc59-2e031db84c14", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6124), 18f, "4% Discount", true, 127.5f, 109.5f, "35", null, null, 100f, "gm" },
                    { "29f34bfa-e4f8-4986-98e3-ea385602f5fd", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6205), 262f, "2% Discount", true, 991.95f, 729.95f, "38", null, null, 100f, "gm" },
                    { "f0750cff-d868-48e0-85c4-d78e5a8fec27", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5389), 675f, "1% Discount", true, 856.25f, 181.25f, "16", null, null, 100f, "gm" },
                    { "5c5ea7fb-8e5f-4bc7-9766-58d7804f9115", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5361), 4f, "4% Discount", true, 772.55f, 768.55f, "15", null, null, 100f, "gm" },
                    { "84240b03-6565-44b1-a563-ce3976812e6f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5332), 130f, "7% Discount", true, 445.65f, 315.65f, "14", null, null, 100f, "gm" },
                    { "9d89c9f6-2bf9-4417-9a54-cb0180da6730", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5305), 556f, "4% Discount", true, 890.2f, 334.2f, "13", null, null, 100f, "gm" },
                    { "c5da1294-3d46-4ab5-adf2-09bd2efbb29d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5278), 62f, "4% Discount", true, 913.25f, 851.25f, "12", null, null, 100f, "gm" },
                    { "6c878cb4-027e-47e5-8c56-7f3faff87fa7", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5252), 5f, "5% Discount", true, 16.25f, 11.25f, "11", null, null, 100f, "gm" },
                    { "26351eef-889c-4275-a81b-ba4369ca219a", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5225), 109f, "6% Discount", true, 392.55f, 283.55f, "10", null, null, 100f, "gm" },
                    { "76d32a0c-c7c1-4b2b-b38d-810f287d6d4c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5518), 20f, "1% Discount", true, 183.5f, 163.5f, "17", null, null, 100f, "gm" },
                    { "1e093338-b27a-4095-990d-7ca368160e20", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5194), 73f, "4% Discount", true, 327.95f, 254.95f, "9", null, null, 100f, "gm" },
                    { "e1253e7b-1fcc-4c62-a9a2-7eacdd927d6d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5117), 779f, "5% Discount", true, 973.55f, 194.55f, "7", null, null, 100f, "gm" },
                    { "0712d864-a1dc-4a06-ae0d-fb68050e000f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5085), 118f, "10% Discount", true, 601.3f, 483.3f, "6", null, null, 100f, "gm" },
                    { "02fd4359-fb45-42f3-8192-11bef6e07f4a", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5050), 86f, "7% Discount", true, 315.4f, 229.4f, "5", null, null, 100f, "gm" },
                    { "5e87d208-a716-47ce-a2bd-77d64ef24aec", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5022), 124f, "8% Discount", true, 214.4f, 90.4f, "4", null, null, 100f, "gm" },
                    { "da8ac59a-a8ca-497a-a975-fe668b3cbb6d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(4991), 161f, "9% Discount", true, 547.1f, 386.1f, "3", null, null, 100f, "gm" },
                    { "22860899-0769-4348-9a83-1631c57d4a2f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(4922), 298f, "7% Discount", true, 423.35f, 125.35f, "2", null, null, 100f, "gm" },
                    { "4716e1dc-e350-4045-b6f7-120ae9541d3b", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(839), 80f, "6% Discount", true, 344.3f, 264.3f, "1", null, null, 100f, "gm" },
                    { "b40a65c4-eebb-48bb-87cd-14897c315ee2", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5146), 16f, "6% Discount", true, 26.45f, 10.45f, "8", null, null, 100f, "gm" },
                    { "d02301e8-fe4f-4d42-84bf-e1bb3a84581f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6234), 258f, "7% Discount", true, 994.85f, 736.85f, "39", null, null, 100f, "gm" },
                    { "6e776c9f-91be-4ec5-9d6a-ae2e34aff69a", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5551), 68f, "1% Discount", true, 95.45f, 27.45f, "18", null, null, 100f, "gm" },
                    { "9e747375-cd4a-4eda-9d61-62dd6f71d347", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5604), 96f, "7% Discount", true, 388.3f, 292.3f, "20", null, null, 100f, "gm" },
                    { "d5094367-d1e9-42e4-815d-2861cccbbf7e", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6180), 157f, "1% Discount", true, 620.7f, 463.7f, "37", null, null, 100f, "gm" },
                    { "eebc514d-7e44-4cb8-a303-0080f98f27c6", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6153), 148f, "2% Discount", true, 335.8f, 187.8f, "36", null, null, 100f, "gm" },
                    { "e1fe1cc8-6e9d-499b-9712-4a5354f5271f", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6098), 275f, "2% Discount", true, 682.5f, 407.5f, "34", null, null, 100f, "gm" },
                    { "54584561-d976-46d5-b54d-3a447a4c01a0", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6066), 58f, "1% Discount", true, 115.8f, 57.8f, "33", null, null, 100f, "gm" },
                    { "e2872d60-f833-4761-be80-2d7b86aff19c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6035), 162f, "3% Discount", true, 444.3f, 282.3f, "32", null, null, 100f, "gm" },
                    { "2924e484-b263-48b2-a4f7-70dc88d14581", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(6006), 201f, "4% Discount", true, 372.35f, 171.35f, "31", null, null, 100f, "gm" },
                    { "299f9d50-40b7-4e3c-9d48-4f000a6e1899", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5575), 86f, "3% Discount", true, 170.6f, 84.6f, "19", null, null, 100f, "gm" },
                    { "3b87e6a0-8738-418c-8b45-6901552a8c31", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5857), 247f, "4% Discount", true, 386.5f, 139.5f, "29", null, null, 100f, "gm" },
                    { "f0c71589-75a5-4c9c-b059-34554468e9f8", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5888), 406f, "9% Discount", true, 674.6f, 268.6f, "30", null, null, 100f, "gm" },
                    { "748175ba-8749-4746-a411-dbadc4fce7a0", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5798), 69f, "6% Discount", true, 354.65f, 285.65f, "27", null, null, 100f, "gm" },
                    { "630e17c9-8dee-4539-a330-a9556f6ec206", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5774), 111f, "2% Discount", true, 869.5f, 758.5f, "26", null, null, 100f, "gm" },
                    { "e2277318-9f77-4371-ba99-deb9637cf45d", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5747), 28f, "1% Discount", true, 266.8f, 238.8f, "25", null, null, 100f, "gm" },
                    { "4c2db037-f941-4cdc-82f6-e6a30e2e259c", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5716), 220f, "4% Discount", true, 339.4f, 119.4f, "24", null, null, 100f, "gm" },
                    { "015e8c7e-db11-4bc0-b95d-5cb3c282f539", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5690), 22f, "8% Discount", true, 105.6f, 83.6f, "23", null, null, 100f, "gm" },
                    { "325215c8-22f5-468e-9b09-454f33f629ce", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5660), 96f, "6% Discount", true, 629.65f, 533.65f, "22", null, null, 100f, "gm" },
                    { "f8a33824-66ae-42a6-b271-037d54a155c2", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5633), 676f, "6% Discount", true, 886.5f, 210.5f, "21", null, null, 100f, "gm" },
                    { "06ef6123-c934-4b14-956d-7b032070e328", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 528, DateTimeKind.Local).AddTicks(5827), 273f, "2% Discount", true, 447.95f, 174.95f, "28", null, null, 100f, "gm" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 4, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9562), "Cheeses", "Dairy Products", null, null },
                    { 5, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9576), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null },
                    { 3, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9569), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 8, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9542), "Seaweed and fish", "Seafood", null, null },
                    { 7, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9526), "Dried fruit and bean curd", "Produce", null, null },
                    { 6, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9534), "Prepared meats", "Meat/Poultry", null, null },
                    { 2, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(9494), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null },
                    { 1, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 516, DateTimeKind.Local).AddTicks(7023), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4198), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4191), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4183), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4175), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4166), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4157), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4148), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4140), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4132), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4124), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4117), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4108), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4100), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4091), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4083), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4075), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4206), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4068), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4308), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4318), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4535), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4528), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4520), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4513), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4504), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4413), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4404), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4300), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4397), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4380), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4372), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4363), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4349), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4341), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4333), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4326), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4388), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(4059), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3849), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3841), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3569), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3560), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3551), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3543), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3535), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3527), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3520), "", true, "Ikura", "", "10.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3578), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3507), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3491), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3371), "", true, "Grandma's Boysenberry Spread", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3353), "", true, "Chef Anton's Gumbo Mix", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3344), "", true, "Chef Anton's Cajun Seasoning", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3334), "", true, "Aniseed Syrup", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3226), "", true, "Chang", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 520, DateTimeKind.Local).AddTicks(1364), "", true, "Chai", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3500), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3598), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3589), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3769), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3832), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3822), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3814), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3806), "", true, "Sasquatch Ale", "", "34.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3794), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3786), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3777), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3606), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3761), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3753), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3746), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3739), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3731), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3723), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3631), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3623), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null },
                    { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 522, DateTimeKind.Local).AddTicks(3616), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleMasters",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "", "Administrator" },
                    { 5, 1, "", "User" }
                });

            migrationBuilder.InsertData(
                table: "StoreCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1004, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 358, DateTimeKind.Local).AddTicks(5749), "", "Stationery", null, null },
                    { 1003, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 358, DateTimeKind.Local).AddTicks(5746), "", "Kid Care/Toys", null, null },
                    { 1005, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 358, DateTimeKind.Local).AddTicks(5751), "", "Electronics", null, null },
                    { 1001, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 358, DateTimeKind.Local).AddTicks(4371), "", "Departmental Stores", null, null },
                    { 1002, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 358, DateTimeKind.Local).AddTicks(5729), "", "Grocery", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Email", "EmailVerified", "FirstName", "FullName", "Gender", "ImageId", "IsActive", "IsDeleted", "LastName", "MobileNumber", "MobileVerified", "Name", "Password", "Props", "UpdatedBy", "UpdatedOn", "UserType" },
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 351, DateTimeKind.Local).AddTicks(4919), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "meetgirish.mjn@gmail.com", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null, null });

            migrationBuilder.InsertData(
                table: "ProductCategoryXrefs",
                columns: new[] { "Id", "ProductCategoryId", "ProductMasterId" },
                values: new object[,]
                {
                    { 35L, 1, "35" },
                    { 47L, 3, "47" },
                    { 46L, 8, "46" },
                    { 45L, 8, "45" },
                    { 44L, 2, "44" },
                    { 43L, 1, "43" },
                    { 42L, 5, "42" },
                    { 41L, 8, "41" },
                    { 40L, 8, "40" },
                    { 39L, 1, "39" },
                    { 38L, 1, "38" },
                    { 37L, 8, "37" },
                    { 36L, 8, "36" },
                    { 77L, 2, "77" },
                    { 34L, 1, "34" },
                    { 33L, 4, "33" },
                    { 48L, 3, "48" },
                    { 49L, 3, "49" },
                    { 50L, 3, "50" },
                    { 51L, 7, "51" },
                    { 67L, 1, "67" },
                    { 66L, 2, "66" },
                    { 65L, 2, "65" },
                    { 64L, 5, "64" },
                    { 63L, 2, "63" },
                    { 62L, 3, "62" },
                    { 61L, 2, "61" },
                    { 32L, 4, "32" },
                    { 60L, 4, "60" },
                    { 58L, 8, "58" },
                    { 57L, 5, "57" },
                    { 56L, 5, "56" },
                    { 55L, 6, "55" },
                    { 54L, 6, "54" },
                    { 53L, 6, "53" },
                    { 52L, 5, "52" },
                    { 59L, 4, "59" },
                    { 68L, 3, "68" },
                    { 31L, 4, "31" },
                    { 29L, 6, "29" },
                    { 8L, 2, "8" },
                    { 7L, 7, "7" },
                    { 6L, 2, "6" },
                    { 5L, 2, "5" },
                    { 4L, 2, "4" },
                    { 3L, 2, "3" },
                    { 2L, 1, "2" },
                    { 1L, 1, "1" },
                    { 70L, 1, "70" },
                    { 71L, 4, "71" },
                    { 72L, 4, "72" },
                    { 73L, 8, "73" },
                    { 74L, 7, "74" },
                    { 75L, 1, "75" },
                    { 76L, 1, "76" },
                    { 9L, 6, "9" },
                    { 10L, 8, "10" },
                    { 11L, 4, "11" },
                    { 12L, 4, "12" },
                    { 28L, 7, "28" },
                    { 27L, 3, "27" },
                    { 26L, 3, "26" },
                    { 25L, 3, "25" },
                    { 24L, 1, "24" },
                    { 23L, 5, "23" },
                    { 22L, 5, "22" },
                    { 30L, 8, "30" },
                    { 21L, 3, "21" },
                    { 19L, 3, "19" },
                    { 18L, 8, "18" },
                    { 17L, 6, "17" },
                    { 16L, 3, "16" },
                    { 15L, 2, "15" },
                    { 14L, 7, "14" },
                    { 13L, 8, "13" },
                    { 20L, 3, "20" },
                    { 69L, 4, "69" }
                });

            migrationBuilder.InsertData(
                table: "StoreMasters",
                columns: new[] { "Id", "AddressId", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Image", "IsActive", "Name", "ShortName", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1001, 1001, "STR-1-Banner.jpg", "STR-1", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 359, DateTimeKind.Local).AddTicks(7381), "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers", "STR-1-Thumb.jpg", true, "AB Supermarket", "AB Supermarket", null, null },
                    { 1007, 1007, "STR-7-Banner.jpg", "STR-7", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1028), "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.", "STR-7-Thumb.jpg", true, "Village Hyper Market", "Village Hyper Market", null, null },
                    { 1006, 1006, "STR-6-Banner.jpg", "STR-6", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1026), "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.", "STR-6-Thumb.jpg", true, "Metro Cash And Carry", "Metro Cash And Carry", null, null },
                    { 1005, 1005, "STR-5-Banner.jpg", "STR-5", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1019), "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.", "STR-5-Thumb.jpg", true, "Big Bazaar", "Big Bazaar", null, null },
                    { 1004, 1004, "STR-4-Banner.jpg", "STR-4", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1017), "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.", "STR-4-Thumb.jpg", true, "D Mart", "D Mart", null, null },
                    { 1003, 1003, "STR-3-Banner.jpg", "STR-3", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1013), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-3-Thumb.jpg", true, "The Big Market", "The Big Market", null, null },
                    { 1002, 1002, "STR-2-Banner.jpg", "STR-2", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(988), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-2-Thumb.jpg", true, "Imperio Market", "Imperio Market", null, null },
                    { 1008, 1008, "STR-8-Banner.jpg", "STR-8", 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 360, DateTimeKind.Local).AddTicks(1031), "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-8-Thumb.jpg", true, "Star Bazaar", "Star Bazaar", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "RoleMasterId", "UpdatedBy", "UpdatedOn", "UserMasterId" },
                values: new object[] { 1, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 356, DateTimeKind.Local).AddTicks(4407), true, 1, 1L, new DateTime(2019, 10, 11, 17, 27, 21, 356, DateTimeKind.Local).AddTicks(693), 1L });

            migrationBuilder.InsertData(
                table: "CartDeviceMasters",
                columns: new[] { "CartDeviceId", "IsActive", "StatusRemark", "StoreMasterId" },
                values: new object[,]
                {
                    { "0b433771-7b7b-4b15-a466-cbd0470ddccb", true, null, 1001 },
                    { "fb4a0cf0-516d-4c0d-9fb3-e327e4109c84", true, null, 1007 },
                    { "f0fc2b90-cd1a-472a-bbbb-a4e3fa365b4e", true, null, 1007 },
                    { "2921c541-d4ee-4e19-a355-753463ac8ea0", true, null, 1004 },
                    { "39c86ca7-72d3-4237-8c3f-c0eb99049f69", true, null, 1004 },
                    { "d0e4d171-629e-4ff1-917f-499ea57685d9", true, null, 1004 },
                    { "31f6f23e-85e4-4ee4-9863-f11c7aca0243", true, null, 1004 },
                    { "9d994da9-56b9-4bb9-a5d9-0a1e1b800320", true, null, 1004 },
                    { "a8799420-3027-4f34-acd2-4ba99a74e3f2", true, null, 1007 },
                    { "99004754-15fe-48b0-ac14-f7e8037b4bae", true, null, 1006 },
                    { "6e6147f0-d45e-4aa2-80ee-3ef396e7bb2e", true, null, 1007 },
                    { "285cba82-ad9b-47d6-a83a-5aca3f7387ad", true, null, 1005 },
                    { "42b1d418-ab71-4365-ad13-dce1bf4fb3b8", true, null, 1005 },
                    { "f9a26e63-b57c-4d39-b042-305ec1ae7309", true, null, 1005 },
                    { "fac8f310-94d5-4dbb-ba5f-250d05c38ef4", true, null, 1005 },
                    { "3c2bdae6-f0d2-4b18-a7a4-515347e70b8b", true, null, 1007 },
                    { "ccc219db-c0c7-4b36-862e-8e5111cc88c0", true, null, 1006 },
                    { "3d5d8032-4b83-4c6a-9f35-58532a3057c0", true, null, 1006 },
                    { "9772bc8d-7ba5-4e81-8c37-77a7e4e2a4a0", true, null, 1006 },
                    { "d6092d5c-7718-4a0e-beae-f2e5c333f7a5", true, null, 1005 },
                    { "b285059f-2c60-4932-82f9-05fe30007de1", true, null, 1003 },
                    { "ccf658a7-8eb4-4ecf-9b41-f4e4f7ed3bfd", true, null, 1006 },
                    { "1c3b60c8-e79f-4390-b0c7-c2a849babdab", true, null, 1003 },
                    { "cab55b41-8102-4887-b9ad-a5eaf7a0ea49", true, null, 1001 },
                    { "28762bab-61f9-4093-b085-3ff1b5aa4751", true, null, 1001 },
                    { "78fb5769-1550-461b-b6ad-26394061e1c6", true, null, 1001 },
                    { "9b59d732-9312-44eb-a7f8-5a3c5b5653c6", true, null, 1001 },
                    { "7b86dcf7-fbaf-4415-b1bf-c05f3677373b", true, null, 1008 },
                    { "3c03b3e2-f4d9-4eae-93f1-efff54f1da7d", true, null, 1008 },
                    { "8771c880-46f3-43a4-a5e6-1e4e0c736383", true, null, 1008 },
                    { "19ed2817-e400-4565-a9f8-6fe5a255d9e7", true, null, 1003 },
                    { "87f58809-3ddc-40dc-be68-d037d9bef561", true, null, 1002 },
                    { "d12fe427-0f86-495f-b2ae-7a2565f1fc54", true, null, 1008 },
                    { "0a86330a-d22e-4831-8b94-f504e47082f9", true, null, 1002 },
                    { "775b9a4c-178e-443a-8667-8d390f398ac6", true, null, 1002 },
                    { "3d8101aa-5086-4476-914e-5f0fda5bd065", true, null, 1002 },
                    { "ab76c73e-77ab-4568-bfa3-16911cbf23a5", true, null, 1008 },
                    { "90302e2c-57e2-41d7-951c-ea6a7c16e65a", true, null, 1003 },
                    { "3f3d6781-190f-41fa-afd7-0077db0dc13c", true, null, 1003 },
                    { "e9c143a2-52bc-41a9-a7ef-3f42ae846c04", true, null, 1002 }
                });

            migrationBuilder.InsertData(
                table: "StoreCategoryXrefs",
                columns: new[] { "Id", "StoreCategoryId", "StoreMasterId" },
                values: new object[,]
                {
                    { 1022L, 1005, 1007 },
                    { 1021L, 1005, 1006 },
                    { 1013L, 1004, 1006 },
                    { 1014L, 1004, 1007 },
                    { 1006L, 1002, 1007 },
                    { 1019L, 1005, 1004 },
                    { 1020L, 1005, 1005 },
                    { 1001L, 1001, 1001 },
                    { 1004L, 1002, 1001 },
                    { 1007L, 1003, 1001 },
                    { 1016L, 1005, 1001 },
                    { 1002L, 1001, 1002 },
                    { 1008L, 1003, 1002 },
                    { 1012L, 1003, 1006 },
                    { 1017L, 1005, 1002 },
                    { 1009L, 1003, 1003 },
                    { 1018L, 1005, 1003 },
                    { 1010L, 1003, 1004 },
                    { 1015L, 1004, 1008 },
                    { 1005L, 1002, 1005 },
                    { 1011L, 1003, 1005 },
                    { 1003L, 1001, 1003 },
                    { 1023L, 1005, 1008 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartDeviceLogs_CartDeviceId",
                table: "CartDeviceLogs",
                column: "CartDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDeviceLogs_ShoppingCartId",
                table: "CartDeviceLogs",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDeviceMasters_StoreMasterId",
                table: "CartDeviceMasters",
                column: "StoreMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_CartVouchers_ShoppingCartId",
                table: "CartVouchers",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartVouchers_VoucherId",
                table: "CartVouchers",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_LogInSessions_UserMasterId",
                table: "LogInSessions",
                column: "UserMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OTPCodes_UserMasterId",
                table: "OTPCodes",
                column: "UserMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMasters_ProductId",
                table: "PriceMasters",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBarcodes_ProductMasterId",
                table: "ProductBarcodes",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryXrefs_ProductCategoryId",
                table: "ProductCategoryXrefs",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryXrefs_ProductMasterId",
                table: "ProductCategoryXrefs",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryXrefs_StoreCategoryId",
                table: "StoreCategoryXrefs",
                column: "StoreCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryXrefs_StoreMasterId",
                table: "StoreCategoryXrefs",
                column: "StoreMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreMasters_AddressId",
                table: "StoreMasters",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleMasterId",
                table: "UserRoles",
                column: "RoleMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserMasterId",
                table: "UserRoles",
                column: "UserMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDeviceLogs");

            migrationBuilder.DropTable(
                name: "CartVouchers");

            migrationBuilder.DropTable(
                name: "LogInSessions");

            migrationBuilder.DropTable(
                name: "OTPCodes");

            migrationBuilder.DropTable(
                name: "PriceMasters");

            migrationBuilder.DropTable(
                name: "ProductBarcodes");

            migrationBuilder.DropTable(
                name: "ProductCategoryXrefs");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "StoreCategoryXrefs");

            migrationBuilder.DropTable(
                name: "UserMasterOAuths");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CartDeviceMasters");

            migrationBuilder.DropTable(
                name: "DiscountVoucherMasters");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductMasters");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "StoreCategories");

            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropTable(
                name: "UserMasters");

            migrationBuilder.DropTable(
                name: "StoreMasters");

            migrationBuilder.DropTable(
                name: "AddressMasters");
        }
    }
}
