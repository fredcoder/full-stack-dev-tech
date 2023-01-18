using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDev.Migrations
{
    public partial class DBMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "2210eb18-7a6a-4845-bd1d-6f137450a06e");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "44604cfa-6597-470c-a838-ecb7cf1f1e62");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "895d5bdc-6a3c-4a23-8d03-67085184d35c");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "a1e84b44-6944-4f27-af9b-15e3c935faee");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "ea1520ad-4d65-42ad-831f-13450c149787");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Product");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "Name", "Price", "ProductTypeId" },
                values: new object[,]
                {
                    { "61ea54a5-1325-46b5-bfa5-de0e86a72e8a", true, "Don Quixote", 12f, "b00db9eb-7650-4878-b814-8a96d5a8220e" },
                    { "1e16f2fd-6659-444d-bae6-092e5f975e53", true, "Microwave", 30f, "f30e74cd-2494-4fc8-8eb3-8de05c4a821e" },
                    { "b3a45d3a-9902-4d5e-a2a1-07715dc63844", true, "Pizza", 15f, "070e30e7-488b-47e3-ad28-4379b9be6185" },
                    { "9fc90f76-e48c-45f4-8bf0-253b5d2b3919", true, "Chair", 25f, "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f" },
                    { "19cb64f3-f223-444d-aa8b-e48200e36c93", true, "Lego", 30f, "d6d124a9-df5b-4ae8-848d-d15bb33bbd19" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "19cb64f3-f223-444d-aa8b-e48200e36c93");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "1e16f2fd-6659-444d-bae6-092e5f975e53");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "61ea54a5-1325-46b5-bfa5-de0e86a72e8a");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "9fc90f76-e48c-45f4-8bf0-253b5d2b3919");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "b3a45d3a-9902-4d5e-a2a1-07715dc63844");

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "Name", "Price", "ProductTypeId", "TypeId" },
                values: new object[,]
                {
                    { "a1e84b44-6944-4f27-af9b-15e3c935faee", true, "Don Quixote", 12f, null, "b00db9eb-7650-4878-b814-8a96d5a8220e" },
                    { "2210eb18-7a6a-4845-bd1d-6f137450a06e", true, "Microwave", 30f, null, "f30e74cd-2494-4fc8-8eb3-8de05c4a821e" },
                    { "44604cfa-6597-470c-a838-ecb7cf1f1e62", true, "Pizza", 15f, null, "070e30e7-488b-47e3-ad28-4379b9be6185" },
                    { "895d5bdc-6a3c-4a23-8d03-67085184d35c", true, "Chair", 25f, null, "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f" },
                    { "ea1520ad-4d65-42ad-831f-13450c149787", true, "Lego", 30f, null, "d6d124a9-df5b-4ae8-848d-d15bb33bbd19" }
                });
        }
    }
}
