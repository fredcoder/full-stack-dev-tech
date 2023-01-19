using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class DBMigration1 : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "IsActive", "Name", "Price", "ProductTypeId" },
                values: new object[,]
                {
                    { "f6095b43-57f1-49a7-9acf-ac3d145fef4f", true, "Don Quixote", 12f, "b00db9eb-7650-4878-b814-8a96d5a8220e" },
                    { "cf994cb1-dc3c-4822-93f7-a7422a016ca9", true, "Microwave", 30f, "f30e74cd-2494-4fc8-8eb3-8de05c4a821e" },
                    { "50909b94-5134-4392-be80-13bcccd2086c", true, "Pizza", 15f, "070e30e7-488b-47e3-ad28-4379b9be6185" },
                    { "7caba613-eaa2-4c83-9d47-97b438169f95", true, "Chair", 25f, "74ca9e4c-2f51-4bfb-8ee0-12efe0db187f" },
                    { "7a852c93-ca4f-4ab5-84ac-c8b70927506e", true, "Lego", 30f, "d6d124a9-df5b-4ae8-848d-d15bb33bbd19" }
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
