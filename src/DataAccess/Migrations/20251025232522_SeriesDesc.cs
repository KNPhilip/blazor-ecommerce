using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeriesDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "The Matrix is a groundbreaking sci-fi saga that explores a dystopian future in which humanity is unknowingly trapped inside a simulated reality — the Matrix — created by intelligent machines to subdue the human population, while their bodies’ bioelectric energy is harvested to power the machines.");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "The Red Dead series is a sweeping, character-driven saga that explores the dying days of the American frontier — a world caught between rugged freedom and the encroaching forces of civilization. Developed by Rockstar Games, the series immerses players in a gritty, cinematic portrayal of the Old West, where loyalty, survival, and morality collide in a landscape as beautiful as it is brutal.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");
        }
    }
}
