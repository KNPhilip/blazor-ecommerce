using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PublisherDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbUserProduct");

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 9 });

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPublishers",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPublishers", x => new { x.ProductId, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_ProductPublishers_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPublishers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "BirthDate", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "IsSoftDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f39bc69-752a-495f-9e13-07b8d447e98f", 0, null, new DateTime(1987, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f39bc69-752a-495f-9e13-07b8d447e98f", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@castle-rock.com", true, null, false, null, false, null, "Castle Rock Entertainment", "INFO@CASTLE-ROCK.COM", "INFO@CASTLE-ROCK.COM", "$3y$20$nR1Q8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "0f39bc69-752a-495f-9e13-07b8d447e98f", false, "info@castle-rock.com" },
                    { "27045ac4-b1d1-4dbb-a13b-529456b1dad2", 0, null, new DateTime(1978, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "27045ac4-b1d1-4dbb-a13b-529456b1dad2", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "erin@morgenstern.fake", true, "Erin", false, "Morgenstern", false, null, null, "ERIN@MORGENSTERN.FAKE", "ERIN@MORGENSTERN.FAKE", "$3y$20$kM3H9JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "27045ac4-b1d1-4dbb-a13b-529456b1dad2", false, "erin@morgenstern.fake" },
                    { "2bc82d0e-8b77-4a6a-84da-e79b618acbcf", 0, null, new DateTime(1912, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "2bc82d0e-8b77-4a6a-84da-e79b618acbcf", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "studio_operations@paramount.com", true, null, false, null, false, null, "Paramount Pictures", "STUDIO_OPERATIONS@PARAMOUNT.COM", "STUDIO_OPERATIONS@PARAMOUNT.COM", "$3y$20$oS2R8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "2bc82d0e-8b77-4a6a-84da-e79b618acbcf", false, "studio_operations@paramount.com" },
                    { "354f78e9-61bc-4f6e-8761-3cfab3749d42", 0, null, new DateTime(2002, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "354f78e9-61bc-4f6e-8761-3cfab3749d42", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "biz@cdprojektred.com", true, null, false, null, false, null, "CD Projekt RED", "BIZ@CDPROJEKTRED.COM", "BIZ@CDPROJEKTRED.COM", "$3y$20$sW6V8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "354f78e9-61bc-4f6e-8761-3cfab3749d42", false, "biz@cdprojektred.com" },
                    { "35be5291-5ce0-4483-9e7d-9d60dc912f98", 0, null, new DateTime(1920, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "35be5291-5ce0-4483-9e7d-9d60dc912f98", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank@herbert.fake", true, "Frank", false, "Herbert", false, null, null, "FRANK@HERBERT.FAKE", "FRANK@HERBERT.FAKE", "$3y$20$vP5K8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "35be5291-5ce0-4483-9e7d-9d60dc912f98", false, "frank@herbert.fake" },
                    { "3711943c-2d78-4a3f-b007-a6ee15ba0e7b", 0, null, new DateTime(1996, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "3711943c-2d78-4a3f-b007-a6ee15ba0e7b", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@barunsonena.com", true, null, false, null, false, null, "Barunson E&A and CJ Entertainment", "CONTACT@BARUNSONENA.COM", "CONTACT@BARUNSONENA.COM", "$3y$20$mQ0P8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "3711943c-2d78-4a3f-b007-a6ee15ba0e7b", false, "contact@barunsonena.com" },
                    { "448d440b-c1c4-453c-8cda-608fedad3762", 0, null, new DateTime(2003, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "448d440b-c1c4-453c-8cda-608fedad3762", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "support@square-enix.fake", true, null, false, null, false, null, "Square Enix", "SUPPORT@SQUARE-ENIX.FAKE", "SUPPORT@SQUARE-ENIX.FAKE", "$3y$20$vZ9Y8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "448d440b-c1c4-453c-8cda-608fedad3762", false, "support@square-enix.fake" },
                    { "47fac782-04bb-45f0-8700-2b9a3b855984", 0, null, new DateTime(1972, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "47fac782-04bb-45f0-8700-2b9a3b855984", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andy@weir.fake", true, "Andy", false, "Weir", false, null, null, "ANDY@WEIR.FAKE", "ANDY@WEIR.FAKE", "$3y$20$bDDaBlqNVSIfhAL7UBFjA2sDVVQABeMd", null, false, "47fac782-04bb-45f0-8700-2b9a3b855984", false, "andy@weir.fake" },
                    { "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393", 0, null, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@supergiantgames.com", true, null, false, null, false, null, "Supergiant Games", "INFO@SUPERGIANTGAMES.COM", "INFO@SUPERGIANTGAMES.COM", "$3y$20$uY8X8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393", false, "info@supergiantgames.com" },
                    { "7c4df877-bffb-4cbd-8417-097cff415a03", 0, null, new DateTime(2009, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c4df877-bffb-4cbd-8417-097cff415a03", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "scoops@minecraft.net", true, null, false, null, false, null, "Mojang Studios", "SCOOPS@MINECRAFT.NET", "SCOOPS@MINECRAFT.NET", "$3y$20$yC2B8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "7c4df877-bffb-4cbd-8417-097cff415a03", false, "scoops@minecraft.net" },
                    { "8567a393-058f-4ecb-a209-307dc6c8c8fa", 0, null, new DateTime(1978, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "8567a393-058f-4ecb-a209-307dc6c8c8fa", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "madeline@miller.fake", true, "Madeline", false, "Miller", false, null, null, "MADELINE@MILLER.FAKE", "MADELINE@MILLER.FAKE", "$3y$20$eR7M8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "8567a393-058f-4ecb-a209-307dc6c8c8fa", false, "madeline@miller.fake" },
                    { "87ef6fb3-1a20-472e-b6d3-7599afb506e6", 0, null, new DateTime(1969, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "87ef6fb3-1a20-472e-b6d3-7599afb506e6", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jojo@moyes.fake", true, "Jojo", false, "Moyes", false, null, null, "JOJO@MOYES.FAKE", "JOJO@MOYES.FAKE", "$3y$20$hT8N8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "87ef6fb3-1a20-472e-b6d3-7599afb506e6", false, "jojo@moyes.fake" },
                    { "8a57c8e1-08f3-42b5-9671-cbc84976fb01", 0, null, new DateTime(1993, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "8a57c8e1-08f3-42b5-9671-cbc84976fb01", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ms-comms@marvelstudios.com", true, null, false, null, false, null, "Marvel Studios", "MS-COMMS@MARVELSTUDIOS.COM", "MS-COMMS@MARVELSTUDIOS.COM", "$3y$20$kP9O8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "8a57c8e1-08f3-42b5-9671-cbc84976fb01", false, "ms-comms@marvelstudios.com" },
                    { "8b1922c7-8118-474b-aa7b-032bec00234c", 0, null, new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8b1922c7-8118-474b-aa7b-032bec00234c", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "support@rockstargames.com", true, null, false, null, false, null, "Rockstar Games", "SUPPORT@ROCKSTARGAMES.COM", "SUPPORT@ROCKSTARGAMES.COM", "$3y$20$xB1A8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "8b1922c7-8118-474b-aa7b-032bec00234c", false, "support@rockstargames.com" },
                    { "9904a3cc-92aa-43e4-a743-5bdc46374c6c", 0, null, new DateTime(1977, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "9904a3cc-92aa-43e4-a743-5bdc46374c6c", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alex@michaelides.fake", true, "Alex", false, "Michaelides", false, null, null, "ALEX@MICHAELIDES.FAKE", "ALEX@MICHAELIDES.FAKE", "$3y$20$e0NRG7mXG1fXo8e2c4c0EuXHkOa7wY", null, false, "9904a3cc-92aa-43e4-a743-5bdc46374c6c", false, "alex@michaelides.fake" },
                    { "a73f5524-6667-4a81-a1a0-1b3e3bbc432f", 0, null, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a73f5524-6667-4a81-a1a0-1b3e3bbc432f", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "us@innersloth.com", true, null, false, null, false, null, "InnerSloth", "US@INNERSLOTH.COM", "US@INNERSLOTH.COM", "$3y$20$tX7W8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "a73f5524-6667-4a81-a1a0-1b3e3bbc432f", false, "us@innersloth.com" },
                    { "a989fbed-3273-4342-bf5b-7724721e1504", 0, null, new DateTime(1975, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "a989fbed-3273-4342-bf5b-7724721e1504", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "markus@zusak.fake", true, "Markus", false, "Zusak", false, null, null, "MARKUS@ZUSAK.FAKE", "MARKUS@ZUSAK.FAKE", "$3y$20$zQ6L8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "a989fbed-3273-4342-bf5b-7724721e1504", false, "markus@zusak.fake" },
                    { "bafc87aa-2221-4543-ac96-9f1e4aac691d", 0, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bafc87aa-2221-4543-ac96-9f1e4aac691d", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "brit@bennett.fake", true, "Brit", false, "Bennett", false, null, null, "BRIT@BENNETT.FAKE", "BRIT@BENNETT.FAKE", "$3y$20$uN4J8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "bafc87aa-2221-4543-ac96-9f1e4aac691d", false, "brit@bennett.fake" },
                    { "c5534807-f265-41c6-afa8-fcbefabb164b", 0, null, new DateTime(1923, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "c5534807-f265-41c6-afa8-fcbefabb164b", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "support@wbd.com", true, null, false, null, false, null, "Warner Bros. Pictures", "SUPPORT@WBD.COM", "SUPPORT@WBD.COM", "$3y$20$pT3S8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "c5534807-f265-41c6-afa8-fcbefabb164b", false, "support@wbd.com" },
                    { "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb", 0, null, new DateTime(1949, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delia@owens.fake", true, "Delia", false, "Owens", false, null, null, "DELIA@OWENS.FAKE", "DELIA@OWENS.FAKE", "$3y$20$gk1F8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb", false, "delia@owens.fake" },
                    { "d6c9880a-9926-400f-86da-79dc08234f33", 0, null, new DateTime(1979, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "d6c9880a-9926-400f-86da-79dc08234f33", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info-asia@capcom.com", true, null, false, null, false, null, "Capcom", "INFO-ASIA@CAPCOM.COM", "INFO-ASIA@CAPCOM.COM", "$3y$20$wA0Z8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "d6c9880a-9926-400f-86da-79dc08234f33", false, "info-asia@capcom.com" },
                    { "dc7b8125-6391-4774-b1f2-ad92281ed289", 0, null, new DateTime(1986, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dc7b8125-6391-4774-b1f2-ad92281ed289", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tara@westover.fake", true, "Tara", false, "Westover", false, null, null, "TARA@WESTOVER.FAKE", "TARA@WESTOVER.FAKE", "$3y$20$hL2G9JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "dc7b8125-6391-4774-b1f2-ad92281ed289", false, "tara@westover.fake" },
                    { "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d", 0, null, new DateTime(1993, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@sony.fake", true, null, false, null, false, null, "Sony Interactive Entertainment", "INFO@SONY.FAKE", "INFO@SONY.FAKE", "$3y$20$rV5U8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d", false, "info@sony.fake" },
                    { "e2e7e873-a404-4c13-bd5e-8c10a046c168", 0, null, new DateTime(1889, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "e2e7e873-a404-4c13-bd5e-8c10a046c168", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@nintendo.de", true, null, false, null, false, null, "Nintendo", "CONTACT@NINTENDO.DE", "CONTACT@NINTENDO.DE", "$3y$20$qU4T8JH6k9mXQ8e2c4c0EuXHkOa7wY", null, false, "e2e7e873-a404-4c13-bd5e-8c10a046c168", false, "contact@nintendo.de" }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/d/db/The_Matrix.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/b/ba/Poster_-_The_Matrix_Reloaded.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/7/7b/The-matrix-revolutions_oxlati6t.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU_P2_Box_Art_2.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/9/9a/Among_Us_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/ce/FFVIIRemake.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/2/2c/Resident_Evil_Village.png");

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 23, 9 },
                column: "OriginalPrice",
                value: 69.99m);

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 21, 6, false, 0m, 14.99m, true },
                    { 22, 8, false, 59.99m, 49.99m, true },
                    { 24, 8, false, 79.99m, 59.99m, true },
                    { 29, 9, false, 54.99m, 49.99m, true }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedDate",
                value: new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedDate",
                value: new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedDate",
                value: new DateTime(2018, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishedDate",
                value: new DateTime(2018, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublishedDate",
                value: new DateTime(2011, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "PublishedDate",
                value: new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "PublishedDate",
                value: new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "PublishedDate",
                value: new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "PublishedDate",
                value: new DateTime(2018, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "PublishedDate",
                value: new DateTime(2019, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "PublishedDate",
                value: new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "PublishedDate",
                value: new DateTime(2019, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Featured", "PublishedDate" },
                values: new object[] { false, new DateTime(1994, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "PublishedDate",
                value: new DateTime(1972, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "PublishedDate",
                value: new DateTime(2008, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "PublishedDate",
                value: new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Matrix is a 1999 science fiction action film (and franchise) where humanity is unknowingly trapped in a simulated reality called the Matrix by intelligent machines.", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Matrix Reloaded follows Neo, Morpheus, and Trinity as they battle the machines for Zion's survival and the fate of humanity.", new DateTime(2003, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Reloaded" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Featured", "PublishedDate", "Title" },
                values: new object[] { "The Matrix Revolutions is the third and final film in the original Matrix trilogy, depicting the epic war between humans and machines as Neo must confront the rogue program Agent Smith.", false, new DateTime(2003, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Revolutions" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Matrix Resurrections is a 2021 science fiction film and the fourth installment in The Matrix franchise. It revisits the world of the Matrix with returning characters and new challenges.", new DateTime(2021, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description", "Featured", "PublishedDate", "Title" },
                values: new object[] { 2, "Spider-Man: No Way Home is a 2021 superhero film directed by Jon Watts. It follows Peter Parker as he seeks help from Doctor Strange to manage the fallout from revealing his identity.", true, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No Way Home" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Legend of Zelda: Breath of the Wild is an action-adventure game developed by Nintendo. Set in a vast open world, players control Link as he awakens from a long slumber to defeat Calamity Ganon.", new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Legend of Zelda: Breath of the Wild" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Featured", "PublishedDate", "Title" },
                values: new object[] { "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.", false, new DateTime(2020, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghost of Tsushima" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Featured", "PublishedDate", "Title" },
                values: new object[] { "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.", true, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyberpunk 2077" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Last of Us is an action-adventure video game series and media franchise created by Naughty Dog and published by Sony Interactive Entertainment.", new DateTime(2013, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.", new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Last of Us Part II" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Among Us" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.", new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hades" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Featured", "PublishedDate", "Title" },
                values: new object[] { "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.", false, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final Fantasy VII Remake" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "PublishedDate", "Title" },
                values: new object[] { "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.", new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil Village" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Featured", "IsSoftDeleted", "PublishedDate", "Title", "Visible" },
                values: new object[,]
                {
                    { 31, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West while attempting to survive against government forces, rival gangs, and other adversaries.", true, false, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Dead Redemption 2", true },
                    { 32, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.", false, false, new DateTime(2009, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minecraft", true }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Data", "ProductId", "Type" },
                values: new object[,]
                {
                    { 31, "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg", 31, 0 },
                    { 32, "https://upload.wikimedia.org/wikipedia/en/b/b6/Minecraft_2024_cover_art.png", 32, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductPublishers",
                columns: new[] { "ProductId", "PublisherId" },
                values: new object[,]
                {
                    { 1, "47fac782-04bb-45f0-8700-2b9a3b855984" },
                    { 2, "9904a3cc-92aa-43e4-a743-5bdc46374c6c" },
                    { 3, "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb" },
                    { 4, "dc7b8125-6391-4774-b1f2-ad92281ed289" },
                    { 5, "27045ac4-b1d1-4dbb-a13b-529456b1dad2" },
                    { 6, "bafc87aa-2221-4543-ac96-9f1e4aac691d" },
                    { 7, "35be5291-5ce0-4483-9e7d-9d60dc912f98" },
                    { 8, "a989fbed-3273-4342-bf5b-7724721e1504" },
                    { 9, "8567a393-058f-4ecb-a209-307dc6c8c8fa" },
                    { 10, "87ef6fb3-1a20-472e-b6d3-7599afb506e6" },
                    { 11, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 12, "3711943c-2d78-4a3f-b007-a6ee15ba0e7b" },
                    { 13, "0f39bc69-752a-495f-9e13-07b8d447e98f" },
                    { 14, "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" },
                    { 15, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 16, "2bc82d0e-8b77-4a6a-84da-e79b618acbcf" },
                    { 17, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 18, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 19, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 20, "c5534807-f265-41c6-afa8-fcbefabb164b" },
                    { 21, "8a57c8e1-08f3-42b5-9671-cbc84976fb01" },
                    { 22, "e2e7e873-a404-4c13-bd5e-8c10a046c168" },
                    { 23, "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                    { 24, "354f78e9-61bc-4f6e-8761-3cfab3749d42" },
                    { 25, "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                    { 26, "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d" },
                    { 27, "a73f5524-6667-4a81-a1a0-1b3e3bbc432f" },
                    { 28, "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393" },
                    { 29, "448d440b-c1c4-453c-8cda-608fedad3762" },
                    { 30, "d6c9880a-9926-400f-86da-79dc08234f33" },
                    { 31, "8b1922c7-8118-474b-aa7b-032bec00234c" },
                    { 32, "7c4df877-bffb-4cbd-8417-097cff415a03" }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 31, 8, false, 0m, 26.99m, true },
                    { 32, 8, false, 29.99m, 24.99m, true },
                    { 32, 9, false, 19.99m, 14.99m, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPublishers_PublisherId",
                table: "ProductPublishers",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPublishers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f39bc69-752a-495f-9e13-07b8d447e98f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27045ac4-b1d1-4dbb-a13b-529456b1dad2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2bc82d0e-8b77-4a6a-84da-e79b618acbcf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "354f78e9-61bc-4f6e-8761-3cfab3749d42");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35be5291-5ce0-4483-9e7d-9d60dc912f98");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3711943c-2d78-4a3f-b007-a6ee15ba0e7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "448d440b-c1c4-453c-8cda-608fedad3762");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47fac782-04bb-45f0-8700-2b9a3b855984");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c4df877-bffb-4cbd-8417-097cff415a03");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8567a393-058f-4ecb-a209-307dc6c8c8fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87ef6fb3-1a20-472e-b6d3-7599afb506e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a57c8e1-08f3-42b5-9671-cbc84976fb01");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1922c7-8118-474b-aa7b-032bec00234c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9904a3cc-92aa-43e4-a743-5bdc46374c6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a73f5524-6667-4a81-a1a0-1b3e3bbc432f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a989fbed-3273-4342-bf5b-7724721e1504");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bafc87aa-2221-4543-ac96-9f1e4aac691d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5534807-f265-41c6-afa8-fcbefabb164b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6c9880a-9926-400f-86da-79dc08234f33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc7b8125-6391-4774-b1f2-ad92281ed289");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2e7e873-a404-4c13-bd5e-8c10a046c168");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 22, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 24, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 29, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 31, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 32, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 32, 9 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/a/a3/Get_Out_poster.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU_P2_Box_Art_2.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/9/9a/Among_Us_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/c/ce/FFVIIRemake.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/2/2c/Resident_Evil_Village.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "Data",
                value: "https://upload.wikimedia.org/wikipedia/en/b/b6/Minecraft_2024_cover_art.png");

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 23, 9 },
                column: "OriginalPrice",
                value: 79.99m);

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 21, 8, false, 59.99m, 49.99m, true },
                    { 21, 9, false, 69.99m, 59.99m, true }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Featured",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Pulp Fiction is a 1994 crime film directed by Quentin Tarantino. The film intertwines multiple narratives of crime in Los Angeles, featuring an ensemble cast.", "Pulp Fiction" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Title" },
                values: new object[] { "The Matrix Resurrections is a 2021 science fiction film and the fourth installment in The Matrix franchise. It revisits the world of the Matrix with returning characters and new challenges.", "The Matrix Resurrections" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Featured", "Title" },
                values: new object[] { "Spider-Man: No Way Home is a 2021 superhero film directed by Jon Watts. It follows Peter Parker as he seeks help from Doctor Strange to manage the fallout from revealing his identity.", true, "Spider-Man: No Way Home" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Get Out is a 2017 horror film written and directed by Jordan Peele. It follows a young African-American man who uncovers disturbing secrets when he meets his white girlfriend's family.", "Get Out" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description", "Featured", "Title" },
                values: new object[] { 3, "The Legend of Zelda: Breath of the Wild is an action-adventure game developed by Nintendo. Set in a vast open world, players control Link as he awakens from a long slumber to defeat Calamity Ganon.", false, "The Legend of Zelda: Breath of the Wild" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.", "Ghost of Tsushima" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Featured", "Title" },
                values: new object[] { "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.", true, "Cyberpunk 2077" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Featured", "Title" },
                values: new object[] { "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.", false, "The Last of Us Part II" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.", "Among Us" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.", "Hades" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.", "Final Fantasy VII Remake" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.", "Resident Evil Village" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Featured", "Title" },
                values: new object[] { "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West while attempting to survive against government forces, rival gangs, and other adversaries.", true, "Red Dead Redemption 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.", "Minecraft" });

            migrationBuilder.CreateIndex(
                name: "IX_DbUserProduct_PublishersId",
                table: "DbUserProduct",
                column: "PublishersId");
        }
    }
}
