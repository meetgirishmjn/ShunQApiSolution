using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessCore.Migrations
{
    public partial class updateDb_appV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDeviceLogs_CartDeviceMasters_CartDeviceId",
                table: "CartDeviceLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDeviceLogs_ShoppingCarts_ShoppingCartId",
                table: "CartDeviceLogs");

            migrationBuilder.DropIndex(
                name: "IX_CartDeviceLogs_CartDeviceId",
                table: "CartDeviceLogs");

            migrationBuilder.DropIndex(
                name: "IX_CartDeviceLogs_ShoppingCartId",
                table: "CartDeviceLogs");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "09300996-9d7f-41aa-93e1-bd6d2ea5aaf6");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "09f5ea33-6b22-4c1f-949d-1a1e55123503");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "11e535aa-e333-4d59-92ce-8640453d5786");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "14457715-86de-492b-9a17-aa01cf09da2c");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "1547d645-6caa-4fd5-a085-65df12fcca51");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "3d5aad26-5afe-4e72-8b58-08f2fab723ff");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "53ba3875-0c3e-4f1a-b7fb-d8c6533b1805");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "55354e85-719f-4574-9d12-d75e0c1dff6e");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "5c0f6030-b560-4c86-8684-7371e08cb93e");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "600efbf2-1814-4841-be5f-b5d1f70247d9");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "63452d64-82bd-49b8-b789-8be399946a90");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "696880db-8afb-44e7-80a8-34b17b3481b5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "6af86a4b-5ea4-4be5-bcd4-09bb86121476");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "6c4ccb8e-81c0-4816-8afc-800ad4ca6585");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "72371421-c046-459f-9c40-65ca26c623e6");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "72f54ae5-d3ce-4863-869a-11c1333a9c3f");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "740fe28c-c3b5-447a-941d-fe097aeaa64d");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "7c55f074-0f83-4f48-b454-3e48689c2594");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "84eaf3b6-ca0f-47a1-b81d-663e51fbbcc6");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "895af08d-c625-408f-a0eb-02f306539c19");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "8d6e31a0-4855-4b47-b122-41f776cd49e0");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "94b1132a-dfd9-412b-9756-7235be2b6e7c");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "a1f7d267-e141-4b30-98ca-5aedc3245b76");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "a37f9246-3301-4ea5-90ac-cdc1e974cc03");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "a97bfc68-db96-4bf4-b5d4-e2025ddf0abe");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ae291c34-03d7-402e-a052-0201178b8577");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "b5f66a6e-82f8-41f0-941d-3ddbf6c5677a");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "b78e5bef-c48d-40d3-9cfc-d7592a95eec3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "bd5dd857-0ea7-4812-90ea-05e96b68ba8a");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "c6a8ca4f-02c2-4e52-9e69-0b6e8a84215e");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "c9927618-59d2-48c9-8207-a0c4c499758d");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "cc43a6d4-4b54-437d-88ac-578a905d5444");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ccd0c309-c6ee-4af7-b1de-3fad1a570ba3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "cf150e7f-3484-411e-8c50-ce21e08155ca");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "d9f828f5-76da-4c50-89fd-ab5fbcfcc480");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "e517d36d-7ed7-4fd1-aa3a-24c29622686a");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "e7b134af-9965-4141-b17e-fb619d428f5e");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "eb270990-95da-4bef-bc4c-7c8685ec51d1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "f6e26f95-ce3c-4717-9c74-47b9135d08b4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ff6c32df-c143-48da-8fc2-b5b70a0bafd6");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "1ae38a43-8b0b-4100-b277-00aa73ff5df9");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "6eef281e-6366-43f5-93c2-cab367b41794");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "8245c3c3-c0c9-49c5-8792-4237c97a3e7d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "00b4312a-6d76-4166-b9cf-73fb5942f6c2");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "034211cd-cc45-4460-9700-b192d7bdef70");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "03f17ec4-5a1b-4d81-b4d4-9ccecc08be5e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "09e91484-722a-4dd7-b22c-280500ffec3c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0bb5c8b0-b573-4c6c-b657-c610fdd97d29");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0c365a35-c382-4fa6-ae7c-ee9d1ef3c26a");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0e010066-dc99-461a-8903-ade50fd02492");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0e03a58b-74c0-418c-861c-b9f2eadb8331");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "114cb56b-8c1e-4b67-8537-4f20ebe7de33");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "12dc7c2a-1ead-4b34-97b8-4816573f04af");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "136fb7da-8b6a-4931-bc92-82e97ad7f515");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "1494b01f-83dc-46c4-a3b6-19ffb8edb983");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "17797e12-bb1e-48e9-8471-3e4bcf00972a");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "1ea46104-e7d1-426b-bcf9-15dd8bf3fd48");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "1ef8c297-78fd-4e04-a2c1-32eabe67fa4d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "231bb117-a072-42bd-8f89-3c8614fa87bd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "25bed50a-4b20-4fa2-8feb-a36e1d82b789");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "286a52d0-519a-44c2-981f-27d70ee6fddd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "2c57cb5e-a89e-492d-8045-b33ec16ae627");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "35ed0145-c8af-478d-9056-d67c05976d10");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "37a4ce2f-d1cd-4b5e-8f21-c4de882f0a26");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3c02d1a8-7fe9-4dcd-b4ca-fd5abfdefb0d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "4481baa9-87c2-40c9-a522-34b994c7d32e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "4494ec47-934f-4681-9702-88fd92e9ebf0");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "46e4cb60-9168-4abe-bcac-c823ac8c1667");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "486ffde3-62c0-499e-a0dc-1b337c3c0df5");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "4b7f78df-fa53-4814-864f-45e0921853b3");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "5a51afd6-af73-4c73-b36c-16347365369d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "5b25fd5a-8de8-4fdd-afd9-d3df90e43e17");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "65e1e0ab-d0d1-4a2c-b7ac-5da2317106e6");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "6cf80745-8321-48a6-b143-fdbd62436992");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "704613a2-c015-4cfb-b8cf-baca7a29d67d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "717788d3-68a1-4f53-a9b2-c2094dfbe76b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "729b4640-3048-4626-99c6-381ca50f572c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "76cb4fad-e253-490b-ad6a-99b81f2b99fb");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "7760982d-2713-4693-a3c3-51597ba2faad");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "7b691ae8-d57c-47ef-9a73-6cf30ad82515");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "7f6dc488-a1ab-492d-b5b9-b6b4166f5204");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "82f36a14-f5a6-423b-b041-a035fad2c311");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "8910a113-a93d-40c0-b342-ad47f0c031ec");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "8f29de75-9df4-4871-9889-03a584d41693");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "964da465-a70e-4bea-a3e2-85a3a8f23d54");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9747e63f-8e0f-452b-a77b-c90b4a426cbd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9a066d18-0f88-4a3b-b965-571e298edd64");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9a55c36c-0750-4927-a9f7-4b1ab240d606");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9b39c996-1553-431d-a4f1-0b4d4f8894b2");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9bb13ceb-5342-4b10-ba13-b8bdd627946f");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9c6c9c03-62fb-4b6f-a562-4c14e062c4c8");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "a298e7d1-6a82-43c6-a037-2d2badcb27bc");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "a804ff34-6fbb-409d-a866-67e20e69cbfd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ab88b614-14ff-44b5-a227-c58e82a721d8");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ac9b6125-af47-41aa-80df-323e5110e706");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "acb17562-56fb-4ce7-a334-6e02b91507f3");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "b6aa17a4-ae25-4b49-96b8-7ba18324a9c7");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "b70ffc20-0a6a-4ac2-b050-b4cd5c370679");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "bdd81086-da73-49b0-9d98-1ecf6682f5bb");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c02e7f07-73e1-411b-a70c-520fa7fc556d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c0a69fb9-cd01-4cf7-9a89-2dcef8947617");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c14e2623-958b-4580-8061-61cfae0cb47e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c35254d0-62e7-496f-bcac-17bbd618cf3f");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c409ea9b-6e04-4ff4-a1d9-7f734dc55a6a");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ce5641a6-4a89-4dd9-8a0e-cdd97b9a162c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "d6e9bae8-c13f-4323-affd-b5b200cd2a06");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "d9c4e900-5f93-4350-bf44-bc124d46a745");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "df653e80-76f5-4643-b5c0-8c37c6ce8509");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "e6689a82-449d-40da-bc60-1dc492052041");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "e73f67fe-58fe-45ba-81ce-0a6a9f64564e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "eaf21124-1da9-4431-9954-10b81f3f733b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ee831988-1c2c-4037-9cda-2057c4f281ed");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f146d99f-f966-4d61-a159-bd5d4a7adb93");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f186f26c-862d-4b88-900f-87f88cc513a3");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f18a554d-0532-4680-a106-2535d1a7b9f7");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f247ec05-8d57-45ba-b8f5-5f20dee36dad");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f4e61dd5-b8c4-4470-b1f6-a00091bab433");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "fa5fc6a2-a92d-434a-8882-a57878c5a6f1");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "fae25622-9971-4692-8bc1-ce6062fdf7c6");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "fcdbd0f2-be16-4183-84d1-0594ba007e35");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "CartDeviceLogs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CartDeviceId",
                table: "CartDeviceLogs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentVoucherMasters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentGatewayName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: false),
                    CartId = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    GatewayResponse = table.Column<string>(nullable: true),
                    GatewayPaymentId = table.Column<string>(nullable: true),
                    HashValidation = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentVoucherMasters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CartDeviceMasters",
                columns: new[] { "CartDeviceId", "IsActive", "StatusRemark", "StoreMasterId" },
                values: new object[,]
                {
                    { "ST1001SC1", true, null, 1001 },
                    { "ST1005SC3", true, null, 1005 },
                    { "ST1005SC4", true, null, 1005 },
                    { "ST1005SC5", true, null, 1005 },
                    { "ST1006SC1", true, null, 1006 },
                    { "ST1006SC2", true, null, 1006 },
                    { "ST1006SC3", true, null, 1006 },
                    { "ST1006SC4", true, null, 1006 },
                    { "ST1006SC5", true, null, 1006 },
                    { "ST1007SC1", true, null, 1007 },
                    { "ST1007SC2", true, null, 1007 },
                    { "ST1007SC3", true, null, 1007 },
                    { "ST1007SC4", true, null, 1007 },
                    { "ST1007SC5", true, null, 1007 },
                    { "ST1008SC1", true, null, 1008 },
                    { "ST1008SC2", true, null, 1008 },
                    { "ST1008SC3", true, null, 1008 },
                    { "ST1008SC4", true, null, 1008 },
                    { "ST1005SC2", true, null, 1005 },
                    { "ST1008SC5", true, null, 1008 },
                    { "ST1005SC1", true, null, 1005 },
                    { "ST1004SC4", true, null, 1004 },
                    { "ST1001SC2", true, null, 1001 },
                    { "ST1001SC3", true, null, 1001 },
                    { "ST1001SC4", true, null, 1001 },
                    { "ST1001SC5", true, null, 1001 },
                    { "ST1002SC1", true, null, 1002 },
                    { "ST1002SC2", true, null, 1002 },
                    { "ST1002SC3", true, null, 1002 },
                    { "ST1002SC4", true, null, 1002 },
                    { "ST1002SC5", true, null, 1002 },
                    { "ST1003SC1", true, null, 1003 },
                    { "ST1003SC2", true, null, 1003 },
                    { "ST1003SC3", true, null, 1003 },
                    { "ST1003SC4", true, null, 1003 },
                    { "ST1003SC5", true, null, 1003 },
                    { "ST1004SC1", true, null, 1004 },
                    { "ST1004SC2", true, null, 1004 },
                    { "ST1004SC3", true, null, 1004 },
                    { "ST1004SC5", true, null, 1004 }
                });

            migrationBuilder.InsertData(
                table: "DiscountVoucherMasters",
                columns: new[] { "Id", "Code", "Description", "Expression", "Title" },
                values: new object[,]
                {
                    { "12479800-f3d6-45e6-aa1c-bf356104ca2d", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "c29af6b8-c5af-44bb-ab35-749f80cd6bdf", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" },
                    { "97e3d5bd-6367-47d5-9c9b-0c9fe92c4bb1", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" }
                });

            migrationBuilder.InsertData(
                table: "PaymentVoucherMasters",
                columns: new[] { "Id", "CartId", "CreatedOn", "GatewayPaymentId", "GatewayResponse", "HashValidation", "IsSuccess", "PaymentGatewayName", "Status", "UserName" },
                values: new object[] { 1023L, "SEED", new DateTime(2019, 11, 5, 14, 6, 6, 639, DateTimeKind.Local).AddTicks(1923), "SEED", "SEED", false, false, "SEED", "SEED", "SEED" });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn", "Weight", "WeightUnit" },
                values: new object[,]
                {
                    { "63f6fa8d-2c17-4cf7-b375-0288820a1283", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9779), 14f, "8% Discount", true, 89.5f, 75.5f, "56", null, null, 100f, "gm" },
                    { "0b0dd957-2223-4e1a-9892-35b556882dae", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9762), 351f, "4% Discount", true, 377.9f, 26.9f, "55", null, null, 100f, "gm" },
                    { "03c7e5d9-9baf-4c9d-8cc9-f693fdf0e2dd", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9709), 455f, "9% Discount", true, 670.8f, 215.8f, "54", null, null, 100f, "gm" },
                    { "3207f5f5-5337-4682-89cf-745dca79cf84", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9697), 371f, "3% Discount", true, 752.7f, 381.7f, "53", null, null, 100f, "gm" },
                    { "896df059-96ec-47a1-aced-84dd5d80fe74", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9683), 713f, "9% Discount", true, 799.95f, 86.95f, "52", null, null, 100f, "gm" },
                    { "a242a876-02fe-42c6-a1ac-159f31590be9", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9671), 340f, "4% Discount", true, 944.7f, 604.7f, "51", null, null, 100f, "gm" },
                    { "b427ecf4-acc3-430a-a7f3-8435bbd30927", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9657), 256f, "9% Discount", true, 270.7f, 14.7f, "50", null, null, 100f, "gm" },
                    { "98bbc292-a5c3-4afe-b220-de6e8162c857", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9644), 240f, "4% Discount", true, 464.2f, 224.2f, "49", null, null, 100f, "gm" },
                    { "07a2e81c-96bc-4118-ab9a-98b897dd1a08", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9631), 726f, "5% Discount", true, 748.45f, 22.45f, "48", null, null, 100f, "gm" },
                    { "2074de89-3430-4e5c-9f87-b546d634ff93", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9615), 69f, "6% Discount", true, 219.65f, 150.65f, "47", null, null, 100f, "gm" },
                    { "bb400d39-c528-4aa2-ac0d-1927706ada1e", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9602), 498f, "5% Discount", true, 667.8f, 169.8f, "46", null, null, 100f, "gm" },
                    { "ea02de5d-590b-4292-a305-fcd563075000", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9589), 578f, "3% Discount", true, 675.35f, 97.35f, "45", null, null, 100f, "gm" },
                    { "ff9fbcc9-480f-4afa-87d9-592c38987d15", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9575), 2f, "8% Discount", true, 12.4f, 10.4f, "44", null, null, 100f, "gm" },
                    { "3ef4a231-5c62-4b24-9e71-4c0e9f2ce918", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9561), 149f, "6% Discount", true, 851.55f, 702.55f, "43", null, null, 100f, "gm" },
                    { "171728f8-eed4-4baf-bf49-101f874e2d05", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9548), 270f, "3% Discount", true, 720.5f, 450.5f, "42", null, null, 100f, "gm" },
                    { "46b5e118-c92d-4bb2-bc99-02caf2012680", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9495), 36f, "7% Discount", true, 184.5f, 148.5f, "41", null, null, 100f, "gm" },
                    { "bf941866-2d8a-40fc-8c88-984636e08325", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9792), 229f, "10% Discount", true, 392.8f, 163.8f, "57", null, null, 100f, "gm" },
                    { "50180d4f-54e4-4c88-8f82-6fe1a94e9df5", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9481), 83f, "2% Discount", true, 925.85f, 842.85f, "40", null, null, 100f, "gm" },
                    { "afb0d58d-960e-4379-8afb-4be4eee477e7", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9819), 123f, "9% Discount", true, 266.65f, 143.65f, "59", null, null, 100f, "gm" },
                    { "08180684-3c36-4862-b9c7-34b2dbe65c2e", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9833), 463f, "9% Discount", true, 887.5f, 424.5f, "60", null, null, 100f, "gm" },
                    { "91d0c887-a7ba-4136-b88a-024af210365c", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(106), 222f, "1% Discount", true, 419.8f, 197.8f, "77", null, null, 100f, "gm" },
                    { "0707e471-261f-4b40-abbe-cd1d230f3c92", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(93), 66f, "8% Discount", true, 117.25f, 51.25f, "76", null, null, 100f, "gm" },
                    { "c74ccc56-d54e-4004-8158-31f033127272", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(80), 3f, "8% Discount", true, 124.45f, 121.45f, "75", null, null, 100f, "gm" },
                    { "723ed20f-75c3-4f27-bb02-9b4546bcb1b3", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(68), 498f, "10% Discount", true, 907.35f, 409.35f, "74", null, null, 100f, "gm" },
                    { "277d7792-368b-486f-aa83-d7a8cdb9100e", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(54), 190f, "2% Discount", true, 881.45f, 691.45f, "73", null, null, 100f, "gm" },
                    { "3b322463-822d-4685-86d9-643fb7f8fc94", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(42), 110f, "10% Discount", true, 674.55f, 564.55f, "72", null, null, 100f, "gm" },
                    { "f4567667-2b34-45c6-b672-bcd92163501d", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(27), 190f, "10% Discount", true, 872.75f, 682.75f, "71", null, null, 100f, "gm" },
                    { "07e4504d-3d65-41fb-af3c-d82962d3342c", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9805), 4f, "1% Discount", true, 14.55f, 10.55f, "58", null, null, 100f, "gm" },
                    { "4ce3c619-603d-4312-a989-ad7dffd02486", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9997), 161f, "3% Discount", true, 210.9f, 49.9f, "69", null, null, 100f, "gm" },
                    { "137e2d86-88ce-4c2e-a300-71a20fc561cb", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9971), 196f, "6% Discount", true, 452.7f, 256.7f, "67", null, null, 100f, "gm" },
                    { "69f0e25c-a432-4d68-9be5-3c138b182480", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9917), 109f, "8% Discount", true, 177.4f, 68.4f, "66", null, null, 100f, "gm" },
                    { "9f8483b0-913a-4d13-802b-e18cbdd0aeda", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9903), 403f, "6% Discount", true, 853.15f, 450.15f, "65", null, null, 100f, "gm" },
                    { "fb7e20b7-5872-48a3-a8b0-28c42282c18b", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9890), 123f, "7% Discount", true, 705.25f, 582.25f, "64", null, null, 100f, "gm" },
                    { "bcfb6341-0143-42eb-bb85-26144085362c", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9874), 330f, "4% Discount", true, 621.15f, 291.15f, "63", null, null, 100f, "gm" },
                    { "af4f7e18-53b5-4b0d-a8ed-f1a2215a61e5", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9858), 284f, "6% Discount", true, 804.25f, 520.25f, "62", null, null, 100f, "gm" },
                    { "100747c4-e8f9-4b5d-b6fa-f2e3d24fc94b", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9846), 137f, "7% Discount", true, 790.15f, 653.15f, "61", null, null, 100f, "gm" },
                    { "f2e77d9f-7b11-47eb-af2b-a98bccdfa412", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9984), 72f, "1% Discount", true, 423.15f, 351.15f, "68", null, null, 100f, "gm" },
                    { "8c37ec51-2ac5-4208-b081-40198a58c51e", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9466), 56f, "9% Discount", true, 123.85f, 67.85f, "39", null, null, 100f, "gm" },
                    { "3bc1dc68-4635-4b44-b216-b7f81074e8cf", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(10), 63f, "1% Discount", true, 146.25f, 83.25f, "70", null, null, 100f, "gm" },
                    { "0425f839-cf0e-4349-8961-0ce4fd2b0fce", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9440), 263f, "2% Discount", true, 347.6f, 84.6f, "37", null, null, 100f, "gm" },
                    { "706dc3b9-aeee-4392-a32b-1404a50cbd67", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8996), 58f, "4% Discount", true, 311.2f, 253.2f, "16", null, null, 100f, "gm" },
                    { "7e2a09ce-8f4e-49ba-a5f5-8e8a83036c24", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8980), 246f, "8% Discount", true, 979.5f, 733.5f, "15", null, null, 100f, "gm" },
                    { "f48548b3-fe31-41c4-ae65-c034b47f40c5", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8965), 512f, "8% Discount", true, 853.2f, 341.2f, "14", null, null, 100f, "gm" },
                    { "67c8299c-1942-4472-b2de-fb27a4ad9c9d", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8951), 393f, "1% Discount", true, 721.7f, 328.7f, "13", null, null, 100f, "gm" },
                    { "75e9c84c-0fbd-475e-9171-76564163f737", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8937), 12f, "3% Discount", true, 23.6f, 11.6f, "12", null, null, 100f, "gm" },
                    { "a9653d5d-c4e6-4eec-8172-41f72b8062b9", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8925), 223f, "3% Discount", true, 292.4f, 69.4f, "11", null, null, 100f, "gm" },
                    { "d5194712-a55c-40c6-b794-c5b91c3c3330", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8910), 4f, "2% Discount", true, 21.45f, 17.45f, "10", null, null, 100f, "gm" },
                    { "047bab81-5f38-4c5c-8bb0-2539fd607a6d", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9009), 57f, "10% Discount", true, 812.2f, 755.2f, "17", null, null, 100f, "gm" },
                    { "d6ccb42f-5959-4621-9280-b58242e995e1", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8895), 68f, "7% Discount", true, 164.5f, 96.5f, "9", null, null, 100f, "gm" },
                    { "3728046a-437c-4c98-8ea5-5ae731cf3c5b", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9453), 465f, "5% Discount", true, 778.2f, 313.2f, "38", null, null, 100f, "gm" },
                    { "ee35aea6-1369-46d2-8d67-af1aec1dc6c9", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8839), 8f, "4% Discount", true, 643.45f, 635.45f, "6", null, null, 100f, "gm" },
                    { "000e6abe-dcaa-4295-874c-7b79864e2989", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8820), 86f, "6% Discount", true, 134.15f, 48.15f, "5", null, null, 200f, "gm" },
                    { "89a5ea1c-140e-40ac-b911-e0614b23d27b", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8734), 25f, "10% Discount", true, 154.15f, 129.15f, "4", null, null, 300f, "gm" },
                    { "39e290ac-ff68-4ef1-a564-751c7c00f993", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8716), 198f, "5% Discount", true, 401.15f, 203.15f, "3", null, null, 500f, "gm" },
                    { "70fff647-2a16-4f40-82ab-706fe361ac75", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8685), 170f, "4% Discount", true, 433.8f, 263.8f, "2", null, null, 500f, "gm" },
                    { "c183e0fa-44e4-45df-a50d-00176adacaeb", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(7062), 1f, "5% Discount", true, 11.35f, 10.35f, "1", null, null, 200f, "gm" },
                    { "8cd2c682-0390-4f51-9fb2-863b37be6b56", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8881), 603f, "7% Discount", true, 792.55f, 189.55f, "8", null, null, 100f, "gm" },
                    { "30582036-91a7-4809-b2ee-df1ac4c1ef83", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9068), 97f, "1% Discount", true, 208.6f, 111.6f, "18", null, null, 100f, "gm" },
                    { "36bf1d3a-63ff-4995-8356-25519b5b8fa7", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(8855), 63f, "3% Discount", true, 92.65f, 29.65f, "7", null, null, 100f, "gm" },
                    { "793b03f4-3562-4c1f-8f68-8e444d75b953", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9094), 185f, "7% Discount", true, 741.45f, 556.45f, "20", null, null, 100f, "gm" },
                    { "0f63f3c4-9ad0-4fa0-94c2-d99da397f3cf", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9426), 28f, "6% Discount", true, 531.55f, 503.55f, "36", null, null, 100f, "gm" },
                    { "38ad29cf-0042-47c9-8994-695cfe1a298c", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9413), 42f, "10% Discount", true, 115.35f, 73.35f, "35", null, null, 100f, "gm" },
                    { "242e09ba-11a2-47fa-a7b1-ee7517c3e098", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9400), 410f, "10% Discount", true, 953.65f, 543.65f, "34", null, null, 100f, "gm" },
                    { "61083998-c8a8-44f4-aee3-a9f427314849", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9385), 11f, "6% Discount", true, 44.2f, 33.2f, "33", null, null, 100f, "gm" },
                    { "6f99715c-8aa0-4ab8-9c9c-a710ba19b417", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9371), 10f, "5% Discount", true, 68.6f, 58.6f, "32", null, null, 100f, "gm" },
                    { "194f77e3-762b-485b-a603-253180dd5c04", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9354), 206f, "8% Discount", true, 272.3f, 66.3f, "31", null, null, 100f, "gm" },
                    { "7c61de9e-93a7-4166-9697-4e97ff3cf481", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9081), 139f, "2% Discount", true, 170.4f, 31.4f, "19", null, null, 100f, "gm" },
                    { "b99bc31f-7aca-454e-b939-b324fa8109a6", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9220), 24f, "2% Discount", true, 105.25f, 81.25f, "29", null, null, 100f, "gm" },
                    { "2653f0c4-4faa-4b23-b7d3-485abe2f2326", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9341), 8f, "10% Discount", true, 993.7f, 985.7f, "30", null, null, 100f, "gm" },
                    { "06f77b92-8502-48d6-a39b-354bdfb2d9f3", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9192), 130f, "10% Discount", true, 357.2f, 227.2f, "27", null, null, 100f, "gm" },
                    { "e6349c55-92cb-402d-aad6-57d9e957136d", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9179), 36f, "5% Discount", true, 110.1f, 74.1f, "26", null, null, 100f, "gm" },
                    { "70273e61-45d3-4bd8-834a-838952e19419", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9165), 795f, "8% Discount", true, 877.5f, 82.5f, "25", null, null, 100f, "gm" },
                    { "572e2464-e909-40db-bec4-91860fe39f44", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9152), 38f, "1% Discount", true, 959.3f, 921.3f, "24", null, null, 100f, "gm" },
                    { "60f4ea45-5c98-4cb0-b3aa-b00f4b74d070", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9136), 328f, "5% Discount", true, 863.75f, 535.75f, "23", null, null, 100f, "gm" },
                    { "c2f0bbf6-cb1f-4d6a-91d7-105aca3790cd", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9123), 93f, "7% Discount", true, 204.35f, 111.35f, "22", null, null, 100f, "gm" },
                    { "8ebb94c1-84c7-4bb8-9c1f-8e194a882b11", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9108), 3f, "9% Discount", true, 16.5f, 13.5f, "21", null, null, 100f, "gm" },
                    { "9de48f8f-1209-4a71-9a02-704f624f8ed2", 1, 1L, new DateTime(2019, 11, 5, 14, 6, 6, 636, DateTimeKind.Local).AddTicks(9206), 159f, "3% Discount", true, 228.7f, 69.7f, "28", null, null, 100f, "gm" }
                });

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 637, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(5284));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 630, DateTimeKind.Local).AddTicks(6358));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 631, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "10",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "11",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "13",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5595));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "15",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "17",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "19",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "20",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5629));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "21",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "22",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5639));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "23",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "24",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5648));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "25",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5656));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "26",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "29",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5410));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "30",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5749));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "31",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "32",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "33",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "34",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "38",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "39",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "40",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "41",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "42",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "43",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "44",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "45",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "46",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "47",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "48",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "49",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "50",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "51",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "52",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "54",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "55",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "56",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6026));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "57",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6033));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "58",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "59",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "60",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "61",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6068));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "62",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "63",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "64",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "65",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6157));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "66",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "67",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "68",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "69",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "7",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "70",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "71",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "72",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "73",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "74",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "75",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "76",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "77",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(6254));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "8",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "9",
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 633, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 563, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 563, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 563, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 563, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 563, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8104));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 564, DateTimeKind.Local).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "UserMasters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 11, 5, 14, 6, 6, 560, DateTimeKind.Local).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 11, 5, 14, 6, 6, 562, DateTimeKind.Local).AddTicks(9924), new DateTime(2019, 11, 5, 14, 6, 6, 562, DateTimeKind.Local).AddTicks(8308) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentVoucherMasters");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1001SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1001SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1001SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1001SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1001SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1002SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1002SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1002SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1002SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1002SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1003SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1003SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1003SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1003SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1003SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1004SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1004SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1004SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1004SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1004SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1005SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1005SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1005SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1005SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1005SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1006SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1006SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1006SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1006SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1006SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1007SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1007SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1007SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1007SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1007SC5");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1008SC1");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1008SC2");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1008SC3");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1008SC4");

            migrationBuilder.DeleteData(
                table: "CartDeviceMasters",
                keyColumn: "CartDeviceId",
                keyValue: "ST1008SC5");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "12479800-f3d6-45e6-aa1c-bf356104ca2d");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "97e3d5bd-6367-47d5-9c9b-0c9fe92c4bb1");

            migrationBuilder.DeleteData(
                table: "DiscountVoucherMasters",
                keyColumn: "Id",
                keyValue: "c29af6b8-c5af-44bb-ab35-749f80cd6bdf");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "000e6abe-dcaa-4295-874c-7b79864e2989");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "03c7e5d9-9baf-4c9d-8cc9-f693fdf0e2dd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0425f839-cf0e-4349-8961-0ce4fd2b0fce");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "047bab81-5f38-4c5c-8bb0-2539fd607a6d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "06f77b92-8502-48d6-a39b-354bdfb2d9f3");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0707e471-261f-4b40-abbe-cd1d230f3c92");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "07a2e81c-96bc-4118-ab9a-98b897dd1a08");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "07e4504d-3d65-41fb-af3c-d82962d3342c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "08180684-3c36-4862-b9c7-34b2dbe65c2e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0b0dd957-2223-4e1a-9892-35b556882dae");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "0f63f3c4-9ad0-4fa0-94c2-d99da397f3cf");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "100747c4-e8f9-4b5d-b6fa-f2e3d24fc94b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "137e2d86-88ce-4c2e-a300-71a20fc561cb");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "171728f8-eed4-4baf-bf49-101f874e2d05");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "194f77e3-762b-485b-a603-253180dd5c04");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "2074de89-3430-4e5c-9f87-b546d634ff93");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "242e09ba-11a2-47fa-a7b1-ee7517c3e098");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "2653f0c4-4faa-4b23-b7d3-485abe2f2326");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "277d7792-368b-486f-aa83-d7a8cdb9100e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "30582036-91a7-4809-b2ee-df1ac4c1ef83");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3207f5f5-5337-4682-89cf-745dca79cf84");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "36bf1d3a-63ff-4995-8356-25519b5b8fa7");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3728046a-437c-4c98-8ea5-5ae731cf3c5b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "38ad29cf-0042-47c9-8994-695cfe1a298c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "39e290ac-ff68-4ef1-a564-751c7c00f993");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3b322463-822d-4685-86d9-643fb7f8fc94");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3bc1dc68-4635-4b44-b216-b7f81074e8cf");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "3ef4a231-5c62-4b24-9e71-4c0e9f2ce918");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "46b5e118-c92d-4bb2-bc99-02caf2012680");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "4ce3c619-603d-4312-a989-ad7dffd02486");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "50180d4f-54e4-4c88-8f82-6fe1a94e9df5");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "572e2464-e909-40db-bec4-91860fe39f44");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "60f4ea45-5c98-4cb0-b3aa-b00f4b74d070");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "61083998-c8a8-44f4-aee3-a9f427314849");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "63f6fa8d-2c17-4cf7-b375-0288820a1283");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "67c8299c-1942-4472-b2de-fb27a4ad9c9d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "69f0e25c-a432-4d68-9be5-3c138b182480");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "6f99715c-8aa0-4ab8-9c9c-a710ba19b417");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "70273e61-45d3-4bd8-834a-838952e19419");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "706dc3b9-aeee-4392-a32b-1404a50cbd67");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "70fff647-2a16-4f40-82ab-706fe361ac75");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "723ed20f-75c3-4f27-bb02-9b4546bcb1b3");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "75e9c84c-0fbd-475e-9171-76564163f737");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "793b03f4-3562-4c1f-8f68-8e444d75b953");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "7c61de9e-93a7-4166-9697-4e97ff3cf481");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "7e2a09ce-8f4e-49ba-a5f5-8e8a83036c24");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "896df059-96ec-47a1-aced-84dd5d80fe74");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "89a5ea1c-140e-40ac-b911-e0614b23d27b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "8c37ec51-2ac5-4208-b081-40198a58c51e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "8cd2c682-0390-4f51-9fb2-863b37be6b56");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "8ebb94c1-84c7-4bb8-9c1f-8e194a882b11");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "91d0c887-a7ba-4136-b88a-024af210365c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "98bbc292-a5c3-4afe-b220-de6e8162c857");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9de48f8f-1209-4a71-9a02-704f624f8ed2");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "9f8483b0-913a-4d13-802b-e18cbdd0aeda");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "a242a876-02fe-42c6-a1ac-159f31590be9");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "a9653d5d-c4e6-4eec-8172-41f72b8062b9");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "af4f7e18-53b5-4b0d-a8ed-f1a2215a61e5");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "afb0d58d-960e-4379-8afb-4be4eee477e7");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "b427ecf4-acc3-430a-a7f3-8435bbd30927");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "b99bc31f-7aca-454e-b939-b324fa8109a6");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "bb400d39-c528-4aa2-ac0d-1927706ada1e");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "bcfb6341-0143-42eb-bb85-26144085362c");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "bf941866-2d8a-40fc-8c88-984636e08325");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c183e0fa-44e4-45df-a50d-00176adacaeb");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c2f0bbf6-cb1f-4d6a-91d7-105aca3790cd");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "c74ccc56-d54e-4004-8158-31f033127272");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "d5194712-a55c-40c6-b794-c5b91c3c3330");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "d6ccb42f-5959-4621-9280-b58242e995e1");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "e6349c55-92cb-402d-aad6-57d9e957136d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ea02de5d-590b-4292-a305-fcd563075000");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ee35aea6-1369-46d2-8d67-af1aec1dc6c9");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f2e77d9f-7b11-47eb-af2b-a98bccdfa412");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f4567667-2b34-45c6-b672-bcd92163501d");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "f48548b3-fe31-41c4-ae65-c034b47f40c5");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "fb7e20b7-5872-48a3-a8b0-28c42282c18b");

            migrationBuilder.DeleteData(
                table: "PriceMasters",
                keyColumn: "Id",
                keyValue: "ff9fbcc9-480f-4afa-87d9-592c38987d15");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "CartDeviceLogs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CartDeviceId",
                table: "CartDeviceLogs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CartDeviceMasters",
                columns: new[] { "CartDeviceId", "IsActive", "StatusRemark", "StoreMasterId" },
                values: new object[,]
                {
                    { "72371421-c046-459f-9c40-65ca26c623e6", true, null, 1001 },
                    { "b78e5bef-c48d-40d3-9cfc-d7592a95eec3", true, null, 1005 },
                    { "8d6e31a0-4855-4b47-b122-41f776cd49e0", true, null, 1005 },
                    { "a97bfc68-db96-4bf4-b5d4-e2025ddf0abe", true, null, 1005 },
                    { "6af86a4b-5ea4-4be5-bcd4-09bb86121476", true, null, 1006 },
                    { "84eaf3b6-ca0f-47a1-b81d-663e51fbbcc6", true, null, 1006 },
                    { "ff6c32df-c143-48da-8fc2-b5b70a0bafd6", true, null, 1006 },
                    { "09300996-9d7f-41aa-93e1-bd6d2ea5aaf6", true, null, 1006 },
                    { "14457715-86de-492b-9a17-aa01cf09da2c", true, null, 1006 },
                    { "eb270990-95da-4bef-bc4c-7c8685ec51d1", true, null, 1007 },
                    { "6c4ccb8e-81c0-4816-8afc-800ad4ca6585", true, null, 1007 },
                    { "f6e26f95-ce3c-4717-9c74-47b9135d08b4", true, null, 1007 },
                    { "ccd0c309-c6ee-4af7-b1de-3fad1a570ba3", true, null, 1007 },
                    { "d9f828f5-76da-4c50-89fd-ab5fbcfcc480", true, null, 1007 },
                    { "c9927618-59d2-48c9-8207-a0c4c499758d", true, null, 1008 },
                    { "1547d645-6caa-4fd5-a085-65df12fcca51", true, null, 1008 },
                    { "3d5aad26-5afe-4e72-8b58-08f2fab723ff", true, null, 1008 },
                    { "ae291c34-03d7-402e-a052-0201178b8577", true, null, 1008 },
                    { "53ba3875-0c3e-4f1a-b7fb-d8c6533b1805", true, null, 1005 },
                    { "11e535aa-e333-4d59-92ce-8640453d5786", true, null, 1008 },
                    { "a1f7d267-e141-4b30-98ca-5aedc3245b76", true, null, 1005 },
                    { "740fe28c-c3b5-447a-941d-fe097aeaa64d", true, null, 1004 },
                    { "c6a8ca4f-02c2-4e52-9e69-0b6e8a84215e", true, null, 1001 },
                    { "cc43a6d4-4b54-437d-88ac-578a905d5444", true, null, 1001 },
                    { "895af08d-c625-408f-a0eb-02f306539c19", true, null, 1001 },
                    { "94b1132a-dfd9-412b-9756-7235be2b6e7c", true, null, 1001 },
                    { "7c55f074-0f83-4f48-b454-3e48689c2594", true, null, 1002 },
                    { "e517d36d-7ed7-4fd1-aa3a-24c29622686a", true, null, 1002 },
                    { "a37f9246-3301-4ea5-90ac-cdc1e974cc03", true, null, 1002 },
                    { "696880db-8afb-44e7-80a8-34b17b3481b5", true, null, 1002 },
                    { "600efbf2-1814-4841-be5f-b5d1f70247d9", true, null, 1002 },
                    { "09f5ea33-6b22-4c1f-949d-1a1e55123503", true, null, 1003 },
                    { "72f54ae5-d3ce-4863-869a-11c1333a9c3f", true, null, 1003 },
                    { "63452d64-82bd-49b8-b789-8be399946a90", true, null, 1003 },
                    { "bd5dd857-0ea7-4812-90ea-05e96b68ba8a", true, null, 1003 },
                    { "b5f66a6e-82f8-41f0-941d-3ddbf6c5677a", true, null, 1003 },
                    { "e7b134af-9965-4141-b17e-fb619d428f5e", true, null, 1004 },
                    { "5c0f6030-b560-4c86-8684-7371e08cb93e", true, null, 1004 },
                    { "cf150e7f-3484-411e-8c50-ce21e08155ca", true, null, 1004 },
                    { "55354e85-719f-4574-9d12-d75e0c1dff6e", true, null, 1004 }
                });

            migrationBuilder.InsertData(
                table: "DiscountVoucherMasters",
                columns: new[] { "Id", "Code", "Description", "Expression", "Title" },
                values: new object[,]
                {
                    { "6eef281e-6366-43f5-93c2-cab367b41794", "ICICIGTSEP", "ICICI Tuesday Offer - Flat 10% OFF on Order of Rs 1500", null, "10% off" },
                    { "1ae38a43-8b0b-4100-b277-00aa73ff5df9", "BBVISA200", "Visa Card Offer (New Users) - Extra Rs 200 OFF on Rs 800", null, "Rs.200 off" },
                    { "8245c3c3-c0c9-49c5-8792-4237c97a3e7d", "DIP20", "Festival fever – On Order Of Rs.800 & Above", null, " Flat 20% Off" }
                });

            migrationBuilder.InsertData(
                table: "PriceMasters",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedOn", "Discount", "DiscountText", "IsActive", "MRP", "Price", "ProductId", "UpdatedBy", "UpdatedOn", "Weight", "WeightUnit" },
                values: new object[,]
                {
                    { "0e010066-dc99-461a-8903-ade50fd02492", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6207), 20f, "8% Discount", true, 35.65f, 15.65f, "56", null, null, 100f, "gm" },
                    { "9c6c9c03-62fb-4b6f-a562-4c14e062c4c8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6175), 41f, "2% Discount", true, 481.25f, 440.25f, "55", null, null, 100f, "gm" },
                    { "0bb5c8b0-b573-4c6c-b657-c610fdd97d29", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6145), 35f, "9% Discount", true, 259.95f, 224.95f, "54", null, null, 100f, "gm" },
                    { "964da465-a70e-4bea-a3e2-85a3a8f23d54", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6114), 61f, "7% Discount", true, 248.2f, 187.2f, "53", null, null, 100f, "gm" },
                    { "c02e7f07-73e1-411b-a70c-520fa7fc556d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6084), 402f, "7% Discount", true, 866.3f, 464.3f, "52", null, null, 100f, "gm" },
                    { "00b4312a-6d76-4166-b9cf-73fb5942f6c2", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6052), 147f, "4% Discount", true, 173.2f, 26.2f, "51", null, null, 100f, "gm" },
                    { "8f29de75-9df4-4871-9889-03a584d41693", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6020), 255f, "2% Discount", true, 950.15f, 695.15f, "50", null, null, 100f, "gm" },
                    { "9747e63f-8e0f-452b-a77b-c90b4a426cbd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6241), 646f, "10% Discount", true, 971.85f, 325.85f, "57", null, null, 100f, "gm" },
                    { "704613a2-c015-4cfb-b8cf-baca7a29d67d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5990), 145f, "2% Discount", true, 238.15f, 93.15f, "49", null, null, 100f, "gm" },
                    { "4b7f78df-fa53-4814-864f-45e0921853b3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5920), 307f, "5% Discount", true, 328.2f, 21.2f, "47", null, null, 100f, "gm" },
                    { "7f6dc488-a1ab-492d-b5b9-b6b4166f5204", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5888), 1f, "8% Discount", true, 734.65f, 733.65f, "46", null, null, 100f, "gm" },
                    { "a804ff34-6fbb-409d-a866-67e20e69cbfd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5855), 50f, "7% Discount", true, 81.85f, 31.85f, "45", null, null, 100f, "gm" },
                    { "82f36a14-f5a6-423b-b041-a035fad2c311", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5751), 78f, "1% Discount", true, 370.2f, 292.2f, "44", null, null, 100f, "gm" },
                    { "35ed0145-c8af-478d-9056-d67c05976d10", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5719), 4f, "5% Discount", true, 551.25f, 547.25f, "43", null, null, 100f, "gm" },
                    { "4494ec47-934f-4681-9702-88fd92e9ebf0", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5687), 319f, "2% Discount", true, 680.5f, 361.5f, "42", null, null, 100f, "gm" },
                    { "286a52d0-519a-44c2-981f-27d70ee6fddd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5657), 172f, "2% Discount", true, 246.6f, 74.6f, "41", null, null, 100f, "gm" },
                    { "3c02d1a8-7fe9-4dcd-b4ca-fd5abfdefb0d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5951), 159f, "1% Discount", true, 511.9f, 352.9f, "48", null, null, 100f, "gm" },
                    { "1ea46104-e7d1-426b-bcf9-15dd8bf3fd48", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5620), 35f, "6% Discount", true, 273.7f, 238.7f, "40", null, null, 100f, "gm" },
                    { "fae25622-9971-4692-8bc1-ce6062fdf7c6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6340), 29f, "10% Discount", true, 590.95f, 561.95f, "58", null, null, 100f, "gm" },
                    { "37a4ce2f-d1cd-4b5e-8f21-c4de882f0a26", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6395), 282f, "4% Discount", true, 610.6f, 328.6f, "60", null, null, 100f, "gm" },
                    { "c35254d0-62e7-496f-bcac-17bbd618cf3f", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6928), 91f, "5% Discount", true, 332.25f, 241.25f, "77", null, null, 100f, "gm" },
                    { "034211cd-cc45-4460-9700-b192d7bdef70", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6900), 214f, "1% Discount", true, 243.8f, 29.8f, "76", null, null, 100f, "gm" },
                    { "136fb7da-8b6a-4931-bc92-82e97ad7f515", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6875), 438f, "10% Discount", true, 747.7f, 309.7f, "75", null, null, 100f, "gm" },
                    { "d9c4e900-5f93-4350-bf44-bc124d46a745", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6848), 45f, "2% Discount", true, 242.1f, 197.1f, "74", null, null, 100f, "gm" },
                    { "c409ea9b-6e04-4ff4-a1d9-7f734dc55a6a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6821), 127f, "3% Discount", true, 292.6f, 165.6f, "73", null, null, 100f, "gm" },
                    { "9bb13ceb-5342-4b10-ba13-b8bdd627946f", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6790), 35f, "8% Discount", true, 292.6f, 257.6f, "72", null, null, 100f, "gm" },
                    { "09e91484-722a-4dd7-b22c-280500ffec3c", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6765), 188f, "6% Discount", true, 437.9f, 249.9f, "71", null, null, 100f, "gm" },
                    { "1494b01f-83dc-46c4-a3b6-19ffb8edb983", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6367), 79f, "6% Discount", true, 149.35f, 70.35f, "59", null, null, 100f, "gm" },
                    { "c14e2623-958b-4580-8061-61cfae0cb47e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6710), 360f, "3% Discount", true, 574.9f, 214.9f, "69", null, null, 100f, "gm" },
                    { "ce5641a6-4a89-4dd9-8a0e-cdd97b9a162c", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6592), 598f, "9% Discount", true, 833.3f, 235.3f, "67", null, null, 100f, "gm" },
                    { "717788d3-68a1-4f53-a9b2-c2094dfbe76b", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6563), 194f, "6% Discount", true, 602.55f, 408.55f, "66", null, null, 100f, "gm" },
                    { "5b25fd5a-8de8-4fdd-afd9-d3df90e43e17", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6534), 177f, "3% Discount", true, 386.95f, 209.95f, "65", null, null, 100f, "gm" },
                    { "17797e12-bb1e-48e9-8471-3e4bcf00972a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6501), 273f, "2% Discount", true, 579.5f, 306.5f, "64", null, null, 100f, "gm" },
                    { "8910a113-a93d-40c0-b342-ad47f0c031ec", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6474), 21f, "7% Discount", true, 500.4f, 479.4f, "63", null, null, 100f, "gm" },
                    { "03f17ec4-5a1b-4d81-b4d4-9ccecc08be5e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6447), 62f, "9% Discount", true, 75.75f, 13.75f, "62", null, null, 100f, "gm" },
                    { "1ef8c297-78fd-4e04-a2c1-32eabe67fa4d", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6420), 245f, "7% Discount", true, 374.8f, 129.8f, "61", null, null, 100f, "gm" },
                    { "f186f26c-862d-4b88-900f-87f88cc513a3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6619), 266f, "7% Discount", true, 360.8f, 94.8f, "68", null, null, 100f, "gm" },
                    { "4481baa9-87c2-40c9-a522-34b994c7d32e", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5589), 630f, "7% Discount", true, 954.5f, 324.5f, "39", null, null, 100f, "gm" },
                    { "ac9b6125-af47-41aa-80df-323e5110e706", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(6738), 21f, "8% Discount", true, 520.7f, 499.7f, "70", null, null, 100f, "gm" },
                    { "486ffde3-62c0-499e-a0dc-1b337c3c0df5", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5527), 477f, "4% Discount", true, 706.8f, 229.8f, "37", null, null, 100f, "gm" },
                    { "0e03a58b-74c0-418c-861c-b9f2eadb8331", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4452), 547f, "10% Discount", true, 700.95f, 153.95f, "16", null, null, 100f, "gm" },
                    { "f4e61dd5-b8c4-4470-b1f6-a00091bab433", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4425), 525f, "3% Discount", true, 540.6f, 15.6f, "15", null, null, 100f, "gm" },
                    { "ee831988-1c2c-4037-9cda-2057c4f281ed", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4398), 55f, "2% Discount", true, 73.9f, 18.9f, "14", null, null, 100f, "gm" },
                    { "7760982d-2713-4693-a3c3-51597ba2faad", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4368), 147f, "10% Discount", true, 251.2f, 104.2f, "13", null, null, 100f, "gm" },
                    { "9a55c36c-0750-4927-a9f7-4b1ab240d606", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4340), 14f, "2% Discount", true, 245.1f, 231.1f, "12", null, null, 100f, "gm" },
                    { "e6689a82-449d-40da-bc60-1dc492052041", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4313), 540f, "1% Discount", true, 831.55f, 291.55f, "11", null, null, 100f, "gm" },
                    { "f247ec05-8d57-45ba-b8f5-5f20dee36dad", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4282), 589f, "6% Discount", true, 684.3f, 95.3f, "10", null, null, 100f, "gm" },
                    { "acb17562-56fb-4ce7-a334-6e02b91507f3", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4489), 81f, "10% Discount", true, 268.8f, 187.8f, "17", null, null, 100f, "gm" },
                    { "7b691ae8-d57c-47ef-9a73-6cf30ad82515", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4249), 184f, "3% Discount", true, 829.8f, 645.8f, "9", null, null, 100f, "gm" },
                    { "b70ffc20-0a6a-4ac2-b050-b4cd5c370679", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5559), 170f, "7% Discount", true, 268.9f, 98.9f, "38", null, null, 100f, "gm" },
                    { "2c57cb5e-a89e-492d-8045-b33ec16ae627", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4042), 284f, "3% Discount", true, 786.45f, 502.45f, "6", null, null, 100f, "gm" },
                    { "f18a554d-0532-4680-a106-2535d1a7b9f7", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4003), 802f, "10% Discount", true, 928.4f, 126.4f, "5", null, null, 200f, "gm" },
                    { "fcdbd0f2-be16-4183-84d1-0594ba007e35", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3972), 358f, "10% Discount", true, 509.8f, 151.8f, "4", null, null, 300f, "gm" },
                    { "a298e7d1-6a82-43c6-a037-2d2badcb27bc", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3935), 21f, "6% Discount", true, 432.5f, 411.5f, "3", null, null, 500f, "gm" },
                    { "46e4cb60-9168-4abe-bcac-c823ac8c1667", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(3872), 735f, "8% Discount", true, 815.55f, 80.55f, "2", null, null, 500f, "gm" },
                    { "65e1e0ab-d0d1-4a2c-b7ac-5da2317106e6", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(677), 59f, "10% Discount", true, 246.95f, 187.95f, "1", null, null, 200f, "gm" },
                    { "bdd81086-da73-49b0-9d98-1ecf6682f5bb", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4206), 12f, "7% Discount", true, 39.5f, 27.5f, "8", null, null, 100f, "gm" },
                    { "fa5fc6a2-a92d-434a-8882-a57878c5a6f1", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4520), 272f, "8% Discount", true, 999.7f, 727.7f, "18", null, null, 100f, "gm" },
                    { "231bb117-a072-42bd-8f89-3c8614fa87bd", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4072), 47f, "4% Discount", true, 291.9f, 244.9f, "7", null, null, 100f, "gm" },
                    { "ab88b614-14ff-44b5-a227-c58e82a721d8", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(4756), 550f, "7% Discount", true, 630.45f, 80.45f, "20", null, null, 100f, "gm" },
                    { "0c365a35-c382-4fa6-ae7c-ee9d1ef3c26a", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5495), 382f, "3% Discount", true, 422.45f, 40.45f, "36", null, null, 100f, "gm" },
                    { "6cf80745-8321-48a6-b143-fdbd62436992", 1, 1L, new DateTime(2019, 10, 25, 1, 30, 19, 126, DateTimeKind.Local).AddTicks(5464), 4f, "10% Discount", true, 26.3f, 22.3f, "35", null, null, 100f, "gm" },
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

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 127, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "ProductBarcodes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 128, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 120, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "1",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 121, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "10",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "11",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4593));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "13",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "15",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "17",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4749));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "19",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "2",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "20",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "21",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "22",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "23",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "24",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "25",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "26",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "29",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "3",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "30",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "31",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "32",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "33",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "34",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4951));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4971));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "38",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "39",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "4",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4531));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "40",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4993));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "41",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "42",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "43",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "44",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5022));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "45",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5028));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "46",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "47",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "48",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "49",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "5",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4538));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "50",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "51",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "52",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "54",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5155));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "55",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "56",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "57",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "58",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "59",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "6",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "60",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "61",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "62",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "63",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5216));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "64",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "65",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5228));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "66",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "67",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "68",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5315));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "69",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "7",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "70",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "71",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "72",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "73",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "74",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "75",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "76",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "77",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "8",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "ProductMasters",
                keyColumn: "Id",
                keyValue: "9",
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 19, 122, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "StoreCategories",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1001,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(8151));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1002,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1003,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1004,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1005,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1006,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1007,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "StoreMasters",
                keyColumn: "Id",
                keyValue: 1008,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 955, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "UserMasters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedOn",
                value: new DateTime(2019, 10, 25, 1, 30, 18, 950, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2019, 10, 25, 1, 30, 18, 954, DateTimeKind.Local).AddTicks(175), new DateTime(2019, 10, 25, 1, 30, 18, 953, DateTimeKind.Local).AddTicks(8356) });

            migrationBuilder.CreateIndex(
                name: "IX_CartDeviceLogs_CartDeviceId",
                table: "CartDeviceLogs",
                column: "CartDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDeviceLogs_ShoppingCartId",
                table: "CartDeviceLogs",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDeviceLogs_CartDeviceMasters_CartDeviceId",
                table: "CartDeviceLogs",
                column: "CartDeviceId",
                principalTable: "CartDeviceMasters",
                principalColumn: "CartDeviceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDeviceLogs_ShoppingCarts_ShoppingCartId",
                table: "CartDeviceLogs",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
