using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class init : Migration
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
                    UpdatedBy = table.Column<long>(nullable: true)
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
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreMasters_AddressMasters_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "559f186c-65c4-4b4d-a209-41f7c41a1ee0", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(1240), 107f, "3% Discount", true, 155.4f, 48.4f, "1", null, null },
                    { "e2b46c3a-871b-4ec3-bb4a-08d6f8ae4382", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6585), 63f, "6% Discount", true, 306.4f, 243.4f, "57", null, null },
                    { "7355b3f9-cb0d-43f5-8fc8-624d542308f5", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6550), 49f, "8% Discount", true, 309.3f, 260.3f, "56", null, null },
                    { "18de7091-fb54-4576-9e4d-96dd247227bd", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6509), 434f, "4% Discount", true, 491.8f, 57.8f, "55", null, null },
                    { "10621f98-a599-4afb-a1dd-e3309deadc56", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6478), 402f, "5% Discount", true, 532.5f, 130.5f, "54", null, null },
                    { "921eea92-d4e6-4abc-95a9-81135e3047a8", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6445), 414f, "3% Discount", true, 690.85f, 276.85f, "53", null, null },
                    { "ece00b78-d3d7-43d7-951a-5b1dc88f1f64", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6415), 811f, "3% Discount", true, 947.75f, 136.75f, "52", null, null },
                    { "c5c5c958-0f7e-496d-9a29-f7287eadb0dd", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6384), 237f, "10% Discount", true, 749.65f, 512.65f, "51", null, null },
                    { "ce5bd630-90d2-41d3-b266-8d2a3dd0c238", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6352), 300f, "2% Discount", true, 513.25f, 213.25f, "50", null, null },
                    { "97ee2eab-9e7c-4558-be71-016e208171aa", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6322), 928f, "6% Discount", true, 986.75f, 58.75f, "49", null, null },
                    { "36a124d4-8a3c-489c-a1d1-afb3977482b0", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6286), 39f, "3% Discount", true, 230.45f, 191.45f, "48", null, null },
                    { "49c35008-42aa-445e-bb4b-06c23b4d6655", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6255), 21f, "4% Discount", true, 234.4f, 213.4f, "47", null, null },
                    { "508bc550-5586-434a-9f42-24f30c330de3", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6225), 1f, "9% Discount", true, 37.95f, 36.95f, "46", null, null },
                    { "3d0d48e0-8f03-4adf-a6fc-5d16385c5b5f", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6196), 117f, "2% Discount", true, 497.95f, 380.95f, "45", null, null },
                    { "c4691f57-6d7d-4d15-83d0-915999c96c9c", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6166), 280f, "7% Discount", true, 767.55f, 487.55f, "44", null, null },
                    { "01edf23b-c3d0-433f-b86c-755b6ccd9a0d", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6124), 114f, "6% Discount", true, 244.95f, 130.95f, "43", null, null },
                    { "6f434ddc-7e5a-4958-8eb1-3c67720edb34", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6614), 75f, "5% Discount", true, 139.7f, 64.7f, "58", null, null },
                    { "e226bdf8-fd0c-4e61-8476-a421a3c47b15", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6646), 298f, "3% Discount", true, 625.1f, 327.1f, "59", null, null },
                    { "f232f6be-a946-4b92-a203-94c006795c41", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6676), 32f, "5% Discount", true, 43.35f, 11.35f, "60", null, null },
                    { "5b96658f-293a-407d-b91b-f805ab9de405", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6708), 326f, "8% Discount", true, 614.1f, 288.1f, "61", null, null },
                    { "a7807a1f-492f-455f-b46b-a6439b1b689f", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7230), 655f, "8% Discount", true, 927.45f, 272.45f, "77", null, null },
                    { "9a3a465d-14f0-4ced-8a4a-83d12ac8f87a", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7199), 689f, "8% Discount", true, 885.5f, 196.5f, "76", null, null },
                    { "d4231bd9-fbcd-4120-9ffd-c53138fc6644", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7171), 386f, "10% Discount", true, 751.5f, 365.5f, "75", null, null },
                    { "5d239979-3acf-490d-b11a-14a2ae583f5e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7139), 370f, "6% Discount", true, 547.5f, 177.5f, "74", null, null },
                    { "4f38f211-8622-4c6e-9374-47ef619ff806", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7109), 113f, "5% Discount", true, 180.8f, 67.8f, "73", null, null },
                    { "f210e059-15b0-4aee-ad9e-aa3e0d3a0f2d", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7073), 642f, "1% Discount", true, 687.45f, 45.45f, "72", null, null },
                    { "b6b109dd-f966-4d2f-b2c3-bc9843cfcbf5", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7043), 111f, "2% Discount", true, 569.55f, 458.55f, "71", null, null },
                    { "a31865c7-2784-4ab6-b50f-f9b29736d63e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6091), 84f, "3% Discount", true, 223.6f, 139.6f, "42", null, null },
                    { "693fd99f-c2ae-4ac9-b5d8-1d00ad5dc793", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(7012), 8f, "8% Discount", true, 101.8f, 93.8f, "70", null, null },
                    { "163619cc-fd20-4d23-ab4e-e46579e08d4c", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6955), 838f, "8% Discount", true, 984.5f, 146.5f, "68", null, null },
                    { "2beda3c5-20ff-478a-947d-02fb9f0816a2", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6925), 811f, "9% Discount", true, 929.3f, 118.3f, "67", null, null },
                    { "c1a1b5f2-99e1-4cfb-9016-28e1893d2dfc", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6868), 241f, "8% Discount", true, 582.15f, 341.15f, "66", null, null },
                    { "34f0959f-406e-4f83-9de8-bf255ff39a85", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6834), 442f, "5% Discount", true, 929.9f, 487.9f, "65", null, null },
                    { "292265fc-61ba-481d-9881-3a448f415571", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6799), 8f, "4% Discount", true, 54.4f, 46.4f, "64", null, null },
                    { "be7d0ac9-718f-4241-af4c-e56e21cfc88e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6768), 169f, "8% Discount", true, 566.75f, 397.75f, "63", null, null },
                    { "1cab2bb9-ba23-4dad-bb90-53c9ac3486b2", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6738), 160f, "3% Discount", true, 621.8f, 461.8f, "62", null, null },
                    { "850a9bc6-26ae-47e1-9a71-0fd4f1f9e4af", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6982), 456f, "7% Discount", true, 633.45f, 177.45f, "69", null, null },
                    { "8dfeafbd-0024-421d-aaee-0a50559bf54c", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6055), 527f, "6% Discount", true, 772.5f, 245.5f, "41", null, null },
                    { "3e88afc9-dae0-48e5-ab5b-658fe76e7811", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(6012), 73f, "3% Discount", true, 245.7f, 172.7f, "40", null, null },
                    { "a4f59aa6-9f91-4871-96ab-789a2e289008", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5191), 247f, "4% Discount", true, 406.1f, 159.1f, "19", null, null },
                    { "911f022a-d985-4611-bca1-01bbe0ff1e1b", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5159), 52f, "9% Discount", true, 65.65f, 13.65f, "18", null, null },
                    { "8fcb3194-2b70-41f9-8578-3e8ce8118f86", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5125), 85f, "10% Discount", true, 160.1f, 75.1f, "17", null, null },
                    { "d6d2ef32-7fb6-4046-b7df-34b418c9748b", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5086), 427f, "1% Discount", true, 543.75f, 116.75f, "16", null, null },
                    { "80403918-2882-46a7-ab49-c9e44d5c4594", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5056), 157f, "5% Discount", true, 324.55f, 167.55f, "15", null, null },
                    { "da904bca-dc3d-4311-8cc4-927230fe5745", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5026), 136f, "6% Discount", true, 798.8f, 662.8f, "14", null, null },
                    { "ddb833e5-472c-4809-8023-705308b30cd0", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4995), 265f, "10% Discount", true, 302.2f, 37.2f, "13", null, null },
                    { "90d35b5b-b214-4221-95af-8ab79fa873e8", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4963), 667f, "1% Discount", true, 793.65f, 126.65f, "12", null, null },
                    { "96f19c31-5747-4d0f-9e18-958542aff121", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4931), 326f, "5% Discount", true, 634.5f, 308.5f, "11", null, null },
                    { "8d2b5d8e-cb5e-47b2-a6ca-202c323a38b9", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4899), 435f, "1% Discount", true, 721.4f, 286.4f, "10", null, null },
                    { "92c08af8-f8b3-4b19-bf8a-c45c7a6c6d2f", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4866), 286f, "2% Discount", true, 319.25f, 33.25f, "9", null, null },
                    { "dcc142e5-9802-4624-91fc-869d32e0d57b", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4821), 721f, "9% Discount", true, 857.75f, 136.75f, "8", null, null },
                    { "0accdb6e-8c8b-4413-a267-f01ae66fd778", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4770), 160f, "8% Discount", true, 852.7f, 692.7f, "7", null, null },
                    { "62999aee-4ed7-4f8d-8d9f-9136aa8ef1bc", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4737), 323f, "10% Discount", true, 835.95f, 512.95f, "6", null, null },
                    { "37307d61-04fc-4d27-b0b5-ab7db9a90a16", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4697), 247f, "4% Discount", true, 458.6f, 211.6f, "5", null, null },
                    { "492af9ef-1c1f-42b0-a3ba-ca6ccf8fc639", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4665), 553f, "5% Discount", true, 729.3f, 176.3f, "4", null, null },
                    { "10e89ca1-646e-44f7-bcf6-ff3e9b3db750", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5987), 313f, "4% Discount", true, 479.1f, 166.1f, "39", null, null },
                    { "f7981954-9946-4139-9bc1-c485b13d5388", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5346), 110f, "10% Discount", true, 162.35f, 52.35f, "20", null, null },
                    { "ffe92551-aada-4ec3-9851-d3ecf3f378a2", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5380), 357f, "5% Discount", true, 808.7f, 451.7f, "21", null, null },
                    { "9d853c9a-1398-4cac-95d5-473ae6fc9e56", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5411), 6f, "5% Discount", true, 186.75f, 180.75f, "22", null, null },
                    { "4d9be568-d1ec-4039-b0f4-cc74a1ace549", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5956), 154f, "7% Discount", true, 311.2f, 157.2f, "38", null, null },
                    { "4650f88c-f379-433c-9b41-7a791db50d49", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5926), 248f, "7% Discount", true, 261.35f, 13.35f, "37", null, null },
                    { "5bd7c92f-8b4f-4426-b4b5-837d10d58bb0", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5893), 517f, "10% Discount", true, 538.3f, 21.3f, "36", null, null },
                    { "2ced9a67-f3bc-4fad-a9fe-5810a09061a0", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5843), 347f, "6% Discount", true, 449.45f, 102.45f, "35", null, null },
                    { "21a77a62-4690-4b63-8f60-be20a76527a5", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5812), 315f, "6% Discount", true, 768.75f, 453.75f, "34", null, null },
                    { "61cd8be2-96d2-4730-bbf3-f1c2299b519e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5773), 86f, "10% Discount", true, 905.15f, 819.15f, "33", null, null },
                    { "fdb291f2-8309-4d12-8da8-d6b24916ddcc", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5736), 3f, "2% Discount", true, 19.4f, 16.4f, "32", null, null },
                    { "d93d59ce-2866-4802-86c3-9fd90a48f922", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4634), 10f, "7% Discount", true, 237.9f, 227.9f, "3", null, null },
                    { "5f104119-3c81-4ffb-b40a-af83584007ca", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5695), 508f, "2% Discount", true, 993.2f, 485.2f, "31", null, null },
                    { "4fbc2333-248e-4175-8fe3-db46aab8d74e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5635), 135f, "10% Discount", true, 564.5f, 429.5f, "29", null, null },
                    { "4ea5e0d9-cb67-4f8f-b53a-bc62a01b2e13", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5604), 399f, "4% Discount", true, 497.4f, 98.4f, "28", null, null },
                    { "c2e5fb29-b20d-4aa7-8d13-d7df1e662ca6", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5571), 19f, "5% Discount", true, 204.25f, 185.25f, "27", null, null },
                    { "5ae6d684-ab8e-48a2-9112-008d7cc13939", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5541), 116f, "2% Discount", true, 189.35f, 73.35f, "26", null, null },
                    { "b3669347-9ed5-4adb-8f6f-1bd2db05e50b", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5511), 241f, "6% Discount", true, 395.45f, 154.45f, "25", null, null },
                    { "9b5aea71-6f6d-483a-94b9-03153876399e", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5472), 668f, "5% Discount", true, 928.25f, 260.25f, "24", null, null },
                    { "0bd18815-a943-4f4c-abf2-129768b0effa", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5441), 193f, "1% Discount", true, 541.5f, 348.5f, "23", null, null },
                    { "be6bc704-c1bb-451e-87c1-aab2b6c6eec1", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(5665), 501f, "10% Discount", true, 756.95f, 255.95f, "30", null, null },
                    { "35552959-f8d9-4ee3-b061-1dc440f7f740", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 505, DateTimeKind.Local).AddTicks(4570), 431f, "10% Discount", true, 589.3f, 158.3f, "2", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 3, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4437), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 5, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4443), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null },
                    { 8, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4414), "Seaweed and fish", "Seafood", null, null },
                    { 4, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4429), "Cheeses", "Dairy Products", null, null },
                    { 7, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4400), "Dried fruit and bean curd", "Produce", null, null },
                    { 1, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(2046), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null },
                    { 6, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4408), "Prepared meats", "Meat/Poultry", null, null },
                    { 2, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 499, DateTimeKind.Local).AddTicks(4376), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5699), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5689), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5681), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5672), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5662), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5642), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5632), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5708), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5623), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5604), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5595), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5586), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5577), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5569), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5559), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5550), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5613), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5909), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5717), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5540), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5899), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5890), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5882), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5873), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5865), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5856), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5847), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5726), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5838), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5821), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5810), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5781), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5772), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5763), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5753), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5744), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5829), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5735), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5520), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5511), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5283), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5273), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5264), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5255), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5245), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5236), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5227), "", true, "Ikura", "", "10.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5529), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5213), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5196), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5187), "", true, "Grandma's Boysenberry Spread", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5169), "", true, "Chef Anton's Gumbo Mix", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5130), "", true, "Chef Anton's Cajun Seasoning", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5119), "", true, "Aniseed Syrup", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5030), "", true, "Chang", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 501, DateTimeKind.Local).AddTicks(2704), "", true, "Chai", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5203), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5304), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5292), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5335), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5502), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5493), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5472), "", true, "Sasquatch Ale", "", "34.jpg", null, null },
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5459), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5450), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5441), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5313), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5422), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5432), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5404), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5394), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5385), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5374), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5364), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5352), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null },
                    { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5344), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 502, DateTimeKind.Local).AddTicks(5413), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "RoleMasters",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[,]
                {
                    { 5, 1, "", "User" },
                    { 1, 1, "", "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "UserMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Email", "EmailVerified", "FirstName", "FullName", "Gender", "ImageId", "IsActive", "IsDeleted", "LastName", "MobileNumber", "MobileVerified", "Name", "Password", "Props", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 375, DateTimeKind.Local).AddTicks(3778), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "Admin", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null });

            migrationBuilder.InsertData(
                table: "ProductCategoryXrefs",
                columns: new[] { "Id", "ProductCategoryId", "ProductMasterId" },
                values: new object[,]
                {
                    { 1L, 1, "1" },
                    { 56L, 5, "56" },
                    { 55L, 6, "55" },
                    { 54L, 6, "54" },
                    { 53L, 6, "53" },
                    { 52L, 5, "52" },
                    { 51L, 7, "51" },
                    { 50L, 3, "50" },
                    { 49L, 3, "49" },
                    { 48L, 3, "48" },
                    { 47L, 3, "47" },
                    { 46L, 8, "46" },
                    { 45L, 8, "45" },
                    { 44L, 2, "44" },
                    { 43L, 1, "43" },
                    { 42L, 5, "42" },
                    { 57L, 5, "57" },
                    { 58L, 8, "58" },
                    { 59L, 4, "59" },
                    { 60L, 4, "60" },
                    { 76L, 1, "76" },
                    { 75L, 1, "75" },
                    { 74L, 7, "74" },
                    { 73L, 8, "73" },
                    { 72L, 4, "72" },
                    { 71L, 4, "71" },
                    { 70L, 1, "70" },
                    { 41L, 8, "41" },
                    { 69L, 4, "69" },
                    { 67L, 1, "67" },
                    { 66L, 2, "66" },
                    { 65L, 2, "65" },
                    { 64L, 5, "64" },
                    { 63L, 2, "63" },
                    { 62L, 3, "62" },
                    { 61L, 2, "61" },
                    { 68L, 3, "68" },
                    { 40L, 8, "40" },
                    { 39L, 1, "39" },
                    { 38L, 1, "38" },
                    { 17L, 6, "17" },
                    { 16L, 3, "16" },
                    { 15L, 2, "15" },
                    { 14L, 7, "14" },
                    { 13L, 8, "13" },
                    { 12L, 4, "12" },
                    { 11L, 4, "11" },
                    { 18L, 8, "18" },
                    { 10L, 8, "10" },
                    { 8L, 2, "8" },
                    { 7L, 7, "7" },
                    { 6L, 2, "6" },
                    { 5L, 2, "5" },
                    { 4L, 2, "4" },
                    { 3L, 2, "3" },
                    { 2L, 1, "2" },
                    { 9L, 6, "9" },
                    { 77L, 2, "77" },
                    { 19L, 3, "19" },
                    { 21L, 3, "21" },
                    { 37L, 8, "37" },
                    { 36L, 8, "36" },
                    { 35L, 1, "35" },
                    { 34L, 1, "34" },
                    { 33L, 4, "33" },
                    { 32L, 4, "32" },
                    { 31L, 4, "31" },
                    { 20L, 3, "20" },
                    { 30L, 8, "30" },
                    { 28L, 7, "28" },
                    { 27L, 3, "27" },
                    { 26L, 3, "26" },
                    { 25L, 3, "25" },
                    { 24L, 1, "24" },
                    { 23L, 5, "23" },
                    { 22L, 5, "22" },
                    { 29L, 6, "29" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "IsActive", "RoleMasterId", "UpdatedBy", "UpdatedOn", "UserMasterId" },
                values: new object[] { 1, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 380, DateTimeKind.Local).AddTicks(2741), true, 1, 1L, new DateTime(2019, 9, 16, 16, 44, 21, 379, DateTimeKind.Local).AddTicks(8947), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_LogInSessions_UserMasterId",
                table: "LogInSessions",
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
                name: "LogInSessions");

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
                name: "UserRoles");

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
