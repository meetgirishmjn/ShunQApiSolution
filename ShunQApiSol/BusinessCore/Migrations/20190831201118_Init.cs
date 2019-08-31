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
                    ProductId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    ProductMasterId = table.Column<string>(nullable: true)
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
                    UpdatedBy = table.Column<long>(nullable: true),
                    ProductMasterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductMasters_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductMasters",
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
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UserMasterId = table.Column<long>(nullable: true),
                    RoleMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_RoleMasters_RoleMasterId",
                        column: x => x.RoleMasterId,
                        principalTable: "RoleMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserMasters_UserMasterId",
                        column: x => x.UserMasterId,
                        principalTable: "UserMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "RoleMasters",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[] { 1, 1, "", "Administrator" });

            migrationBuilder.InsertData(
                table: "RoleMasters",
                columns: new[] { "Id", "CompanyId", "Description", "Name" },
                values: new object[] { 5, 1, "", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_LogInSessions_UserMasterId",
                table: "LogInSessions",
                column: "UserMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBarcodes_ProductMasterId",
                table: "ProductBarcodes",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductMasterId",
                table: "ProductCategories",
                column: "ProductMasterId");

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
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "StoreCategoryXrefs");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ProductMasters");

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
