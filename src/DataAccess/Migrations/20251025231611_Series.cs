using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Series : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSeries",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSeries", x => new { x.ProductId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_ProductSeries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSeries_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "CreatedDate", "IsSoftDeleted", "Name" },
                values: new object[] { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Nintendo Switch" });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 31, 8 },
                column: "Price",
                value: 86.99m);

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 31, 9, false, 0m, 69.99m, true },
                    { 31, 10, false, 0m, 69.99m, true }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "America, 1899. The end of the Wild West era has begun. After a robbery goes badly wrong in the western town of Blackwater, Arthur Morgan and the Van der Linde gang are forced to flee. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him.");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Featured", "IsSoftDeleted", "PublishedDate", "Title", "Visible" },
                values: new object[,]
                {
                    { 33, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vast, rugged, and lawless. As a young man, you were helpless to prevent the slaughter of your family at the hands of bandits. Many years later, you live as a bounty hunter bringing criminals to justice, while struggling to unravel the mystery of your past. You must find those who murdered your family. Then, you will take your revenge. A blazing arcade-style third-person game fueled by precision gunplay, Red Dead Revolver is a classic tale of vengeance on the untamed frontier.", false, false, new DateTime(2004, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Revolver", true },
                    { 34, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Step into the vibrant, ever-evolving world of Red Dead Online and experience life across frontier America. Forge your own path as you battle lawmen, outlaw gangs and ferocious wild animals to build a life on the American frontier. Build a camp, ride solo or form a posse and explore everything from the snowy mountains in the North to the swamps of the South, from remote outposts to busy farms and bustling towns. Chase down bounties, hunt, fish and trade, search for exotic treasures, run your own underground Moonshine distillery, or become a Naturalist to learn the secrets of the animal kingdom and much more in a world of astounding depth and detail.", false, false, new DateTime(2018, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Online", true },
                    { 35, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Journey across the sprawling expanses of the American West and Mexico in Red Dead Redemption. When federal agents threaten his family, former outlaw John Marston is forced to hunt down the gang of criminals he once called friends. Step into the events immediately following the 2018 blockbuster, Red Dead Redemption 2, in the critically acclaimed tale of Marston’s journey to bury his blood-stained past, one man at a time.", false, false, new DateTime(2010, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption", true },
                    { 36, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "When former outlaw John Marston wakes up at his farmhouse, he finds a world gone insane: overnight, deranged hordes have overrun the towns and outposts of the American frontier. In a desperate attempt to save his family, Marston must traverse a world torn apart by chaos and disorder, using every skill he has to survive long enough to find a cure.", false, false, new DateTime(2010, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption: Undead Nightmare", true },
                    { 37, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "As Arthur Morgan, loyal right hand to charismatic gang leader, Dutch Van Der Linde, you’ll live, hunt, party, steal and fight alongside a diverse cast of outlaws you’ll come to know as family, including Bill Williamson, Javier Escuella, Sadie Adler, Micah Bell, John Marston, Charles Smith, Susan Grimshaw and many more. The Van Der Linde gang is a group of fully realized characters and living and fighting alongside this gang is an experience unlike any other.", false, false, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2: Ultimate Edition", true }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "The Matrix Series" },
                    { 2, "", "Red Dead Series" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Data", "ProductId", "Type" },
                values: new object[,]
                {
                    { 33, "https://upload.wikimedia.org/wikipedia/en/c/c1/Red_Dead_Revolver_Coverart.jpg", 33, 0 },
                    { 34, "https://static.wikia.nocookie.net/reddeadredemption/images/9/9d/RedDeadOnline-EpicGamesStore-CoverArt.jpg/revision/latest?cb=20201201170402", 34, 0 },
                    { 35, "https://upload.wikimedia.org/wikipedia/en/a/a7/Red_Dead_Redemption.jpg", 35, 0 },
                    { 36, "https://upload.wikimedia.org/wikipedia/en/5/59/Red_Dead_Redemption_-_Undead_Nightmare_cover.JPG", 36, 0 },
                    { 37, "https://image.api.playstation.com/cdn/UP1004/CUSA03041_00/3zDubiWo2X5WU18FGiwlsf4lKWb8MwkE.png?w=620&thumb=false", 37, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductSeries",
                columns: new[] { "ProductId", "SeriesId" },
                values: new object[,]
                {
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 31, 2 },
                    { 33, 2 },
                    { 34, 2 },
                    { 35, 2 },
                    { 36, 2 },
                    { 37, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 33, 9, false, 11.49m, 6.99m, true },
                    { 33, 10, false, 11.49m, 6.99m, true },
                    { 34, 8, false, 0m, 28.99m, true },
                    { 34, 9, false, 0m, 23.49m, true },
                    { 34, 10, false, 0m, 23.49m, true },
                    { 35, 8, false, 0m, 72.49m, true },
                    { 35, 9, false, 0m, 66.49m, true },
                    { 35, 10, false, 0m, 33.99m, true },
                    { 35, 11, false, 0m, 49.99m, true },
                    { 36, 8, false, 0m, 72.49m, true },
                    { 36, 9, false, 0m, 66.49m, true },
                    { 36, 10, false, 0m, 33.99m, true },
                    { 36, 11, false, 0m, 49.99m, true },
                    { 37, 8, false, 0m, 144.99m, true },
                    { 37, 9, false, 0m, 114.99m, true },
                    { 37, 10, false, 0m, 114.99m, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSeries_SeriesId",
                table: "ProductSeries",
                column: "SeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSeries");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 31, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 31, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 33, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 33, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 34, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 34, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 34, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 35, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 35, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 35, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 35, 11 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 36, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 36, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 36, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 36, 11 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 37, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 37, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 37, 10 });

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 31, 8 },
                column: "Price",
                value: 26.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "Description",
                value: "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West while attempting to survive against government forces, rival gangs, and other adversaries.");
        }
    }
}
