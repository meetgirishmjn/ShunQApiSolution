using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class Init_db : Migration
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
                    { "ae711950-f6ca-4175-b043-bab5fb064e3d", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "8c852720-9d3f-446f-bd46-48f2df356320", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" },
                    { "b6520a8d-62da-43fa-ae73-6cc3c96e33a9", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" }
                });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn", "Weight", "WeightUnit" },
                values: new object[,]
                {
                    { "8bd5c7d0-070a-482b-99ef-98d3d3751a09", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6409), 48f, "2% Discount", true, 106.55f, 58.55f, "57", null, null, 100f, "gm" },
                    { "1fec36ec-8407-46f6-be5d-ad676be2f390", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6392), 128f, "9% Discount", true, 208.45f, 80.45f, "56", null, null, 100f, "gm" },
                    { "0a2431dc-ffd9-4a91-b2a9-07b607599d9d", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6374), 694f, "10% Discount", true, 978.2f, 284.2f, "55", null, null, 100f, "gm" },
                    { "62fbfc35-46f1-4211-a651-4512fd88ad2a", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6357), 15f, "10% Discount", true, 792.25f, 777.25f, "54", null, null, 100f, "gm" },
                    { "b1226250-8015-40b3-823a-535defa101cb", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6336), 6f, "1% Discount", true, 495.5f, 489.5f, "53", null, null, 100f, "gm" },
                    { "f0bb224c-ff78-49f3-a29d-8e20138822cc", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6317), 714f, "2% Discount", true, 811.7f, 97.7f, "52", null, null, 100f, "gm" },
                    { "c3431b25-16b9-491e-9b44-670b7200cfea", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6300), 197f, "4% Discount", true, 273.9f, 76.9f, "51", null, null, 100f, "gm" },
                    { "4b4f11b4-f69d-4326-9491-14f5a3b0f7bf", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6283), 312f, "2% Discount", true, 893.6f, 581.6f, "50", null, null, 100f, "gm" },
                    { "06d9e549-9b4a-4758-9f5d-53dcd13f27c3", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6121), 538f, "10% Discount", true, 694.2f, 156.2f, "45", null, null, 100f, "gm" },
                    { "5b023e10-270d-4f6a-8349-768f3463cb61", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6177), 236f, "4% Discount", true, 388.9f, 152.9f, "48", null, null, 100f, "gm" },
                    { "0eb0699a-78c7-4511-bee4-d0d8342d9bb6", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6160), 732f, "8% Discount", true, 893.1f, 161.1f, "47", null, null, 100f, "gm" },
                    { "b99976b4-630a-43db-b6ae-41d2133f0087", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6142), 275f, "3% Discount", true, 297.8f, 22.8f, "46", null, null, 100f, "gm" },
                    { "1b143385-71b2-47d4-ae6f-b64a77dbadb4", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6426), 11f, "4% Discount", true, 47.8f, 36.8f, "58", null, null, 100f, "gm" },
                    { "0e8d7aff-02d8-4215-9ce0-330722934c30", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6103), 25f, "4% Discount", true, 269.15f, 244.15f, "44", null, null, 100f, "gm" },
                    { "0b775b14-8f32-4762-80da-cfabfb2d08cb", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6086), 495f, "9% Discount", true, 929.25f, 434.25f, "43", null, null, 100f, "gm" },
                    { "325c233e-c2cb-408c-8319-5934262c140a", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6069), 47f, "3% Discount", true, 626.85f, 579.85f, "42", null, null, 100f, "gm" },
                    { "504b811b-4a83-48e3-a923-415979cc5c5f", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6264), 554f, "9% Discount", true, 995.35f, 441.35f, "49", null, null, 100f, "gm" },
                    { "8dff8afe-d311-4e5a-87e3-f38c5dcba066", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6444), 67f, "6% Discount", true, 77.5f, 10.5f, "59", null, null, 100f, "gm" },
                    { "f7e3e8ad-ab78-49ed-bcdc-060debc687d0", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6601), 197f, "8% Discount", true, 652.6f, 455.6f, "64", null, null, 100f, "gm" },
                    { "99bb202a-ffe1-4d93-8535-e8886b6bda07", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6479), 26f, "5% Discount", true, 42.75f, 16.75f, "61", null, null, 100f, "gm" },
                    { "39ebe59f-3f1c-4f24-89b0-41daa7e8a1e7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6838), 161f, "6% Discount", true, 203.5f, 42.5f, "77", null, null, 100f, "gm" },
                    { "66d1e2f2-b721-48c0-a12d-d18230710bfe", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6820), 205f, "6% Discount", true, 932.3f, 727.3f, "76", null, null, 100f, "gm" },
                    { "6ec7c9ee-caad-4b3e-9957-33ca2f8bcd89", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6803), 238f, "8% Discount", true, 717.7f, 479.7f, "75", null, null, 100f, "gm" },
                    { "8521a5f3-b4fe-4d63-b8dd-7ba8a9da1d9b", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6784), 29f, "8% Discount", true, 884.8f, 855.8f, "74", null, null, 100f, "gm" },
                    { "c7545c1d-97fa-4806-a9fa-c21a81e236a7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6767), 97f, "7% Discount", true, 290.4f, 193.4f, "73", null, null, 100f, "gm" },
                    { "2b068905-4170-4ca8-a590-a9bb0958f417", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6748), 21f, "4% Discount", true, 77.35f, 56.35f, "72", null, null, 100f, "gm" },
                    { "20f90e3a-0ea5-43ee-9c6d-aace0a01daa2", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6732), 842f, "4% Discount", true, 946.95f, 104.95f, "71", null, null, 100f, "gm" },
                    { "b4da9519-78c0-4b7a-a3b1-5f42d23c8598", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6462), 319f, "3% Discount", true, 661.5f, 342.5f, "60", null, null, 100f, "gm" },
                    { "6167b1be-feb0-49a1-97ad-cc4cefc279ac", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6713), 489f, "3% Discount", true, 906.5f, 417.5f, "70", null, null, 100f, "gm" },
                    { "a8160ae6-ac93-46fa-92be-dce0b52a92b9", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6674), 25f, "6% Discount", true, 420.75f, 395.75f, "68", null, null, 100f, "gm" },
                    { "ace3109f-fa72-46d8-8cf6-9bbedb982acc", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6657), 653f, "2% Discount", true, 683.75f, 30.75f, "67", null, null, 100f, "gm" },
                    { "ba2f0faf-a83e-4b8c-a2a5-8d4280a0b649", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6640), 676f, "5% Discount", true, 995.3f, 319.3f, "66", null, null, 100f, "gm" },
                    { "b48048b4-12bc-4041-a038-17af5a5afef9", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6620), 67f, "7% Discount", true, 407.9f, 340.9f, "65", null, null, 100f, "gm" },
                    { "96b7d2ef-66ae-49b2-9c89-5724c1a91661", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6052), 162f, "4% Discount", true, 216.3f, 54.3f, "41", null, null, 100f, "gm" },
                    { "b23574e7-c580-45d6-8963-174c93d9a0f4", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6517), 135f, "7% Discount", true, 463.5f, 328.5f, "63", null, null, 100f, "gm" },
                    { "0e146524-00a3-4bf0-9541-a6dc7d789580", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6499), 265f, "6% Discount", true, 308.4f, 43.4f, "62", null, null, 100f, "gm" },
                    { "aad32041-b60a-48e9-8770-1161ccbb0486", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6691), 12f, "5% Discount", true, 25.45f, 13.45f, "69", null, null, 100f, "gm" },
                    { "b6e03573-67a7-4309-a8a6-5f5915cf8ea5", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6034), 131f, "9% Discount", true, 470.75f, 339.75f, "40", null, null, 100f, "gm" },
                    { "15055cd8-cf86-43bb-a8dd-8189e9ba051b", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5943), 13f, "8% Discount", true, 78.8f, 65.8f, "35", null, null, 100f, "gm" },
                    { "c2a3fde7-6272-4d88-bd03-1049b551e2a6", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5999), 61f, "3% Discount", true, 195.3f, 134.3f, "38", null, null, 100f, "gm" },
                    { "5b7aef7b-0cea-486a-acdb-0cfccfa19f30", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5380), 26f, "8% Discount", true, 493.55f, 467.55f, "16", null, null, 100f, "gm" },
                    { "ffff5cdb-324e-4b89-9fca-913ac2a2a24f", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5362), 736f, "3% Discount", true, 757.65f, 21.65f, "15", null, null, 100f, "gm" },
                    { "ce80e022-7552-4e2b-9122-95f765829ffe", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5344), 341f, "2% Discount", true, 469.55f, 128.55f, "14", null, null, 100f, "gm" },
                    { "61087393-be2d-4db5-9ca5-3090b69f2d9f", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5321), 191f, "4% Discount", true, 224.2f, 33.2f, "13", null, null, 100f, "gm" },
                    { "a884936a-bc12-45cc-b74d-ede2f42f187d", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5303), 107f, "4% Discount", true, 462.6f, 355.6f, "12", null, null, 100f, "gm" },
                    { "22b76cb6-36f3-4d4a-a999-ca174bf1a17f", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5284), 81f, "1% Discount", true, 99.1f, 18.1f, "11", null, null, 100f, "gm" },
                    { "ea98832b-2bfa-462d-8463-e02af9d7e25c", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5263), 121f, "1% Discount", true, 309.35f, 188.35f, "10", null, null, 100f, "gm" },
                    { "183bf540-a498-403f-9c0f-fb9203d14fbf", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5399), 113f, "8% Discount", true, 623.6f, 510.6f, "17", null, null, 100f, "gm" },
                    { "3ae3fe85-c743-4a5a-98b1-bf3fbf6ff36b", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5242), 714f, "6% Discount", true, 800.8f, 86.8f, "9", null, null, 100f, "gm" },
                    { "f05a1270-d36f-48ce-8a3b-d6767553baff", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5204), 296f, "8% Discount", true, 904.65f, 608.65f, "7", null, null, 100f, "gm" },
                    { "741316ea-a48e-412b-beaa-9b6574343b09", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5181), 14f, "3% Discount", true, 43.35f, 29.35f, "6", null, null, 100f, "gm" },
                    { "20f3687d-7267-43fd-8c5b-dc65c8ff43e7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5044), 18f, "5% Discount", true, 345.35f, 327.35f, "5", null, null, 100f, "gm" },
                    { "fd4f1be6-8c02-4a1c-885e-3c81ea8ca3ab", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5025), 32f, "4% Discount", true, 52.55f, 20.55f, "4", null, null, 100f, "gm" },
                    { "39362d9d-739f-4d24-98e0-54df412c72df", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5004), 208f, "7% Discount", true, 575.6f, 367.6f, "3", null, null, 100f, "gm" },
                    { "4c92dc2a-f9cf-4b5b-a141-5b8367084a51", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(4958), 182f, "2% Discount", true, 244.15f, 62.15f, "2", null, null, 100f, "gm" },
                    { "4973fdd2-11a6-4076-9400-1b437a90f064", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(1911), 227f, "7% Discount", true, 247.2f, 20.2f, "1", null, null, 100f, "gm" },
                    { "6fd1ad97-e604-4ab2-ad2a-1d4b9ae56ab2", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5222), 44f, "1% Discount", true, 862.25f, 818.25f, "8", null, null, 100f, "gm" },
                    { "53c63e41-2211-453f-9a79-84a72f62b979", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(6017), 81f, "2% Discount", true, 434.4f, 353.4f, "39", null, null, 100f, "gm" },
                    { "16b7932d-7f73-49e1-a192-40a94fe8b23d", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5417), 685f, "1% Discount", true, 697.9f, 12.9f, "18", null, null, 100f, "gm" },
                    { "04531a2d-3d79-4cec-82ca-0869612d1cd8", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5521), 163f, "3% Discount", true, 568.9f, 405.9f, "20", null, null, 100f, "gm" },
                    { "77609c9d-6853-44d7-bda3-69c1c4b7ec84", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5977), 367f, "5% Discount", true, 847.75f, 480.75f, "37", null, null, 100f, "gm" },
                    { "6bef3e34-bc9e-4e8d-9e44-86fffb6b196a", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5960), 614f, "6% Discount", true, 831.1f, 217.1f, "36", null, null, 100f, "gm" },
                    { "5b4c381d-765e-4b85-8b17-2c91a5118c9f", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5924), 319f, "2% Discount", true, 752.15f, 433.15f, "34", null, null, 100f, "gm" },
                    { "a0084cf2-caa5-45bc-9824-01d118547455", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5762), 659f, "6% Discount", true, 752.45f, 93.45f, "33", null, null, 100f, "gm" },
                    { "ed71f21f-9270-44dd-a17b-eb28307c25bf", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5745), 89f, "4% Discount", true, 402.75f, 313.75f, "32", null, null, 100f, "gm" },
                    { "67397275-dea6-4e86-8aa8-9ae243ec7ff9", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5727), 346f, "10% Discount", true, 458.15f, 112.15f, "31", null, null, 100f, "gm" },
                    { "db6349c0-af80-4a42-954c-e942348f69b0", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5435), 577f, "3% Discount", true, 903.75f, 326.75f, "19", null, null, 100f, "gm" },
                    { "bb8ff6ce-66f4-4e00-91cc-fcaa6719b088", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5686), 738f, "3% Discount", true, 805.5f, 67.5f, "29", null, null, 100f, "gm" },
                    { "3ce1f3d3-897f-4025-aac0-7cebf322f6d5", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5709), 28f, "10% Discount", true, 923.9f, 895.9f, "30", null, null, 100f, "gm" },
                    { "1f3777af-c59a-4d64-ad6f-584cef470acf", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5649), 20f, "7% Discount", true, 54.25f, 34.25f, "27", null, null, 100f, "gm" },
                    { "73bc72e1-6068-4c0b-aa4c-9ffc1976bbfa", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5630), 545f, "5% Discount", true, 995.65f, 450.65f, "26", null, null, 100f, "gm" },
                    { "72c7e68d-fd3a-4c31-8d7c-f6afaf776a95", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5613), 216f, "10% Discount", true, 376.15f, 160.15f, "25", null, null, 100f, "gm" },
                    { "96fd8027-46f0-48c1-ae86-e997aa299307", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5595), 199f, "7% Discount", true, 391.3f, 192.3f, "24", null, null, 100f, "gm" },
                    { "6f43301f-00b4-4409-9c6d-b70d163ae13b", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5578), 73f, "7% Discount", true, 962.55f, 889.55f, "23", null, null, 100f, "gm" },
                    { "755d42a1-fbe3-452d-826c-e8a52c62c039", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5561), 337f, "4% Discount", true, 644.75f, 307.75f, "22", null, null, 100f, "gm" },
                    { "b5a8a2b8-ee5e-44e5-9b00-16f5998c54b9", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5539), 122f, "1% Discount", true, 283.15f, 161.15f, "21", null, null, 100f, "gm" },
                    { "43231a3a-12a3-4a8c-bb4e-093d62abc1a7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 677, DateTimeKind.Local).AddTicks(5667), 2f, "1% Discount", true, 12.15f, 10.15f, "28", null, null, 100f, "gm" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 4, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9058), "Cheeses", "Dairy Products", null, null },
                    { 5, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9078), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null },
                    { 3, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9070), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 8, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9043), "Seaweed and fish", "Seafood", null, null },
                    { 7, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9026), "Dried fruit and bean curd", "Produce", null, null },
                    { 6, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9034), "Prepared meats", "Meat/Poultry", null, null },
                    { 2, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(9001), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null },
                    { 1, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 671, DateTimeKind.Local).AddTicks(6841), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8741), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8732), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8723), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8713), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8704), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8694), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8684), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8674), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8664), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8654), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8645), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8635), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8624), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8433), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8423), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8414), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8750), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8404), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8771), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8780), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(9019), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(9010), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(9000), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8991), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8981), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8972), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8962), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8759), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8952), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8934), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8924), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8914), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8899), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8890), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8799), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8790), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8943), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8395), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8385), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8376), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8071), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8061), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8052), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8042), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8032), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8021), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7892), "", true, "Ikura", "", "10.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8081), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7879), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7860), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7847), "", true, "Grandma's Boysenberry Spread", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7829), "", true, "Chef Anton's Gumbo Mix", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7819), "", true, "Chef Anton's Cajun Seasoning", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7808), "", true, "Aniseed Syrup", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7698), "", true, "Chang", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 673, DateTimeKind.Local).AddTicks(7966), "", true, "Chai", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(7870), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8104), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8094), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8296), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8366), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8357), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8347), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8338), "", true, "Sasquatch Ale", "", "34.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8325), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8315), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8306), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8113), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8285), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8192), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8182), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8173), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8164), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8152), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8142), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8133), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null },
                    { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 674, DateTimeKind.Local).AddTicks(8123), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null }
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
                    { 1004, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 563, DateTimeKind.Local).AddTicks(4836), "", "Stationery", null, null },
                    { 1003, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 563, DateTimeKind.Local).AddTicks(4834), "", "Kid Care/Toys", null, null },
                    { 1005, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 563, DateTimeKind.Local).AddTicks(4837), "", "Electronics", null, null },
                    { 1001, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 563, DateTimeKind.Local).AddTicks(3947), "", "Departmental Stores", null, null },
                    { 1002, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 563, DateTimeKind.Local).AddTicks(4825), "", "Grocery", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Email", "EmailVerified", "FirstName", "FullName", "Gender", "ImageId", "IsActive", "IsDeleted", "LastName", "MobileNumber", "MobileVerified", "Name", "Password", "Props", "UpdatedBy", "UpdatedOn", "UserType" },
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 558, DateTimeKind.Local).AddTicks(2561), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "meetgirish.mjn@gmail.com", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null, null });

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
                    { 1001, 1001, "STR-1-Banner.jpg", "STR-1", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(2140), "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers", "STR-1-Thumb.jpg", true, "AB Supermarket", "AB Supermarket", null, null },
                    { 1007, 1007, "STR-7-Banner.jpg", "STR-7", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3820), "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.", "STR-7-Thumb.jpg", true, "Village Hyper Market", "Village Hyper Market", null, null },
                    { 1006, 1006, "STR-6-Banner.jpg", "STR-6", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3817), "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.", "STR-6-Thumb.jpg", true, "Metro Cash And Carry", "Metro Cash And Carry", null, null },
                    { 1005, 1005, "STR-5-Banner.jpg", "STR-5", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3812), "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.", "STR-5-Thumb.jpg", true, "Big Bazaar", "Big Bazaar", null, null },
                    { 1004, 1004, "STR-4-Banner.jpg", "STR-4", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3810), "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.", "STR-4-Thumb.jpg", true, "D Mart", "D Mart", null, null },
                    { 1003, 1003, "STR-3-Banner.jpg", "STR-3", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3807), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-3-Thumb.jpg", true, "The Big Market", "The Big Market", null, null },
                    { 1002, 1002, "STR-2-Banner.jpg", "STR-2", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3793), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-2-Thumb.jpg", true, "Imperio Market", "Imperio Market", null, null },
                    { 1008, 1008, "STR-8-Banner.jpg", "STR-8", 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 564, DateTimeKind.Local).AddTicks(3822), "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-8-Thumb.jpg", true, "Star Bazaar", "Star Bazaar", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "RoleMasterId", "UpdatedBy", "UpdatedOn", "UserMasterId" },
                values: new object[] { 1, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 562, DateTimeKind.Local).AddTicks(228), true, 1, 1L, new DateTime(2019, 10, 20, 17, 2, 39, 561, DateTimeKind.Local).AddTicks(7618), 1L });

            migrationBuilder.InsertData(
                table: "CartDeviceMasters",
                columns: new[] { "CartDeviceId", "IsActive", "StatusRemark", "StoreMasterId" },
                values: new object[,]
                {
                    { "5c9282db-3036-42a1-86f4-26fa43836e1b", true, null, 1001 },
                    { "5e23e6b1-b896-4e89-879d-ea9d0e365cea", true, null, 1007 },
                    { "43b2f6e7-ffb3-4bd8-9bbf-a55b8940240a", true, null, 1007 },
                    { "d65266c0-dedf-4583-8493-b429ec6ec38b", true, null, 1004 },
                    { "1ba22a89-5e28-428a-bdee-69e4be0424c3", true, null, 1004 },
                    { "19908d62-6b7d-4194-a6c3-b94700197cc4", true, null, 1004 },
                    { "9cc247f7-4232-4038-8719-2ab151eac3a1", true, null, 1004 },
                    { "dbee4457-af4f-4940-8666-fc95d386a60e", true, null, 1004 },
                    { "69422183-2ff7-4951-9fa3-9d91ef760250", true, null, 1007 },
                    { "3a5deb15-5798-4428-8995-c9b506932c72", true, null, 1006 },
                    { "926da321-ac73-4d95-9a93-500159a2e96b", true, null, 1007 },
                    { "2d2781c7-e2a3-4597-b38b-5736cca1ef77", true, null, 1005 },
                    { "95ac2dae-e41c-44c5-a93d-15598e0591d1", true, null, 1005 },
                    { "2ee73525-e214-4ba5-9707-f9864f1c7482", true, null, 1005 },
                    { "20cd3682-5d41-4fa5-94f8-3eaa37d198d0", true, null, 1005 },
                    { "ef3f6822-1b73-4f93-ad1b-fe7b64eb9bd9", true, null, 1007 },
                    { "f342080d-9f4b-4f8e-b16f-1f7ccbe2928a", true, null, 1006 },
                    { "96691f86-b4c7-443c-8b23-5c4fce84b783", true, null, 1006 },
                    { "d6f1b730-c03d-483a-97ad-92c4708781bf", true, null, 1006 },
                    { "e38a844e-413a-45be-9223-f2ced73e2617", true, null, 1005 },
                    { "7daf5f78-1d1c-4de9-a75e-c18ef1432ba1", true, null, 1003 },
                    { "1a633ca6-9a13-4cf0-a950-cb1c91ff7477", true, null, 1006 },
                    { "b5217226-49ce-45cd-b387-1174f796845c", true, null, 1003 },
                    { "335ace1e-53e6-4bb1-8111-c5e0cb8eabbe", true, null, 1001 },
                    { "e66a4ea3-a923-41d4-af7f-894ab7816b6e", true, null, 1001 },
                    { "83841c3c-9bcf-41a6-9f54-6ad4ab4dabbd", true, null, 1001 },
                    { "8fbb9a64-bd1c-409c-b566-057d8647f357", true, null, 1001 },
                    { "0a537ef1-829a-4e3d-8615-8aabe1bfc2f7", true, null, 1008 },
                    { "d68f25fb-ac33-43bd-ba1e-b66b66d2dffa", true, null, 1008 },
                    { "7b569519-1285-4022-918c-15613b7ee97e", true, null, 1008 },
                    { "7ed2f4b0-4110-4f74-8f5f-6e6fbaddc824", true, null, 1003 },
                    { "d7d24719-787a-4688-bcd9-081ab4ea3060", true, null, 1002 },
                    { "7b7d5876-12a5-445f-9a99-974309417632", true, null, 1008 },
                    { "9a323744-a49c-4c4a-b46f-5d727d693047", true, null, 1002 },
                    { "c3de2d5f-f54e-4ee8-84e9-95ccac0a177c", true, null, 1002 },
                    { "6a3cfe4a-8159-430e-ad3b-c29f70c4958b", true, null, 1002 },
                    { "8687aff1-3966-440b-b28f-a0c4b3fb6367", true, null, 1008 },
                    { "adf727bc-e60f-4c49-86d5-82fa028b28cc", true, null, 1003 },
                    { "67d10e5a-21bc-428c-8baa-410fecf6bc53", true, null, 1003 },
                    { "ff43de65-8532-4934-911f-1dce78db04b0", true, null, 1002 }
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
