using Domain.Enums;
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
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 22,
                Title = "Ghost of Tsushima",
                Description = "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 23,
                Title = "Cyberpunk 2077",
                Description = "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.",
                CategoryId = 3,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 24,
                Title = "The Last of Us Part II",
                Description = "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 25,
                Title = "Among Us",
                Description = "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 26,
                Title = "Hades",
                Description = "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 27,
                Title = "Final Fantasy VII Remake",
                Description = "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 28,
                Title = "Resident Evil Village",
                Description = "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 29,
                Title = "Red Dead Redemption 2",
                Description = "Red Dead Redemption 2 is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in a fictionalized representation of the United States in 1899 and follows the exploits of Arthur Morgan, an outlaw and member of the Van der Linde gang, who must deal with the decline of the Wild West while attempting to survive against government forces, rival gangs, and other adversaries.",
                CategoryId = 3,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 30,
                Title = "Minecraft",
                Description = "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.",
                CategoryId = 3,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            }
        ];
    }

    internal static List<Image> SeedVideoGameImages()
    {
        return
        [
            new()
            {
                Id = 21,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
                Type = ImageType.Url,
                ProductId = 21
            },
            new()
            {
                Id = 22,
                Data = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                Type = ImageType.Url,
                ProductId = 22
            },
            new()
            {
                Id = 23,
                Data = "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg",
                Type = ImageType.Url,
                ProductId = 23
            },
            new()
            {
                Id = 24,
                Data = "https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU_P2_Box_Art_2.png",
                Type = ImageType.Url,
                ProductId = 24
            },
            new()
            {
                Id = 25,
                Data = "https://upload.wikimedia.org/wikipedia/en/9/9a/Among_Us_cover_art.jpg",
                Type = ImageType.Url,
                ProductId = 25
            },
            new()
            {
                Id = 26,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg",
                Type = ImageType.Url,
                ProductId = 26
            },
            new()
            {
                Id = 27,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/ce/FFVIIRemake.png",
                Type = ImageType.Url,
                ProductId = 27
            },
            new()
            {
                Id = 28,
                Data = "https://upload.wikimedia.org/wikipedia/en/2/2c/Resident_Evil_Village.png",
                Type = ImageType.Url,
                ProductId = 28
            },
            new()
            {
                Id = 29,
                Data = "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg",
                Type = ImageType.Url,
                ProductId = 29
            },
            new()
            {
                Id = 30,
                Data = "https://upload.wikimedia.org/wikipedia/en/b/b6/Minecraft_2024_cover_art.png",
                Type = ImageType.Url,
                ProductId = 30
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
                Visible = true
            },
            new()
            {
                ProductId = 21,
                ProductTypeId = 8,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true
            },
            new()
            {
                ProductId = 22,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m,
                Visible = true
            },
            new()
            {
                ProductId = 23,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 79.99m,
                Visible = true
            },
            new()
            {
                ProductId = 24,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true
            },
            new()
            {
                ProductId = 25,
                ProductTypeId = 8,
                Price = 4.99m,
                OriginalPrice = 9.99m,
                Visible = true
            },
            new()
            {
                ProductId = 26,
                ProductTypeId = 9,
                Price = 24.99m,
                OriginalPrice = 34.99m,
                Visible = true
            },
            new()
            {
                ProductId = 27,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m,
                Visible = true
            },
            new()
            {
                ProductId = 28,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m,
                Visible = true
            },
            new()
            {
                ProductId = 29,
                ProductTypeId = 8,
                Price = 59.99m,
                OriginalPrice = 0m,
                Visible = true
            },
            new()
            {
                ProductId = 30,
                ProductTypeId = 8,
                Price = 26.99m,
                OriginalPrice = 29.99m,
                Visible = true
            }
        ];
    }
}
