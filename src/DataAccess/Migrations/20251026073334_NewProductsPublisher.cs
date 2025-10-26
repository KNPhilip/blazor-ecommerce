using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewProductsPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductPublishers",
                columns: new[] { "ProductId", "PublisherId" },
                values: new object[,]
                {
                    { 33, "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { 34, "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { 35, "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { 36, "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { 37, "8b1922c7-8118-474b-aa7b-032bec00234c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductPublishers",
                keyColumns: new[] { "ProductId", "PublisherId" },
                keyValues: new object[] { 33, "8b1922c7-8118-474b-aa7b-032bec00234c" });

            migrationBuilder.DeleteData(
                table: "ProductPublishers",
                keyColumns: new[] { "ProductId", "PublisherId" },
                keyValues: new object[] { 34, "8b1922c7-8118-474b-aa7b-032bec00234c" });

            migrationBuilder.DeleteData(
                table: "ProductPublishers",
                keyColumns: new[] { "ProductId", "PublisherId" },
                keyValues: new object[] { 35, "8b1922c7-8118-474b-aa7b-032bec00234c" });

            migrationBuilder.DeleteData(
                table: "ProductPublishers",
                keyColumns: new[] { "ProductId", "PublisherId" },
                keyValues: new object[] { 36, "8b1922c7-8118-474b-aa7b-032bec00234c" });

            migrationBuilder.DeleteData(
                table: "ProductPublishers",
                keyColumns: new[] { "ProductId", "PublisherId" },
                keyValues: new object[] { 37, "8b1922c7-8118-474b-aa7b-032bec00234c" });
        }
    }
}
