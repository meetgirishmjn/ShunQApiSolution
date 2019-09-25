using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class dbinit : Migration
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
                    { "9e07993a-9af4-4116-84de-a58981ed2b95", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "c142c757-39cc-4602-b4b3-c964f93e5c97", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" },
                    { "c4af9d2a-3cda-4172-8bad-a4fd1e5a31f4", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" }
                });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "53904331-5656-4085-9d9f-b0239a640b48", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(121), 25f, "9% Discount", true, 817.1f, 792.1f, "57", null, null },
                    { "506037ce-42a1-4cbb-b441-bdaa7b28bf53", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(102), 43f, "2% Discount", true, 425.65f, 382.65f, "56", null, null },
                    { "6f6fee41-a819-4a71-a884-a118ace0b9e1", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(82), 80f, "4% Discount", true, 295.3f, 215.3f, "55", null, null },
                    { "c5a1f533-f537-4236-a030-d85ba06aaa47", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(65), 143f, "2% Discount", true, 263.65f, 120.65f, "54", null, null },
                    { "820c69e0-6784-4b6d-80e1-92a423fbb7f4", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(48), 20f, "1% Discount", true, 51.85f, 31.85f, "53", null, null },
                    { "22f1c341-6b31-4716-8cae-b757356ebe37", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(30), 165f, "2% Discount", true, 503.95f, 338.95f, "52", null, null },
                    { "6a858a50-ee2a-4723-b8b9-484d1828f7a8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(13), 289f, "5% Discount", true, 712.75f, 423.75f, "51", null, null },
                    { "3719a6da-5f3c-48de-a300-9f8f52c48125", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9865), 207f, "7% Discount", true, 219.85f, 12.85f, "50", null, null },
                    { "ad4e1831-2ea8-48fa-98e2-0bd2eb381bb2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9774), 84f, "3% Discount", true, 218.85f, 134.85f, "45", null, null },
                    { "306efe4c-d244-4532-a8ff-15748eb8f8b2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9830), 209f, "3% Discount", true, 665.1f, 456.1f, "48", null, null },
                    { "c29f9437-0f6b-4afd-b492-73fd3b16c94b", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9809), 618f, "9% Discount", true, 674.1f, 56.1f, "47", null, null },
                    { "08297544-fe53-48b6-ad77-a49346f53621", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9791), 333f, "8% Discount", true, 475.25f, 142.25f, "46", null, null },
                    { "95b90a0d-8af3-46b9-b826-4c386abff41c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(138), 76f, "7% Discount", true, 659.55f, 583.55f, "58", null, null },
                    { "7b8cdb54-601e-4cb4-bd14-35f7b805e355", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9757), 355f, "8% Discount", true, 574.15f, 219.15f, "44", null, null },
                    { "51928079-920f-478a-9c85-efce91ae9e65", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9739), 712f, "6% Discount", true, 771.85f, 59.85f, "43", null, null },
                    { "88f84d86-09f1-48b7-834c-ca1332dcaee8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9722), 546f, "10% Discount", true, 741.5f, 195.5f, "42", null, null },
                    { "c03e34ef-f488-4c8a-981d-dc669af42889", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9848), 1f, "8% Discount", true, 234.55f, 233.55f, "49", null, null },
                    { "09410bf7-bc1c-45d3-af13-fe7f49cc1096", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(155), 526f, "6% Discount", true, 927.2f, 401.2f, "59", null, null },
                    { "20267b35-d012-45af-9fb2-cada0e000fa3", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(308), 659f, "4% Discount", true, 669.5f, 10.5f, "64", null, null },
                    { "f4c15831-b9f8-4657-b809-99b8a5d12ff4", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(189), 47f, "1% Discount", true, 916.5f, 869.5f, "61", null, null },
                    { "fc682799-e402-4a6d-882d-e5f73138b0f2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(623), 9f, "4% Discount", true, 20.65f, 11.65f, "77", null, null },
                    { "038e7b71-7f3c-4da1-b63e-e1c6ce836f4d", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(605), 446f, "9% Discount", true, 886.7f, 440.7f, "76", null, null },
                    { "1ff50bec-c69a-4ebd-8da4-ca154c6690c7", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(588), 80f, "3% Discount", true, 721.35f, 641.35f, "75", null, null },
                    { "37da441c-172c-4aa5-9031-10c1619bdd42", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(568), 628f, "3% Discount", true, 681.5f, 53.5f, "74", null, null },
                    { "1859c5fe-e04e-47a5-b8e1-4e978c527a7b", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(471), 18f, "5% Discount", true, 69.9f, 51.9f, "73", null, null },
                    { "ea58aec8-b7d2-4526-91c5-1d723ddd855a", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(453), 227f, "6% Discount", true, 285.25f, 58.25f, "72", null, null },
                    { "2114d09d-34e9-495c-8144-76fc2c18af8c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(432), 580f, "7% Discount", true, 653.25f, 73.25f, "71", null, null },
                    { "7158ff82-f259-4c80-a79b-d541da8cf79c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(172), 145f, "6% Discount", true, 861.85f, 716.85f, "60", null, null },
                    { "6f77740d-1ba6-497b-a3d2-08f64f4d3612", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(414), 801f, "5% Discount", true, 852.45f, 51.45f, "70", null, null },
                    { "22851fc1-cd8e-4ff8-9af0-c6f2daaef3d3", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(380), 701f, "5% Discount", true, 923.8f, 222.8f, "68", null, null },
                    { "cdd3b4d2-5424-48b5-bd8a-6ffb0d0b736a", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(364), 106f, "8% Discount", true, 854.2f, 748.2f, "67", null, null },
                    { "7b71d8fb-641a-4674-900f-536012918216", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(346), 322f, "3% Discount", true, 781.55f, 459.55f, "66", null, null },
                    { "2268429b-73e0-4dc7-a80a-d3caa77eb6d8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(326), 261f, "2% Discount", true, 402.8f, 141.8f, "65", null, null },
                    { "d49f1919-b488-4ebe-91ba-537e4071d716", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9705), 513f, "9% Discount", true, 570.6f, 57.6f, "41", null, null },
                    { "53463972-7a9a-4a8f-890a-ae4428f7d6a7", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(287), 497f, "7% Discount", true, 886.75f, 389.75f, "63", null, null },
                    { "a8e21cae-7bf9-4420-a787-1c3361d7e287", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(206), 238f, "4% Discount", true, 610.15f, 372.15f, "62", null, null },
                    { "6c2aa8ef-cd44-4b52-9954-f6a1cf0dd236", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 726, DateTimeKind.Local).AddTicks(398), 85f, "8% Discount", true, 138.45f, 53.45f, "69", null, null },
                    { "89f90d76-01f5-489d-accb-f395c168d516", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9687), 128f, "7% Discount", true, 250.3f, 122.3f, "40", null, null },
                    { "752bd9e8-ff5b-4f00-a649-e135afc2ee08", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9526), 5f, "6% Discount", true, 54.5f, 49.5f, "35", null, null },
                    { "3ec0611e-b823-4466-8321-b2a9f977d357", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9649), 30f, "8% Discount", true, 41.2f, 11.2f, "38", null, null },
                    { "1f935b77-112a-4130-b75d-b63bfbd08324", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9112), 184f, "3% Discount", true, 363.3f, 179.3f, "16", null, null },
                    { "30bb5143-51f8-4616-8495-1b60e91c6d7e", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9090), 276f, "3% Discount", true, 384.35f, 108.35f, "15", null, null },
                    { "04024db1-9b95-4e8b-b8e2-c66180bb39a8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9068), 217f, "3% Discount", true, 723.35f, 506.35f, "14", null, null },
                    { "2be4f84d-7a15-4cb5-adb2-161c84404fc1", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8904), 25f, "5% Discount", true, 115.35f, 90.35f, "13", null, null },
                    { "767753ff-b6e0-4249-842f-c50f0f730853", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8886), 130f, "3% Discount", true, 182.25f, 52.25f, "12", null, null },
                    { "ef29a907-ea50-4a43-bb93-69b114b3293b", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8869), 230f, "9% Discount", true, 268.95f, 38.95f, "11", null, null },
                    { "03e12bef-01a3-4961-83e1-bff0ef327867", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8850), 521f, "9% Discount", true, 622.95f, 101.95f, "10", null, null },
                    { "3764a103-d11b-4314-ade3-caacbab13605", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9128), 79f, "8% Discount", true, 649.95f, 570.95f, "17", null, null },
                    { "7252a365-435e-4dfb-a021-93b204048bac", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8830), 159f, "8% Discount", true, 196.7f, 37.7f, "9", null, null },
                    { "e00b8e19-025e-40e0-8288-a94160816e68", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8780), 42f, "2% Discount", true, 738.55f, 696.55f, "7", null, null },
                    { "176b9471-ae83-4394-80a1-98f984336017", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8763), 90f, "8% Discount", true, 785.5f, 695.5f, "6", null, null },
                    { "878715c9-81a5-4f09-a782-7bc1a6183e3c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8738), 382f, "8% Discount", true, 558.85f, 176.85f, "5", null, null },
                    { "25bc3fda-aab5-462b-86a7-32e06a131ec6", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8721), 63f, "5% Discount", true, 108.9f, 45.9f, "4", null, null },
                    { "3e333d23-5069-46d9-a282-061f59d092a2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8702), 98f, "6% Discount", true, 748.1f, 650.1f, "3", null, null },
                    { "bf659f5f-a714-4ab6-99fc-364d220fe012", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8663), 124f, "1% Discount", true, 250.95f, 126.95f, "2", null, null },
                    { "031d6e3b-1e2d-4229-81eb-029559c16f5c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(6352), 209f, "8% Discount", true, 236.95f, 27.95f, "1", null, null },
                    { "98e97e52-e7cf-455d-a428-b4c544fcb060", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(8814), 193f, "3% Discount", true, 849.6f, 656.6f, "8", null, null },
                    { "f74941b4-8fda-4f3e-8210-223856265666", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9667), 47f, "4% Discount", true, 264.7f, 217.7f, "39", null, null },
                    { "c6b427ba-e79d-42c0-a87e-80ef9844a796", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9149), 303f, "3% Discount", true, 640.95f, 337.95f, "18", null, null },
                    { "733dfc16-e4f6-4b15-8a79-aaee8551bebb", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9183), 513f, "4% Discount", true, 999.65f, 486.65f, "20", null, null },
                    { "8dd4adc9-355b-480f-940d-10f362928694", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9559), 12f, "5% Discount", true, 49.4f, 37.4f, "37", null, null },
                    { "6b70573d-d455-4257-87db-19d4d1427f13", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9543), 944f, "1% Discount", true, 978.3f, 34.3f, "36", null, null },
                    { "1dd831cb-de13-4101-b22b-3bb6c0b51cc9", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9508), 849f, "10% Discount", true, 909.1f, 60.1f, "34", null, null },
                    { "387b9180-5ee1-41a9-b9e3-c44db31296e8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9489), 74f, "8% Discount", true, 144.8f, 70.8f, "33", null, null },
                    { "4c3de8dd-ad03-4932-bd46-68c0c56aaa28", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9471), 79f, "5% Discount", true, 924.25f, 845.25f, "32", null, null },
                    { "b4669e17-5e4a-482f-9e7f-fa5dbc9f5ee8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9451), 682f, "1% Discount", true, 902.75f, 220.75f, "31", null, null },
                    { "8dc1badb-9083-4ea7-a533-55109f310668", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9165), 95f, "3% Discount", true, 422.4f, 327.4f, "19", null, null },
                    { "2592863e-221d-4c0d-a45e-ef088ebbb0aa", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9411), 240f, "6% Discount", true, 912.9f, 672.9f, "29", null, null },
                    { "4b7b74e2-c4b0-4b30-8305-2cf80d44dd3c", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9434), 2f, "7% Discount", true, 12.6f, 10.6f, "30", null, null },
                    { "ba0bf55c-4b73-4b1d-9cb9-04cf5a8271af", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9375), 471f, "10% Discount", true, 502.6f, 31.6f, "27", null, null },
                    { "bf6ee80e-4ffe-4223-b5c6-d9d09426d0fc", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9355), 387f, "8% Discount", true, 525.3f, 138.3f, "26", null, null },
                    { "f3cc9a19-cc23-4beb-9335-eaec368b26d3", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9274), 80f, "6% Discount", true, 878.75f, 798.75f, "25", null, null },
                    { "fb31083a-7d1a-41ad-8fe5-210cc8660d67", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9256), 378f, "7% Discount", true, 928.35f, 550.35f, "24", null, null },
                    { "f507606a-ae3e-47c8-a917-2674683f23e0", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9235), 576f, "6% Discount", true, 944.5f, 368.5f, "23", null, null },
                    { "58ed0d89-3f91-405f-8e9b-1c27a35f7d89", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9218), 35f, "10% Discount", true, 330.1f, 295.1f, "22", null, null },
                    { "3f4df80e-497f-4a7d-9f34-9507f29f9903", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9200), 172f, "5% Discount", true, 745.5f, 573.5f, "21", null, null },
                    { "8780e4ae-7ec1-4bfa-b8d6-f3f5d2a9f216", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 725, DateTimeKind.Local).AddTicks(9393), 215f, "4% Discount", true, 470.95f, 255.95f, "28", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 4, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7830), "Cheeses", "Dairy Products", null, null },
                    { 5, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7842), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null },
                    { 3, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7836), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 8, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7816), "Seaweed and fish", "Seafood", null, null },
                    { 7, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7804), "Dried fruit and bean curd", "Produce", null, null },
                    { 6, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7811), "Prepared meats", "Meat/Poultry", null, null },
                    { 2, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(7783), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null },
                    { 1, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 720, DateTimeKind.Local).AddTicks(6309), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8921), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8916), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8912), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8907), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8902), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8896), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8891), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8885), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8880), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8875), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8869), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8859), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8850), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8732), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8725), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8718), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8926), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8711), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8937), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8942), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9164), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9159), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9154), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9148), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9079), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9073), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9068), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8932), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9061), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9052), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9047), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9041), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9030), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9025), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9020), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9015), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(9056), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8701), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8665), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8655), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8055), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8043), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8032), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7781), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7770), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7756), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7740), "", true, "Ikura", "", "10.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8069), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7725), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7700), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7685), "", true, "Grandma's Boysenberry Spread", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7662), "", true, "Chef Anton's Gumbo Mix", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7650), "", true, "Chef Anton's Cajun Seasoning", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7634), "", true, "Aniseed Syrup", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7489), "", true, "Chang", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 722, DateTimeKind.Local).AddTicks(6201), "", true, "Chai", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(7716), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8101), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8091), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8565), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8646), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8636), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8626), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8619), "", true, "Sasquatch Ale", "", "34.jpg", null, null },
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8602), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8588), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8578), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8113), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8223), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8209), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8197), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8188), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8174), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8168), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8149), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8134), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[] { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 723, DateTimeKind.Local).AddTicks(8124), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null });

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
                    { 1004, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 612, DateTimeKind.Local).AddTicks(6567), "", "Stationery", null, null },
                    { 1003, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 612, DateTimeKind.Local).AddTicks(6563), "", "Kid Care/Toys", null, null },
                    { 1005, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 612, DateTimeKind.Local).AddTicks(6569), "", "Electronics", null, null },
                    { 1001, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 612, DateTimeKind.Local).AddTicks(3661), "", "Departmental Stores", null, null },
                    { 1002, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 612, DateTimeKind.Local).AddTicks(6544), "", "Grocery", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Email", "EmailVerified", "FirstName", "FullName", "Gender", "ImageId", "IsActive", "IsDeleted", "LastName", "MobileNumber", "MobileVerified", "Name", "Password", "Props", "UpdatedBy", "UpdatedOn", "UserType" },
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 606, DateTimeKind.Local).AddTicks(2691), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "Admin", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null, null });

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
                    { 1001, 1001, "STR-1-Banner.jpg", "STR-1", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 613, DateTimeKind.Local).AddTicks(9079), "A top company in the category Supermarkets, also known for Mineral Water Dealers, Spice Retailers, Raisin Retailers", "STR-1-Thumb.jpg", true, "AB Supermarket", "AB Supermarket", null, null },
                    { 1007, 1007, "STR-7-Banner.jpg", "STR-7", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1666), "A unique shopping experience by putting you first. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. They make products available at low prices resultingin more savings. The heart of their core values lies in the commitment towards providing quality service.", "STR-7-Thumb.jpg", true, "Village Hyper Market", "Village Hyper Market", null, null },
                    { 1006, 1006, "STR-6-Banner.jpg", "STR-6", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1428), "This local grocery store is always looking to deliver a unique shopping experience by putting you first. They understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. They make products available at low prices resulting in more savings. When it comes to customer value, they have progressed in leaps & bounds.", "STR-6-Thumb.jpg", true, "Metro Cash And Carry", "Metro Cash And Carry", null, null },
                    { 1005, 1005, "STR-5-Banner.jpg", "STR-5", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1420), "One of the most popular supermarket chains of India, they offer an urban shopping environment for all kinds of home and personal care needs. Their stores are a place where one can find groceries, fresh fruits and veggies, confectioneries, personal care items, fashionable clothing for men, women, and kids, and so much more! They are a brand that the consumers trust for their dedication towards quality and providing a seamless shopping experience.", "STR-5-Thumb.jpg", true, "Big Bazaar", "Big Bazaar", null, null },
                    { 1004, 1004, "STR-4-Banner.jpg", "STR-4", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1417), "DMart is a one stop supermarket chain that aims to offer customers a wide range of basic home and personal products under one roof. Each DMart store stocks home utility products - including food, toiletries, beauty products, garments, kitchenware, bed and bath linen, home appliances and more available at competitive prices that their customers appreciate.", "STR-4-Thumb.jpg", true, "D Mart", "D Mart", null, null },
                    { 1003, 1003, "STR-3-Banner.jpg", "STR-3", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1413), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-3-Thumb.jpg", true, "The Big Market", "The Big Market", null, null },
                    { 1002, 1002, "STR-2-Banner.jpg", "STR-2", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1388), "This neighborhood grocery store is committed to delight customers and gauge their success through efficient service and a smile. The friendly store staff are always close at hand to assist you. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-2-Thumb.jpg", true, "Imperio Market", "Imperio Market", null, null },
                    { 1008, 1008, "STR-8-Banner.jpg", "STR-8", 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 614, DateTimeKind.Local).AddTicks(1672), "We understand the value of your time and will get you what you are looking for. They have almost all products that you may require on a daily basis. With exclusive offers and best prices, they ensure the customers more than one reason to come back for more. The heart of their core value lies in the commitment toward providing quality service.", "STR-8-Thumb.jpg", true, "Star Bazaar", "Star Bazaar", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "RoleMasterId", "UpdatedBy", "UpdatedOn", "UserMasterId" },
                values: new object[] { 1, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 610, DateTimeKind.Local).AddTicks(9446), true, 1, 1L, new DateTime(2019, 9, 26, 0, 33, 34, 610, DateTimeKind.Local).AddTicks(5206), 1L });

            migrationBuilder.InsertData(
                table: "StoreCategoryXrefs",
                columns: new[] { "Id", "StoreCategoryId", "StoreMasterId" },
                values: new object[,]
                {
                    { 1001L, 1001, 1001 },
                    { 1022L, 1005, 1007 },
                    { 1014L, 1004, 1007 },
                    { 1006L, 1002, 1007 },
                    { 1021L, 1005, 1006 },
                    { 1013L, 1004, 1006 },
                    { 1012L, 1003, 1006 },
                    { 1020L, 1005, 1005 },
                    { 1011L, 1003, 1005 },
                    { 1005L, 1002, 1005 },
                    { 1015L, 1004, 1008 },
                    { 1019L, 1005, 1004 },
                    { 1018L, 1005, 1003 },
                    { 1009L, 1003, 1003 },
                    { 1003L, 1001, 1003 },
                    { 1017L, 1005, 1002 },
                    { 1008L, 1003, 1002 },
                    { 1002L, 1001, 1002 },
                    { 1016L, 1005, 1001 },
                    { 1007L, 1003, 1001 },
                    { 1004L, 1002, 1001 },
                    { 1010L, 1003, 1004 },
                    { 1023L, 1005, 1008 }
                });

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
                name: "StoreMasters");

            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropTable(
                name: "UserMasters");

            migrationBuilder.DropTable(
                name: "AddressMasters");
        }
    }
}
