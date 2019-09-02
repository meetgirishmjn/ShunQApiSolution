using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class Init : Migration
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<string>(nullable: true),
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
                table: "ProductCategories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Description", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(731), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null, null },
                    { 2, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1406), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null, null },
                    { 7, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1415), "Dried fruit and bean curd", "Produce", null, null },
                    { 6, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1419), "Prepared meats", "Meat/Poultry", null, null },
                    { 8, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1421), "Seaweed and fish", "Seafood", null, null },
                    { 4, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1427), "Cheeses", "Dairy Products", null, null },
                    { 3, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1430), "Desserts, candies, and sweet breads", "Confections", null, null },
                    { 5, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(1432), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductMasters",
                columns: new[] { "Id", "BannerImage", "Code", "CompanyId", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "ShortName", "ThumbImage", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { "57", "57.jpg", "57", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3652), "", true, "Ravioli Angelo", "", "57.jpg", null, null },
                    { "56", "56.jpg", "56", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3649), "", true, "Gnocchi di nonna Alice", "", "56.jpg", null, null },
                    { "55", "55.jpg", "55", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3646), "", true, "Pâté chinois", "", "55.jpg", null, null },
                    { "54", "54.jpg", "54", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3643), "", true, "Tourtière", "", "54.jpg", null, null },
                    { "53", "53.jpg", "53", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3641), "", true, "Perth Pasties", "", "53.jpg", null, null },
                    { "52", "52.jpg", "52", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3638), "", true, "Filo Mix", "", "52.jpg", null, null },
                    { "51", "51.jpg", "51", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3635), "", true, "Manjimup Dried Apples", "", "51.jpg", null, null },
                    { "50", "50.jpg", "50", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3632), "", true, "Valkoinen suklaa", "", "50.jpg", null, null },
                    { "46", "46.jpg", "46", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3619), "", true, "Spegesild", "", "46.jpg", null, null },
                    { "48", "48.jpg", "48", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3626), "", true, "Chocolade", "", "48.jpg", null, null },
                    { "47", "47.jpg", "47", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3623), "", true, "Zaanse koeken", "", "47.jpg", null, null },
                    { "58", "58.jpg", "58", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3655), "", true, "Escargots de Bourgogne", "", "58.jpg", null, null },
                    { "45", "45.jpg", "45", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3583), "", true, "Rogede sild", "", "45.jpg", null, null },
                    { "44", "44.jpg", "44", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3580), "", true, "Gula Malacca", "", "44.jpg", null, null },
                    { "43", "43.jpg", "43", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3577), "", true, "Ipoh Coffee", "", "43.jpg", null, null },
                    { "42", "42.jpg", "42", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3574), "", true, "Singaporean Hokkien Fried Mee", "", "42.jpg", null, null },
                    { "49", "49.jpg", "49", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3629), "", true, "Maxilaku", "", "49.jpg", null, null },
                    { "59", "59.jpg", "59", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3658), "", true, "Raclette Courdavault", "", "59.jpg", null, null },
                    { "63", "63.jpg", "63", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3702), "", true, "Vegie-spread", "", "63.jpg", null, null },
                    { "61", "61.jpg", "61", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3663), "", true, "Sirop d'érable", "", "61.jpg", null, null },
                    { "77", "77.jpg", "77", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3862), "", true, "Original Frankfurter grüne Soße", "", "77.jpg", null, null },
                    { "76", "76.jpg", "76", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3858), "", true, "Lakkalikööri", "", "76.jpg", null, null },
                    { "75", "75.jpg", "75", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3739), "", true, "Rhönbräu Klosterbier", "", "75.jpg", null, null },
                    { "74", "74.jpg", "74", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3737), "", true, "Longlife Tofu", "", "74.jpg", null, null },
                    { "73", "73.jpg", "73", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3734), "", true, "Röd Kaviar", "", "73.jpg", null, null },
                    { "72", "72.jpg", "72", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3731), "", true, "Mozzarella di Giovanni", "", "72.jpg", null, null },
                    { "71", "71.jpg", "71", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3728), "", true, "Flotemysost", "", "71.jpg", null, null },
                    { "60", "60.jpg", "60", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3661), "", true, "Camembert Pierrot", "", "60.jpg", null, null },
                    { "70", "70.jpg", "70", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3724), "", true, "Outback Lager", "", "70.jpg", null, null },
                    { "68", "68.jpg", "68", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3719), "", true, "Scottish Longbreads", "", "68.jpg", null, null },
                    { "67", "67.jpg", "67", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3716), "", true, "Laughing Lumberjack Lager", "", "67.jpg", null, null },
                    { "66", "66.jpg", "66", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3713), "", true, "Louisiana Hot Spiced Okra", "", "66.jpg", null, null },
                    { "65", "65.jpg", "65", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3708), "", true, "Louisiana Fiery Hot Pepper Sauce", "", "65.jpg", null, null },
                    { "64", "64.jpg", "64", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3705), "", true, "Wimmers gute Semmelknödel", "", "64.jpg", null, null },
                    { "41", "41.jpg", "41", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3571), "", true, "Jack's New England Clam Chowder", "", "41.jpg", null, null },
                    { "62", "62.jpg", "62", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3666), "", true, "Tarte au sucre", "", "62.jpg", null, null },
                    { "69", "69.jpg", "69", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3722), "", true, "Gudbrandsdalsost", "", "69.jpg", null, null },
                    { "40", "40.jpg", "40", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3568), "", true, "Boston Crab Meat", "", "40.jpg", null, null },
                    { "36", "36.jpg", "36", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3556), "", true, "Inlagd Sill", "", "36.jpg", null, null },
                    { "38", "38.jpg", "38", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3563), "", true, "Côte de Blaye", "", "38.jpg", null, null },
                    { "16", "16.jpg", "16", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3456), "", true, "Pavlova", "", "16.jpg", null, null },
                    { "15", "15.jpg", "15", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3453), "", true, "Genen Shouyu", "", "15.jpg", null, null },
                    { "14", "14.jpg", "14", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3398), "", true, "Tofu", "", "14.jpg", null, null },
                    { "13", "13.jpg", "13", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3395), "", true, "Konbu", "", "13.jpg", null, null },
                    { "12", "12.jpg", "12", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3392), "", true, "Queso Manchego La Pastora", "", "12.jpg", null, null },
                    { "11", "11.jpg", "11", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3389), "", true, "Queso Cabrales", "", "11.jpg", null, null },
                    { "10", "10.jpg", "10", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3386), "", true, "Ikura", "", "10.jpg", null, null },
                    { "17", "17.jpg", "17", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3460), "", true, "Alice Mutton", "", "17.jpg", null, null },
                    { "9", "9.jpg", "9", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3381), "", true, "Mishi Kobe Niku", "", "9.jpg", null, null },
                    { "7", "7.jpg", "7", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3375), "", true, "Uncle Bob's Organic Dried Pears", "", "7.jpg", null, null },
                    { "6", "6.jpg", "6", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3372), "", true, "Grandma's Boysenberry Spread", "", "6.jpg", null, null },
                    { "5", "5.jpg", "5", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3365), "", true, "Chef Anton's Gumbo Mix", "", "5.jpg", null, null },
                    { "4", "4.jpg", "4", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3362), "", true, "Chef Anton's Cajun Seasoning", "", "4.jpg", null, null },
                    { "3", "3.jpg", "3", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3358), "", true, "Aniseed Syrup", "", "3.jpg", null, null },
                    { "2", "2.jpg", "2", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3324), "", true, "Chang", "", "2.jpg", null, null },
                    { "1", "1.jpg", "1", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 662, DateTimeKind.Local).AddTicks(9220), "", true, "Chai", "", "1.jpg", null, null },
                    { "8", "8.jpg", "8", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3378), "", true, "Northwoods Cranberry Sauce", "", "8.jpg", null, null },
                    { "39", "39.jpg", "39", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3565), "", true, "Chartreuse verte", "", "39.jpg", null, null },
                    { "18", "18.jpg", "18", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3465), "", true, "Carnarvon Tigers", "", "18.jpg", null, null },
                    { "20", "20.jpg", "20", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3472), "", true, "Sir Rodney's Marmalade", "", "20.jpg", null, null },
                    { "37", "37.jpg", "37", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3559), "", true, "Gravad lax", "", "37.jpg", null, null },
                    { "35", "35.jpg", "35", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3553), "", true, "Steeleye Stout", "", "35.jpg", null, null },
                    { "34", "34.jpg", "34", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3549), "", true, "Sasquatch Ale", "", "34.jpg", null, null },
                    { "33", "33.jpg", "33", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3544), "", true, "Geitost", "", "33.jpg", null, null },
                    { "32", "32.jpg", "32", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3541), "", true, "Mascarpone Fabioli", "", "32.jpg", null, null },
                    { "31", "31.jpg", "31", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3538), "", true, "Gorgonzola Telino", "", "31.jpg", null, null },
                    { "19", "19.jpg", "19", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3469), "", true, "Teatime Chocolate Biscuits", "", "19.jpg", null, null },
                    { "29", "29.jpg", "29", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3499), "", true, "Thüringer Rostbratwurst", "", "29.jpg", null, null },
                    { "30", "30.jpg", "30", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3502), "", true, "Nord-Ost Matjeshering", "", "30.jpg", null, null },
                    { "27", "27.jpg", "27", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3493), "", true, "Schoggi Schokolade", "", "27.jpg", null, null },
                    { "26", "26.jpg", "26", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3490), "", true, "Gumbär Gummibärchen", "", "26.jpg", null, null },
                    { "25", "25.jpg", "25", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3487), "", true, "NuNuCa Nuß-Nougat-Creme", "", "25.jpg", null, null },
                    { "24", "24.jpg", "24", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3484), "", true, "Guaraná Fantástica", "", "24.jpg", null, null },
                    { "23", "23.jpg", "23", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3481), "", true, "Tunnbröd", "", "23.jpg", null, null },
                    { "22", "22.jpg", "22", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3478), "", true, "Gustaf's Knäckebröd", "", "22.jpg", null, null },
                    { "21", "21.jpg", "21", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3475), "", true, "Sir Rodney's Scones", "", "21.jpg", null, null },
                    { "28", "28.jpg", "28", 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 663, DateTimeKind.Local).AddTicks(3496), "", true, "Rössle Sauerkraut", "", "28.jpg", null, null }
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
                values: new object[] { 1L, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 613, DateTimeKind.Local).AddTicks(3258), "meetgirish.mjn@gmail.com", true, "Girish", "Girish Mahajan", "M", "", true, false, " Mahajan", "8871384762", true, "Admin", "0E37EZvfM10P1jAH1JRpV+OVlsT39xs451MD2WqKcsU=", "", null, null });

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
                values: new object[] { 1, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 615, DateTimeKind.Local).AddTicks(1672), true, 1, 1L, new DateTime(2019, 9, 2, 22, 31, 57, 615, DateTimeKind.Local).AddTicks(136), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_LogInSessions_UserMasterId",
                table: "LogInSessions",
                column: "UserMasterId");

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
