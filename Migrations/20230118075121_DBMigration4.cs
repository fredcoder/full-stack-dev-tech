using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDev.Migrations
{
    public partial class DBMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "Name", "Price", "ProductTypeId" },
                values: new object[,]
                {
                    { "7087d279-0d0d-40f2-8521-7594cd4085f0", true, "Don Quixote", 12f, "b00db9eb-7650-4878-b814-8a96d5a8220e" },
                    { "bb904871-2627-404d-809d-aec7e60bbe40", true, "Microwave", 30f, "f30e74cd-2494-4fc8-8eb3-8de05c4a821e" },
                    { "5cbaed4e-4a9e-495e-9dd1-310d931156c3", true, "Pizza", 15f, "070e30e7-488b-47e3-ad28-4379b9be6185" },
                    { "83cdb933-1daa-40d2-be0f-bde9810510b1", true, "Chair", 25f, "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f" },
                    { "75a248e1-91a0-4698-bf57-616567cf6e08", true, "Lego", 30f, "d6d124a9-df5b-4ae8-848d-d15bb33bbd19" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "5cbaed4e-4a9e-495e-9dd1-310d931156c3");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "7087d279-0d0d-40f2-8521-7594cd4085f0");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "75a248e1-91a0-4698-bf57-616567cf6e08");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "83cdb933-1daa-40d2-be0f-bde9810510b1");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: "bb904871-2627-404d-809d-aec7e60bbe40");

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
    }
}
