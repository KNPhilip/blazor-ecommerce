using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPublishers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbUserProduct",
                columns: table => new
                {
                    PublishedProductsId = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUserProduct", x => new { x.PublishedProductsId, x.PublishersId });
                    table.ForeignKey(
                        name: "FK_DbUserProduct_AspNetUsers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbUserProduct_Products_PublishedProductsId",
                        column: x => x.PublishedProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProduct_PublishersId",
                table: "DbUserProduct",
                column: "PublishersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbUserProduct");
        }
    }
}
