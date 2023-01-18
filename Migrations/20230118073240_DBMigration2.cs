using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDev.Migrations
{
    public partial class DBMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "0d039ad9-4c3d-49ca-9966-7b893e8d0944");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "28ce8f23-6943-4f5f-af3b-73de3143751e");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "43b11ab4-16ac-47d3-8ede-5b9f49ae04e3");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "adae976f-8781-4f91-91a8-12cb2ca412cf");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "cad4b686-4b76-4818-8f80-ef2fb8c0a811");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "Name", "Price", "ProductTypeId", "TypeId" },
                values: new object[,]
                {
                    { "0d039ad9-4c3d-49ca-9966-7b893e8d0944", true, "Books", 10f, null, "b00db9eb-7650-4878-b814-8a96d5a8220e" },
                    { "28ce8f23-6943-4f5f-af3b-73de3143751e", true, "Electronics", 10f, null, "f30e74cd-2494-4fc8-8eb3-8de05c4a821e" },
                    { "adae976f-8781-4f91-91a8-12cb2ca412cf", true, "Food", 10f, null, "070e30e7-488b-47e3-ad28-4379b9be6185" },
                    { "43b11ab4-16ac-47d3-8ede-5b9f49ae04e3", true, "Furniture", 10f, null, "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f" },
                    { "cad4b686-4b76-4818-8f80-ef2fb8c0a811", true, "Toys", 10f, null, "d6d124a9-df5b-4ae8-848d-d15bb33bbd19" }
                });
        }
    }
}
