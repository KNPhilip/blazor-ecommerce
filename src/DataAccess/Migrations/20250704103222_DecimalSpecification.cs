using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DecimalSpecification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 10 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 653, DateTimeKind.Utc).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 653, DateTimeKind.Utc).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 653, DateTimeKind.Utc).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9762));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9764));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 7, 4, 10, 32, 21, 654, DateTimeKind.Utc).AddTicks(9765));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "Price",
                value: 14.99m);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 14.99m, 9.99m });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 16.99m, 12.99m });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 20.99m, 15.99m });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 4, 2, false, 18.99m, 13.99m, true },
                    { 5, 2, false, 21.99m, 16.99m, true },
                    { 6, 2, false, 19.99m, 14.99m, true },
                    { 7, 2, false, 22.99m, 17.99m, true },
                    { 8, 2, false, 15.99m, 10.99m, true },
                    { 9, 2, false, 24.99m, 18.99m, true },
                    { 10, 2, false, 17.99m, 12.99m, true },
                    { 11, 5, false, 14.99m, 9.99m, true },
                    { 11, 6, false, 19.99m, 14.99m, true }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(8165), "The Martian is a science fiction novel by Andy Weir, published in 2011. The story follows astronaut Mark Watney, who is stranded on Mars and must use his ingenuity and spirit to survive.", "", "The Martian" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9049), "The Silent Patient is a psychological thriller novel by Alex Michaelides, published in 2019. It tells the story of a woman who shoots her husband and then stops speaking, and the psychotherapist determined to uncover her motivations.", "", "The Silent Patient" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9052), "Where the Crawdads Sing is a novel by Delia Owens, published in 2018. It is a coming-of-age story that intertwines a murder mystery with the life of a young girl growing up in the marshes of North Carolina.", true, "", "Where the Crawdads Sing" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9054), "Educated is a memoir by Tara Westover, published in 2018. It recounts her experiences growing up in a strict and abusive household in rural Idaho, and her quest for knowledge that ultimately leads her to earn a PhD.", false, "", "Educated" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9056), "The Night Circus is a fantasy novel by Erin Morgenstern, published in 2011. It follows a magical competition between two young illusionists, set against the backdrop of a mysterious circus that appears only at night.", true, "", "The Night Circus" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9057), "The Vanishing Half is a novel by Brit Bennett, published in 2020. It tells the story of twin sisters whose lives diverge when one decides to pass as white, exploring themes of race, identity, and family.", false, "", "The Vanishing Half" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9059), "Dune is a science fiction novel by Frank Herbert, published in 1965. It is set in a distant future amidst a huge interstellar empire, focusing on the conflict over the desert planet Arrakis and its valuable resource, spice.", true, "", "Dune" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9061), "The Book Thief is a historical novel by Markus Zusak, published in 2005. It follows a young girl in Nazi Germany who finds solace by stealing books and sharing them with others, narrated by Death.", "", "The Book Thief" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9062), "Circe is a fantasy novel by Madeline Miller, published in 2018. It is a retelling of the life of Circe, the daughter of Helios, exploring her journey of self-discovery and empowerment.", "", "Circe" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 1, new DateTime(2025, 7, 4, 10, 32, 21, 651, DateTimeKind.Utc).AddTicks(9064), "The Giver of Stars is a historical novel by Jojo Moyes, published in 2019. It tells the story of a group of women who become traveling librarians in 1930s Kentucky, fighting for their right to work and make a difference.", "", "The Giver of Stars" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2115), "Inception is a 2010 science fiction film directed by Christopher Nolan. The story follows a skilled thief who steals secrets from within the subconscious during the dream state.", true, "", "Inception" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "IsSoftDeleted", "Title", "Visible" },
                values: new object[,]
                {
                    { 12, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2119), "Parasite is a 2019 South Korean black comedy thriller film directed by Bong Joon-ho. It tells the story of a poor family who schemes to become employed by a wealthy family.", false, "", false, "Parasite", true },
                    { 13, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2121), "The Shawshank Redemption is a 1994 drama film based on a Stephen King novella. It follows the story of a banker sentenced to life in Shawshank State Penitentiary for the murder of his wife.", true, "", false, "The Shawshank Redemption", true },
                    { 14, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2123), "The Godfather is a 1972 crime film directed by Francis Ford Coppola. It chronicles the powerful Italian-American crime family of Don Vito Corleone.", false, "", false, "The Godfather", true },
                    { 15, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2125), "The Dark Knight is a 2008 superhero film directed by Christopher Nolan. It features Batman as he faces off against the Joker, who seeks to create chaos in Gotham City.", true, "", false, "The Dark Knight", true },
                    { 16, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2128), "Forrest Gump is a 1994 drama film directed by Robert Zemeckis. The story follows a slow-witted but kind-hearted man as he witnesses and unwittingly influences several historical events.", false, "", false, "Forrest Gump", true },
                    { 17, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2129), "Pulp Fiction is a 1994 crime film directed by Quentin Tarantino. The film intertwines multiple narratives of crime in Los Angeles, featuring an ensemble cast.", true, "", false, "Pulp Fiction", true },
                    { 18, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2131), "The Matrix Resurrections is a 2021 science fiction film and the fourth installment in The Matrix franchise. It revisits the world of the Matrix with returning characters and new challenges.", false, "", false, "The Matrix Resurrections", true },
                    { 19, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2133), "Spider-Man: No Way Home is a 2021 superhero film directed by Jon Watts. It follows Peter Parker as he seeks help from Doctor Strange to manage the fallout from revealing his identity.", true, "", false, "Spider-Man: No Way Home", true },
                    { 20, 2, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(2134), "Get Out is a 2017 horror film written and directed by Jordan Peele. It follows a young African-American man who uncovers disturbing secrets when he meets his white girlfriend's family.", false, "", false, "Get Out", true },
                    { 21, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4967), "The Legend of Zelda: Breath of the Wild is an action-adventure game developed by Nintendo. Set in a vast open world, players control Link as he awakens from a long slumber to defeat Calamity Ganon.", true, "", false, "The Legend of Zelda: Breath of the Wild", true },
                    { 22, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4971), "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.", false, "", false, "Ghost of Tsushima", true },
                    { 23, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4973), "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.", true, "", false, "Cyberpunk 2077", true },
                    { 24, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4975), "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.", false, "", false, "The Last of Us Part II", true },
                    { 25, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4977), "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.", true, "", false, "Among Us", true },
                    { 26, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4980), "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.", false, "", false, "Hades", true },
                    { 27, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4981), "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.", true, "", false, "Final Fantasy VII Remake", true },
                    { 28, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4983), "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.", false, "", false, "Resident Evil Village", true },
                    { 29, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4984), "Apex Legends is a free-to-play battle royale game developed by Respawn Entertainment. Players choose from a roster of characters, each with unique abilities, and compete to be the last squad standing.", true, "", false, "Apex Legends", true },
                    { 30, 3, new DateTime(2025, 7, 4, 10, 32, 21, 652, DateTimeKind.Utc).AddTicks(4986), "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.", false, "", false, "Minecraft", true }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 12, 6, false, 16.99m, 12.99m, true },
                    { 13, 6, false, 15.99m, 10.99m, true },
                    { 14, 6, false, 19.99m, 14.99m, true },
                    { 15, 6, false, 22.99m, 16.99m, true },
                    { 16, 6, false, 17.99m, 12.99m, true },
                    { 17, 6, false, 18.99m, 13.99m, true },
                    { 18, 6, false, 24.99m, 19.99m, true },
                    { 19, 6, false, 23.99m, 17.99m, true },
                    { 20, 6, false, 15.99m, 11.99m, true },
                    { 21, 8, false, 59.99m, 49.99m, true },
                    { 21, 9, false, 69.99m, 59.99m, true },
                    { 22, 9, false, 69.99m, 59.99m, true },
                    { 23, 9, false, 79.99m, 59.99m, true },
                    { 24, 9, false, 59.99m, 49.99m, true },
                    { 25, 8, false, 9.99m, 4.99m, true },
                    { 26, 9, false, 34.99m, 24.99m, true },
                    { 27, 9, false, 69.99m, 59.99m, true },
                    { 28, 9, false, 59.99m, 49.99m, true },
                    { 29, 8, false, 0m, 0m, true },
                    { 30, 8, false, 29.99m, 26.99m, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 13, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 18, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 19, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 20, 6 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 21, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 22, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 23, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 24, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 25, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 26, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 27, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 28, 9 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 29, 8 });

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 30, 8 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 589, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 589, DateTimeKind.Utc).AddTicks(6142));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 589, DateTimeKind.Utc).AddTicks(6144));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7361));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7549));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2025, 7, 3, 21, 12, 21, 590, DateTimeKind.Utc).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 2 },
                column: "Price",
                value: 9.99m);

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 0m, 7.99m });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 14.99m, 7.99m });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumns: new[] { "ProductId", "ProductTypeId" },
                keyValues: new object[] { 3, 2 },
                columns: new[] { "OriginalPrice", "Price" },
                values: new object[] { 0m, 6.99m });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "IsSoftDeleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 1, 4, false, 29.99m, 19.99m, true },
                    { 4, 5, false, 0m, 3.99m, true },
                    { 4, 6, false, 0m, 9.99m, true },
                    { 4, 7, false, 0m, 19.99m, true },
                    { 5, 5, false, 0m, 3.99m, true },
                    { 6, 5, false, 0m, 2.99m, true },
                    { 7, 8, false, 29.99m, 19.99m, true },
                    { 7, 9, false, 0m, 69.99m, true },
                    { 7, 10, false, 59.99m, 49.99m, true },
                    { 8, 8, false, 24.99m, 9.99m, true },
                    { 9, 8, false, 0m, 14.99m, true },
                    { 10, 1, false, 299m, 159.99m, true },
                    { 11, 1, false, 399m, 79.99m, true }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(8297), "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9293), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9296), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.", false, "https://upload.wikimedia.org/wikipedia/en/5/51/1984_first_edition_cover.jpg", "Nineteen Eighty-Four" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9298), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", true, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9299), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", false, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 2, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9301), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", true, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 3, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9303), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", false, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9305), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9306), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "DateCreated", "Description", "ImageUrl", "Title" },
                values: new object[] { 3, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9308), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "DateCreated", "Description", "Featured", "ImageUrl", "Title" },
                values: new object[] { 3, new DateTime(2025, 7, 3, 21, 12, 21, 588, DateTimeKind.Utc).AddTicks(9310), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", false, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System" });
        }
    }
}
