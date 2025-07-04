using Domain.Models;

namespace DataAccess.Data;

internal static class VideoGameSeeder
{
    internal static List<Product> SeedVideoGameProducts()
    {
        return
        [
            new()
            {
                Id = 21,
                Title = "The Legend of Zelda: Breath of the Wild",
                Description = "The Legend of Zelda: Breath of the Wild is an action-adventure game developed by Nintendo. Set in a vast open world, players control Link as he awakens from a long slumber to defeat Calamity Ganon.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = true,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 22,
                Title = "Ghost of Tsushima",
                Description = "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = false,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 23,
                Title = "Cyberpunk 2077",
                Description = "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = true,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 24,
                Title = "The Last of Us Part II",
                Description = "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = false,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 25,
                Title = "Among Us",
                Description = "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = true,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 26,
                Title = "Hades",
                Description = "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = false,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 27,
                Title = "Final Fantasy VII Remake",
                Description = "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = true,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 28,
                Title = "Resident Evil Village",
                Description = "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = false,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 29,
                Title = "Apex Legends",
                Description = "Apex Legends is a free-to-play battle royale game developed by Respawn Entertainment. Players choose from a roster of characters, each with unique abilities, and compete to be the last squad standing.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = true,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 30,
                Title = "Minecraft",
                Description = "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.",
                ImageUrl = string.Empty,
                CategoryId = 3,
                Featured = false,
                Visible = true,
                IsSoftDeleted = false
            }
        ];
    }

    internal static List<ProductVariant> SeedVideoGameVariants()
    {
        return
        [
            new()
            {
                ProductId = 21,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 21,
                ProductTypeId = 8,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 22,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 23,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 79.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 24,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 25,
                ProductTypeId = 8,
                Price = 4.99m,
                OriginalPrice = 9.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 26,
                ProductTypeId = 9,
                Price = 24.99m,
                OriginalPrice = 34.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 27,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 28,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 29,
                ProductTypeId = 8,
                Price = 0m,
                OriginalPrice = 0m,
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                ProductId = 30,
                ProductTypeId = 8,
                Price = 26.99m,
                OriginalPrice = 29.99m,
                Visible = true,
                IsSoftDeleted = false
            }
        ];
    }
}
