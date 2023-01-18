using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDev.Migrations
{
    public partial class DBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b00db9eb-7650-4878-b814-8a96d5a8220e", "Books" },
                    { "f30e74cd-2494-4fc8-8eb3-8de05c4a821e", "Electronics" },
                    { "070e30e7-488b-47e3-ad28-4379b9be6185", "Food" },
                    { "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f", "Furniture" },
                    { "d6d124a9-df5b-4ae8-848d-d15bb33bbd19", "Toys" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductType");
        }
    }
}
