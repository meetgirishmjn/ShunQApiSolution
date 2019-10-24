using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class init_DB : Migration
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
                    { "6eef281e-6366-43f5-93c2-cab367b41794", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "8245c3c3-c0c9-49c5-8792-4237c97a3e7d", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" },
                    { "1ae38a43-8b0b-4100-b277-00aa73ff5df9", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" }
                });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn", "Weight", "WeightUnit" },
                values: new object[,]
                {
                    { "9747e63f-8e0f-452b-a77b-c90b4a426cbd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6241), 646f, "10% Discount", true, 971.85f, 325.85f, "57", null, null, 100f, "gm" },
                    { "0e010066-dc99-461a-8903-ade50fd02492", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6207), 20f, "8% Discount", true, 35.65f, 15.65f, "56", null, null, 100f, "gm" },
                    { "9c6c9c03-62fb-4b6f-a562-4c14e062c4c8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6175), 41f, "2% Discount", true, 481.25f, 440.25f, "55", null, null, 100f, "gm" },
                    { "0bb5c8b0-b573-4c6c-b657-c610fdd97d29", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6145), 35f, "9% Discount", true, 259.95f, 224.95f, "54", null, null, 100f, "gm" },
                    { "964da465-a70e-4bea-a3e2-85a3a8f23d54", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6114), 61f, "7% Discount", true, 248.2f, 187.2f, "53", null, null, 100f, "gm" },
                    { "c02e7f07-73e1-411b-a70c-520fa7fc556d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6084), 402f, "7% Discount", true, 866.3f, 464.3f, "52", null, null, 100f, "gm" },
                    { "00b4312a-6d76-4166-b9cf-73fb5942f6c2", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6052), 147f, "4% Discount", true, 173.2f, 26.2f, "51", null, null, 100f, "gm" },
                    { "8f29de75-9df4-4871-9889-03a584d41693", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6020), 255f, "2% Discount", true, 950.15f, 695.15f, "50", null, null, 100f, "gm" },
                    { "a804ff34-6fbb-409d-a866-67e20e69cbfd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5855), 50f, "7% Discount", true, 81.85f, 31.85f, "45", null, null, 100f, "gm" },
                    { "3c02d1a8-7fe9-4dcd-b4ca-fd5abfdefb0d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5951), 159f, "1% Discount", true, 511.9f, 352.9f, "48", null, null, 100f, "gm" },
                    { "4b7f78df-fa53-4814-864f-45e0921853b3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5920), 307f, "5% Discount", true, 328.2f, 21.2f, "47", null, null, 100f, "gm" },
                    { "7f6dc488-a1ab-492d-b5b9-b6b4166f5204", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5888), 1f, "8% Discount", true, 734.65f, 733.65f, "46", null, null, 100f, "gm" },
                    { "fae25622-9971-4692-8bc1-ce6062fdf7c6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6340), 29f, "10% Discount", true, 590.95f, 561.95f, "58", null, null, 100f, "gm" },
                    { "82f36a14-f5a6-423b-b041-a035fad2c311", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5751), 78f, "1% Discount", true, 370.2f, 292.2f, "44", null, null, 100f, "gm" },
                    { "35ed0145-c8af-478d-9056-d67c05976d10", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5719), 4f, "5% Discount", true, 551.25f, 547.25f, "43", null, null, 100f, "gm" },
                    { "4494ec47-934f-4681-9702-88fd92e9ebf0", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5687), 319f, "2% Discount", true, 680.5f, 361.5f, "42", null, null, 100f, "gm" },
                    { "704613a2-c015-4cfb-b8cf-baca7a29d67d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5990), 145f, "2% Discount", true, 238.15f, 93.15f, "49", null, null, 100f, "gm" },
                    { "1494b01f-83dc-46c4-a3b6-19ffb8edb983", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6367), 79f, "6% Discount", true, 149.35f, 70.35f, "59", null, null, 100f, "gm" },
                    { "17797e12-bb1e-48e9-8471-3e4bcf00972a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6501), 273f, "2% Discount", true, 579.5f, 306.5f, "64", null, null, 100f, "gm" },
                    { "1ef8c297-78fd-4e04-a2c1-32eabe67fa4d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6420), 245f, "7% Discount", true, 374.8f, 129.8f, "61", null, null, 100f, "gm" },
                    { "c35254d0-62e7-496f-bcac-17bbd618cf3f", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6928), 91f, "5% Discount", true, 332.25f, 241.25f, "77", null, null, 100f, "gm" },
                    { "034211cd-cc45-4460-9700-b192d7bdef70", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6900), 214f, "1% Discount", true, 243.8f, 29.8f, "76", null, null, 100f, "gm" },
                    { "136fb7da-8b6a-4931-bc92-82e97ad7f515", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6875), 438f, "10% Discount", true, 747.7f, 309.7f, "75", null, null, 100f, "gm" },
                    { "d9c4e900-5f93-4350-bf44-bc124d46a745", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6848), 45f, "2% Discount", true, 242.1f, 197.1f, "74", null, null, 100f, "gm" },
                    { "c409ea9b-6e04-4ff4-a1d9-7f734dc55a6a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6821), 127f, "3% Discount", true, 292.6f, 165.6f, "73", null, null, 100f, "gm" },
                    { "9bb13ceb-5342-4b10-ba13-b8bdd627946f", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6790), 35f, "8% Discount", true, 292.6f, 257.6f, "72", null, null, 100f, "gm" },
                    { "09e91484-722a-4dd7-b22c-280500ffec3c", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6765), 188f, "6% Discount", true, 437.9f, 249.9f, "71", null, null, 100f, "gm" },
                    { "37a4ce2f-d1cd-4b5e-8f21-c4de882f0a26", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6395), 282f, "4% Discount", true, 610.6f, 328.6f, "60", null, null, 100f, "gm" },
                    { "ac9b6125-af47-41aa-80df-323e5110e706", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6738), 21f, "8% Discount", true, 520.7f, 499.7f, "70", null, null, 100f, "gm" },
                    { "f186f26c-862d-4b88-900f-87f88cc513a3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6619), 266f, "7% Discount", true, 360.8f, 94.8f, "68", null, null, 100f, "gm" },
                    { "ce5641a6-4a89-4dd9-8a0e-cdd97b9a162c", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6592), 598f, "9% Discount", true, 833.3f, 235.3f, "67", null, null, 100f, "gm" },
                    { "717788d3-68a1-4f53-a9b2-c2094dfbe76b", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6563), 194f, "6% Discount", true, 602.55f, 408.55f, "66", null, null, 100f, "gm" },
                    { "5b25fd5a-8de8-4fdd-afd9-d3df90e43e17", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6534), 177f, "3% Discount", true, 386.95f, 209.95f, "65", null, null, 100f, "gm" },
                    { "286a52d0-519a-44c2-981f-27d70ee6fddd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5657), 172f, "2% Discount", true, 246.6f, 74.6f, "41", null, null, 100f, "gm" },
                    { "8910a113-a93d-40c0-b342-ad47f0c031ec", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6474), 21f, "7% Discount", true, 500.4f, 479.4f, "63", null, null, 100f, "gm" },
                    { "03f17ec4-5a1b-4d81-b4d4-9ccecc08be5e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6447), 62f, "9% Discount", true, 75.75f, 13.75f, "62", null, null, 100f, "gm" },
                    { "c14e2623-958b-4580-8061-61cfae0cb47e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6710), 360f, "3% Discount", true, 574.9f, 214.9f, "69", null, null, 100f, "gm" },
                    { "1ea46104-e7d1-426b-bcf9-15dd8bf3fd48", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5620), 35f, "6% Discount", true, 273.7f, 238.7f, "40", null, null, 100f, "gm" },
                    { "6cf80745-8321-48a6-b143-fdbd62436992", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5464), 4f, "10% Discount", true, 26.3f, 22.3f, "35", null, null, 100f, "gm" },
                    { "b70ffc20-0a6a-4ac2-b050-b4cd5c370679", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5559), 170f, "7% Discount", true, 268.9f, 98.9f, "38", null, null, 100f, "gm" },
                    { "0e03a58b-74c0-418c-861c-b9f2eadb8331", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4452), 547f, "10% Discount", true, 700.95f, 153.95f, "16", null, null, 100f, "gm" },
                    { "f4e61dd5-b8c4-4470-b1f6-a00091bab433", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4425), 525f, "3% Discount", true, 540.6f, 15.6f, "15", null, null, 100f, "gm" },
                    { "ee831988-1c2c-4037-9cda-2057c4f281ed", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4398), 55f, "2% Discount", true, 73.9f, 18.9f, "14", null, null, 100f, "gm" },
                    { "7760982d-2713-4693-a3c3-51597ba2faad", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4368), 147f, "10% Discount", true, 251.2f, 104.2f, "13", null, null, 100f, "gm" },
                    { "9a55c36c-0750-4927-a9f7-4b1ab240d606", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4340), 14f, "2% Discount", true, 245.1f, 231.1f, "12", null, null, 100f, "gm" },
                    { "e6689a82-449d-40da-bc60-1dc492052041", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4313), 540f, "1% Discount", true, 831.55f, 291.55f, "11", null, null, 100f, "gm" },
                    { "f247ec05-8d57-45ba-b8f5-5f20dee36dad", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4282), 589f, "6% Discount", true, 684.3f, 95.3f, "10", null, null, 100f, "gm" },
                    { "acb17562-56fb-4ce7-a334-6e02b91507f3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4489), 81f, "10% Discount", true, 268.8f, 187.8f, "17", null, null, 100f, "gm" },
                    { "7b691ae8-d57c-47ef-9a73-6cf30ad82515", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4249), 184f, "3% Discount", true, 829.8f, 645.8f, "9", null, null, 100f, "gm" },
                    { "231bb117-a072-42bd-8f89-3c8614fa87bd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4072), 47f, "4% Discount", true, 291.9f, 244.9f, "7", null, null, 100f, "gm" },
                    { "2c57cb5e-a89e-492d-8045-b33ec16ae627", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4042), 284f, "3% Discount", true, 786.45f, 502.45f, "6", null, null, 100f, "gm" },
                    { "f18a554d-0532-4680-a106-2535d1a7b9f7", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4003), 802f, "10% Discount", true, 928.4f, 126.4f, "5", null, null, 200f, "gm" },
                    { "fcdbd0f2-be16-4183-84d1-0594ba007e35", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3972), 358f, "10% Discount", true, 509.8f, 151.8f, "4", null, null, 300f, "gm" },
                    { "a298e7d1-6a82-43c6-a037-2d2badcb27bc", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3935), 21f, "6% Discount", true, 432.5f, 411.5f, "3", null, null, 500f, "gm" },
                    { "46e4cb60-9168-4abe-bcac-c823ac8c1667", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3872), 735f, "8% Discount", true, 815.55f, 80.55f, "2", null, null, 500f, "gm" },
                    { "65e1e0ab-d0d1-4a2c-b7ac-5da2317106e6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(677), 59f, "10% Discount", true, 246.95f, 187.95f, "1", null, null, 200f, "gm" },
                    { "bdd81086-da73-49b0-9d98-1ecf6682f5bb", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4206), 12f, "7% Discount", true, 39.5f, 27.5f, "8", null, null, 100f, "gm" },
                    { "4481baa9-87c2-40c9-a522-34b994c7d32e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5589), 630f, "7% Discount", true, 954.5f, 324.5f, "39", null, null, 100f, "gm" },
                    { "fa5fc6a2-a92d-434a-8882-a57878c5a6f1", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4520), 272f, "8% Discount", true, 999.7f, 727.7f, "18", null, null, 100f, "gm" },
                    { "ab88b614-14ff-44b5-a227-c58e82a721d8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4756), 550f, "7% Discount", true, 630.45f, 80.45f, "20", null, null, 100f, "gm" },
                    { "486ffde3-62c0-499e-a0dc-1b337c3c0df5", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5527), 477f, "4% Discount", true, 706.8f, 229.8f, "37", null, null, 100f, "gm" },
                    { "0c365a35-c382-4fa6-ae7c-ee9d1ef3c26a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5495), 382f, "3% Discount", true, 422.45f, 40.45f, "36", null, null, 100f, "gm" },
                    { "b6aa17a4-ae25-4b49-96b8-7ba18324a9c7", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5434), 237f, "4% Discount", true, 278.45f, 41.45f, "34", null, null, 100f, "gm" },
                    { "f146d99f-f966-4d61-a159-bd5d4a7adb93", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5396), 537f, "1% Discount", true, 556.1f, 19.1f, "33", null, null, 100f, "gm" },
                    { "9a066d18-0f88-4a3b-b965-571e298edd64", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5144), 920f, "10% Discount", true, 987.35f, 67.35f, "32", null, null, 100f, "gm" },
                    { "eaf21124-1da9-4431-9954-10b81f3f733b", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5112), 672f, "2% Discount", true, 939.5f, 267.5f, "31", null, null, 100f, "gm" },
                    { "76cb4fad-e253-490b-ad6a-99b81f2b99fb", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4548), 366f, "7% Discount", true, 607.8f, 241.8f, "19", null, null, 100f, "gm" },
                    { "9b39c996-1553-431d-a4f1-0b4d4f8894b2", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5049), 27f, "3% Discount", true, 350.45f, 323.45f, "29", null, null, 100f, "gm" },
                    { "729b4640-3048-4626-99c6-381ca50f572c", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5080), 609f, "3% Discount", true, 927.5f, 318.5f, "30", null, null, 100f, "gm" },
                    { "c0a69fb9-cd01-4cf7-9a89-2dcef8947617", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4988), 540f, "4% Discount", true, 666.5f, 126.5f, "27", null, null, 100f, "gm" },
                    { "d6e9bae8-c13f-4323-affd-b5b200cd2a06", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4956), 567f, "2% Discount", true, 968.55f, 401.55f, "26", null, null, 100f, "gm" },
                    { "5a51afd6-af73-4c73-b36c-16347365369d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4925), 303f, "9% Discount", true, 376.6f, 73.6f, "25", null, null, 100f, "gm" },
                    { "12dc7c2a-1ead-4b34-97b8-4816573f04af", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4884), 390f, "9% Discount", true, 863.65f, 473.65f, "24", null, null, 100f, "gm" },
                    { "25bed50a-4b20-4fa2-8feb-a36e1d82b789", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4852), 186f, "8% Discount", true, 591.7f, 405.7f, "23", null, null, 100f, "gm" },
                    { "e73f67fe-58fe-45ba-81ce-0a6a9f64564e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4822), 151f, "8% Discount", true, 617.65f, 466.65f, "22", null, null, 100f, "gm" },
                    { "114cb56b-8c1e-4b67-8537-4f20ebe7de33", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4789), 550f, "3% Discount", true, 700.35f, 150.35f, "21", null, null, 100f, "gm" },
                    { "df653e80-76f5-4643-b5c0-8c37c6ce8509", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5019), 123f, "10% Discount", true, 497.65f, 374.65f, "28", null, null, 100f, "gm" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 4, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1791), "Cheeses", "Dairy Products", null, null },
                    { 5, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1802), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null },
                    { 3, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1796), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 8, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1779), "Seaweed and fish", "Seafood", null, null },
                    { 7, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1768), "Dried fruit and bean curd", "Produce", null, null },
                    { 6, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1774), "Prepared meats", "Meat/Poultry", null, null },
                    { 2, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1751), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null },
                    { 1, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(542), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5175), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5169), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5162), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5155), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5148), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5142), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5135), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5128), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5059), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5052), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5045), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5038), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5028), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5022), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5016), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5008), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5181), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5001), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5197), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5203), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5373), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5367), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5360), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5354), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5348), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5342), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5334), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5190), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5328), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5315), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5308), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5302), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5228), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5222), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5216), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5209), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5321), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4993), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4986), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4978), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4741), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4621), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4614), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4607), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4600), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4593), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4585), "", true, "Ikura", "", "10.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4749), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4574), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4559), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4551), "", true, "Device-6", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4538), "", true, "Device-5", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4531), "", true, "Device-4", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4520), "", true, "Device-3", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4445), "", true, "Device-2", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 121, DateTimeKind.Local).AddTicks(4928), "", true, "Device-1", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4566), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4767), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4760), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4850), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4971), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4962), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4951), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4944), "", true, "Sasquatch Ale", "", "34.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4871), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4864), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4857), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4774), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4842), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4835), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4827), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4820), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4812), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4804), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4797), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4790), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null },
                    { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4782), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null }
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
                    { 1004, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2535), "", "Stationery", null, null },
                    { 1003, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2533), "", "Kid Care/Toys", null, null },
                    { 1005, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2536), "", "Electronics", null, null },
                    { 1001, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(1671), "", "Departmental Stores", null, null },
                    { 1002, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2525), "", "Grocery", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Email", "EmailVerified", "FirstName", "FullName", "Gender", "ImageId", "IsActive", "IsDeleted", "LastName", "MobileNumber", "MobileVerified", "Name", "Password", "Props", "UpdatedBy", "UpdatedOn", "UserType" },
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 950, DateTimeKind.Local).AddTicks(9271), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "meetgirish.mjn@gmail.com", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null, null });

            migrationBuilder.InsertData(
                table: "ProductBarcodes",
                columns: new[] { "Id", "Code", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "ProductMasterId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 6, "9501101530003", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(743), true, "6", null, null },
                    { 5, "036000291452", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(737), true, "5", null, null },
                    { 1, "811571013579", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 127, DateTimeKind.Local).AddTicks(8005), true, "1", null, null },
                    { 4, "9771234567003", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(734), true, "4", null, null },
                    { 2, "705632441947", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(633), true, "2", null, null },
                    { 3, "9780123456786", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(659), true, "3", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategoryXrefs",
                columns: new[] { "Id", "ProductCategoryId", "ProductMasterId" },
                values: new object[,]
                {
                    { 32L, 4, "32" },
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
                    { 35L, 1, "35" },
                    { 34L, 1, "34" },
                    { 33L, 4, "33" },
                    { 48L, 3, "48" },
                    { 49L, 3, "49" },
                    { 53L, 6, "53" },
                    { 51L, 7, "51" },
                    { 67L, 1, "67" },
                    { 66L, 2, "66" },
                    { 65L, 2, "65" },
                    { 64L, 5, "64" },
                    { 63L, 2, "63" },
                    { 62L, 3, "62" },
                    { 61L, 2, "61" },
                    { 50L, 3, "50" },
                    { 60L, 4, "60" },
                    { 58L, 8, "58" },
                    { 57L, 5, "57" },
                    { 56L, 5, "56" },
                    { 55L, 6, "55" },
                    { 54L, 6, "54" },
                    { 77L, 2, "77" },
                    { 52L, 5, "52" },
                    { 59L, 4, "59" },
                    { 31L, 4, "31" },
                    { 28L, 7, "28" },
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
                    { 68L, 3, "68" },
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
                    { 1001, 1001, "STR-1-Banner.jpg", "STR-1", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(8151), "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers", "STR-1-Thumb.jpg", true, "AB Supermarket", "AB Supermarket", null, null },
                    { 1007, 1007, "STR-7-Banner.jpg", "STR-7", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9257), "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.", "STR-7-Thumb.jpg", true, "Village Hyper Market", "Village Hyper Market", null, null },
                    { 1006, 1006, "STR-6-Banner.jpg", "STR-6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9256), "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.", "STR-6-Thumb.jpg", true, "Metro Cash And Carry", "Metro Cash And Carry", null, null },
                    { 1005, 1005, "STR-5-Banner.jpg", "STR-5", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9251), "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.", "STR-5-Thumb.jpg", true, "Big Bazaar", "Big Bazaar", null, null },
                    { 1004, 1004, "STR-4-Banner.jpg", "STR-4", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9249), "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.", "STR-4-Thumb.jpg", true, "D Mart", "D Mart", null, null },
                    { 1003, 1003, "STR-3-Banner.jpg", "STR-3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9246), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-3-Thumb.jpg", true, "The Big Market", "The Big Market", null, null },
                    { 1002, 1002, "STR-2-Banner.jpg", "STR-2", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9235), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-2-Thumb.jpg", true, "Imperio Market", "Imperio Market", null, null },
                    { 1008, 1008, "STR-8-Banner.jpg", "STR-8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9260), "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-8-Thumb.jpg", true, "Star Bazaar", "Star Bazaar", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "RoleMasterId", "UpdatedBy", "UpdatedOn", "UserMasterId" },
                values: new object[] { 1, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 954, DateTimeKind.Local).AddTicks(175), true, 1, 1L, new DateTime(2019, 10, 25, 1, 30, 18, 953, DateTimeKind.Local).AddTicks(8356), 1L });

            migrationBuilder.InsertData(
                table: "CartDeviceMasters",
                columns: new[] { "CartDeviceId", "IsActive", "StatusRemark", "StoreMasterId" },
                values: new object[,]
                {
                    { "72371421-c046-459f-9c40-65ca26c623e6", true, null, 1001 },
                    { "d9f828f5-76da-4c50-89fd-ab5fbcfcc480", true, null, 1007 },
                    { "ccd0c309-c6ee-4af7-b1de-3fad1a570ba3", true, null, 1007 },
                    { "e7b134af-9965-4141-b17e-fb619d428f5e", true, null, 1004 },
                    { "5c0f6030-b560-4c86-8684-7371e08cb93e", true, null, 1004 },
                    { "cf150e7f-3484-411e-8c50-ce21e08155ca", true, null, 1004 },
                    { "740fe28c-c3b5-447a-941d-fe097aeaa64d", true, null, 1004 },
                    { "55354e85-719f-4574-9d12-d75e0c1dff6e", true, null, 1004 },
                    { "f6e26f95-ce3c-4717-9c74-47b9135d08b4", true, null, 1007 },
                    { "09300996-9d7f-41aa-93e1-bd6d2ea5aaf6", true, null, 1006 },
                    { "6c4ccb8e-81c0-4816-8afc-800ad4ca6585", true, null, 1007 },
                    { "53ba3875-0c3e-4f1a-b7fb-d8c6533b1805", true, null, 1005 },
                    { "b78e5bef-c48d-40d3-9cfc-d7592a95eec3", true, null, 1005 },
                    { "8d6e31a0-4855-4b47-b122-41f776cd49e0", true, null, 1005 },
                    { "a97bfc68-db96-4bf4-b5d4-e2025ddf0abe", true, null, 1005 },
                    { "eb270990-95da-4bef-bc4c-7c8685ec51d1", true, null, 1007 },
                    { "6af86a4b-5ea4-4be5-bcd4-09bb86121476", true, null, 1006 },
                    { "84eaf3b6-ca0f-47a1-b81d-663e51fbbcc6", true, null, 1006 },
                    { "ff6c32df-c143-48da-8fc2-b5b70a0bafd6", true, null, 1006 },
                    { "a1f7d267-e141-4b30-98ca-5aedc3245b76", true, null, 1005 },
                    { "b5f66a6e-82f8-41f0-941d-3ddbf6c5677a", true, null, 1003 },
                    { "14457715-86de-492b-9a17-aa01cf09da2c", true, null, 1006 },
                    { "63452d64-82bd-49b8-b789-8be399946a90", true, null, 1003 },
                    { "c6a8ca4f-02c2-4e52-9e69-0b6e8a84215e", true, null, 1001 },
                    { "cc43a6d4-4b54-437d-88ac-578a905d5444", true, null, 1001 },
                    { "895af08d-c625-408f-a0eb-02f306539c19", true, null, 1001 },
                    { "94b1132a-dfd9-412b-9756-7235be2b6e7c", true, null, 1001 },
                    { "11e535aa-e333-4d59-92ce-8640453d5786", true, null, 1008 },
                    { "ae291c34-03d7-402e-a052-0201178b8577", true, null, 1008 },
                    { "3d5aad26-5afe-4e72-8b58-08f2fab723ff", true, null, 1008 },
                    { "bd5dd857-0ea7-4812-90ea-05e96b68ba8a", true, null, 1003 },
                    { "7c55f074-0f83-4f48-b454-3e48689c2594", true, null, 1002 },
                    { "1547d645-6caa-4fd5-a085-65df12fcca51", true, null, 1008 },
                    { "a37f9246-3301-4ea5-90ac-cdc1e974cc03", true, null, 1002 },
                    { "696880db-8afb-44e7-80a8-34b17b3481b5", true, null, 1002 },
                    { "600efbf2-1814-4841-be5f-b5d1f70247d9", true, null, 1002 },
                    { "c9927618-59d2-48c9-8207-a0c4c499758d", true, null, 1008 },
                    { "09f5ea33-6b22-4c1f-949d-1a1e55123503", true, null, 1003 },
                    { "72f54ae5-d3ce-4863-869a-11c1333a9c3f", true, null, 1003 },
                    { "e517d36d-7ed7-4fd1-aa3a-24c29622686a", true, null, 1002 }
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
