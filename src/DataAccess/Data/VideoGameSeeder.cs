using Domain.Enums;
using Domain.Models;

namespace DataAccess.Data;

internal static class VideoGameSeeder
{
    internal static List<Product> SeedVideoGameProducts()
    {
        List<Product> videoGames =
        [
            new()
            {
                Id = 22,
                Title = "The Legend of Zelda: Breath of the Wild",
                Description = "The Legend of Zelda: Breath of the Wild is an action-adventure game developed by Nintendo. Set in a vast open world, players control Link as he awakens from a long slumber to defeat Calamity Ganon.",
                CategoryId = 3,
                PublishedDate = new DateTime(2017, 3, 3)
            },
            new()
            {
                Id = 23,
                Title = "Ghost of Tsushima",
                Description = "Ghost of Tsushima is an action-adventure game developed by Sucker Punch Productions. Set in feudal Japan, players control samurai Jin Sakai as he battles against the Mongol invasion.",
                CategoryId = 3,
                PublishedDate = new DateTime(2020, 7, 17)
            },
            new()
            {
                Id = 24,
                Title = "Cyberpunk 2077",
                Description = "Cyberpunk 2077 is an open-world role-playing game developed by CD Projekt. Set in a dystopian future, players assume the role of V, a customizable mercenary navigating the streets of Night City.",
                CategoryId = 3,
                Featured = true,
                PublishedDate = new DateTime(2020, 12, 10)
            },
            new()
            {
                Id = 25,
                Title = "The Last of Us",
                Description = "The Last of Us is an action-adventure video game series and media franchise created by Naughty Dog and published by Sony Interactive Entertainment.",
                CategoryId = 3,
                PublishedDate = new DateTime(2013, 6, 14)
            },
            new()
            {
                Id = 26,
                Title = "The Last of Us Part II",
                Description = "The Last of Us Part II is an action-adventure game developed by Naughty Dog. It follows Ellie on her quest for revenge in a post-apocalyptic world filled with danger and moral dilemmas.",
                CategoryId = 3,
                Featured = true,
                PublishedDate = new DateTime(2020, 6, 19)
            },
            new()
            {
                Id = 27,
                Title = "Among Us",
                Description = "Among Us is a multiplayer social deduction game developed by InnerSloth. Players work together on a spaceship, but some are impostors trying to sabotage the crew.",
                CategoryId = 3,
                PublishedDate = new DateTime(2018, 6, 15)
            },
            new()
            {
                Id = 28,
                Title = "Hades",
                Description = "Hades is a roguelike dungeon crawler developed by Supergiant Games. Players control Zagreus, the son of Hades, as he attempts to escape the Underworld.",
                CategoryId = 3,
                PublishedDate = new DateTime(2020, 9, 17)
            },
            new()
            {
                Id = 29,
                Title = "Final Fantasy VII Remake",
                Description = "Final Fantasy VII Remake is an action role-playing game developed by Square Enix. It is a reimagining of the classic 1997 game, focusing on the early chapters of Cloud Strife's journey.",
                CategoryId = 3,
                PublishedDate = new DateTime(2020, 4, 10)
            },
            new()
            {
                Id = 30,
                Title = "Resident Evil Village",
                Description = "Resident Evil Village is a survival horror game developed by Capcom. It follows Ethan Winters as he searches for his kidnapped daughter in a mysterious village filled with horrors.",
                CategoryId = 3,
                PublishedDate = new DateTime(2021, 5, 7)
            },
            new()
            {
                Id = 31,
                Title = "Red Dead Redemption 2",
                Description = "America, 1899. The end of the Wild West era has begun. After a robbery goes badly wrong in the western town of Blackwater, Arthur Morgan and the Van der Linde gang are forced to flee. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2018, 10, 26)
            },
            new()
            {
                Id = 32,
                Title = "Minecraft",
                Description = "Minecraft is a sandbox game developed by Mojang Studios. Players can build and explore their own worlds, crafting items and surviving against monsters.",
                CategoryId = 3,
                PublishedDate = new DateTime(2009, 5, 17)
            },
            new()
            {
                Id = 33,
                Title = "Red Dead Revolver",
                Description = "Vast, rugged, and lawless. As a young man, you were helpless to prevent the slaughter of your family at the hands of bandits. Many years later, you live as a bounty hunter bringing criminals to justice, while struggling to unravel the mystery of your past. You must find those who murdered your family. Then, you will take your revenge. A blazing arcade-style third-person game fueled by precision gunplay, Red Dead Revolver is a classic tale of vengeance on the untamed frontier.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2004, 5, 4)
            },
            new()
            {
                Id = 34,
                Title = "Red Dead Online",
                Description = "Step into the vibrant, ever-evolving world of Red Dead Online and experience life across frontier America. Forge your own path as you battle lawmen, outlaw gangs and ferocious wild animals to build a life on the American frontier. Build a camp, ride solo or form a posse and explore everything from the snowy mountains in the North to the swamps of the South, from remote outposts to busy farms and bustling towns. Chase down bounties, hunt, fish and trade, search for exotic treasures, run your own underground Moonshine distillery, or become a Naturalist to learn the secrets of the animal kingdom and much more in a world of astounding depth and detail.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2018, 11, 27)
            },
            new()
            {
                Id = 35,
                Title = "Red Dead Redemption",
                Description = "Journey across the sprawling expanses of the American West and Mexico in Red Dead Redemption. When federal agents threaten his family, former outlaw John Marston is forced to hunt down the gang of criminals he once called friends. Step into the events immediately following the 2018 blockbuster, Red Dead Redemption 2, in the critically acclaimed tale of Marston’s journey to bury his blood-stained past, one man at a time.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2010, 5, 18)
            },
            new()
            {
                Id = 36,
                Title = "Red Dead Redemption: Undead Nightmare",
                Description = "When former outlaw John Marston wakes up at his farmhouse, he finds a world gone insane: overnight, deranged hordes have overrun the towns and outposts of the American frontier. In a desperate attempt to save his family, Marston must traverse a world torn apart by chaos and disorder, using every skill he has to survive long enough to find a cure.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2010, 10, 26)
            },
            new()
            {
                Id = 37,
                Title = "Red Dead Redemption 2: Ultimate Edition",
                Description = "As Arthur Morgan, loyal right hand to charismatic gang leader, Dutch Van Der Linde, you’ll live, hunt, party, steal and fight alongside a diverse cast of outlaws you’ll come to know as family, including Bill Williamson, Javier Escuella, Sadie Adler, Micah Bell, John Marston, Charles Smith, Susan Grimshaw and many more. The Van Der Linde gang is a group of fully realized characters and living and fighting alongside this gang is an experience unlike any other.",
                CategoryId = 3,
                Featured = false,
                PublishedDate = new DateTime(2018, 10, 26)
            }
        ];

        videoGames.ForEach(p =>
        {
            p.CreatedDate = new DateTime(2025, 1, 1);
        });

        return videoGames;
    }

    internal static List<Image> SeedVideoGameImages()
    {
        return
        [
            new()
            {
                Id = 22,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
                Type = ImageType.Url,
                ProductId = 22
            },
            new()
            {
                Id = 23,
                Data = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                Type = ImageType.Url,
                ProductId = 23
            },
            new()
            {
                Id = 24,
                Data = "https://upload.wikimedia.org/wikipedia/en/9/9f/Cyberpunk_2077_box_art.jpg",
                Type = ImageType.Url,
                ProductId = 24
            },
            new()
            {
                Id = 25,
                Data = "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg",
                Type = ImageType.Url,
                ProductId = 25
            },
            new()
            {
                Id = 26,
                Data = "https://upload.wikimedia.org/wikipedia/en/4/4f/TLOU_P2_Box_Art_2.png",
                Type = ImageType.Url,
                ProductId = 26
            },
            new()
            {
                Id = 27,
                Data = "https://upload.wikimedia.org/wikipedia/en/9/9a/Among_Us_cover_art.jpg",
                Type = ImageType.Url,
                ProductId = 27
            },
            new()
            {
                Id = 28,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg",
                Type = ImageType.Url,
                ProductId = 28
            },
            new()
            {
                Id = 29,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/ce/FFVIIRemake.png",
                Type = ImageType.Url,
                ProductId = 29
            },
            new()
            {
                Id = 30,
                Data = "https://upload.wikimedia.org/wikipedia/en/2/2c/Resident_Evil_Village.png",
                Type = ImageType.Url,
                ProductId = 30
            },
            new()
            {
                Id = 31,
                Data = "https://upload.wikimedia.org/wikipedia/en/4/44/Red_Dead_Redemption_II.jpg",
                Type = ImageType.Url,
                ProductId = 31
            },
            new()
            {
                Id = 32,
                Data = "https://upload.wikimedia.org/wikipedia/en/b/b6/Minecraft_2024_cover_art.png",
                Type = ImageType.Url,
                ProductId = 32
            },
            new()
            {
                Id = 33,
                Data = "https://upload.wikimedia.org/wikipedia/en/c/c1/Red_Dead_Revolver_Coverart.jpg",
                Type = ImageType.Url,
                ProductId = 33
            },
            new()
            {
                Id = 34,
                Data = "https://static.wikia.nocookie.net/reddeadredemption/images/9/9d/RedDeadOnline-EpicGamesStore-CoverArt.jpg/revision/latest?cb=20201201170402",
                Type = ImageType.Url,
                ProductId = 34
            },
            new()
            {
                Id = 35,
                Data = "https://upload.wikimedia.org/wikipedia/en/a/a7/Red_Dead_Redemption.jpg",
                Type = ImageType.Url,
                ProductId = 35
            },
            new()
            {
                Id = 36,
                Data = "https://upload.wikimedia.org/wikipedia/en/5/59/Red_Dead_Redemption_-_Undead_Nightmare_cover.JPG",
                Type = ImageType.Url,
                ProductId = 36
            },
            new()
            {
                Id = 37,
                Data = "https://image.api.playstation.com/cdn/UP1004/CUSA03041_00/3zDubiWo2X5WU18FGiwlsf4lKWb8MwkE.png?w=620&thumb=false",
                Type = ImageType.Url,
                ProductId = 37
            }
        ];
    }

    internal static List<ProductVariant> SeedVideoGameVariants()
    {
        return
        [
            new()
            {
                ProductId = 22,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m
            },
            new()
            {
                ProductId = 22,
                ProductTypeId = 8,
                Price = 49.99m,
                OriginalPrice = 59.99m
            },
            new()
            {
                ProductId = 23,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m
            },
            new()
            {
                ProductId = 24,
                ProductTypeId = 8,
                Price = 59.99m,
                OriginalPrice = 79.99m
            },
            new()
            {
                ProductId = 24,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m
            },
            new()
            {
                ProductId = 25,
                ProductTypeId = 8,
                Price = 4.99m,
                OriginalPrice = 9.99m
            },
            new()
            {
                ProductId = 26,
                ProductTypeId = 9,
                Price = 24.99m,
                OriginalPrice = 34.99m
            },
            new()
            {
                ProductId = 27,
                ProductTypeId = 9,
                Price = 59.99m,
                OriginalPrice = 69.99m
            },
            new()
            {
                ProductId = 28,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 59.99m
            },
            new()
            {
                ProductId = 29,
                ProductTypeId = 8,
                Price = 59.99m,
                OriginalPrice = 0m
            },
            new()
            {
                ProductId = 29,
                ProductTypeId = 9,
                Price = 49.99m,
                OriginalPrice = 54.99m
            },
            new()
            {
                ProductId = 30,
                ProductTypeId = 8,
                Price = 26.99m,
                OriginalPrice = 29.99m
            },
            new()
            {
                ProductId = 32,
                ProductTypeId = 8,
                Price = 24.99m,
                OriginalPrice = 29.99m
            },
            new()
            {
                ProductId = 32,
                ProductTypeId = 9,
                Price = 14.99m,
                OriginalPrice = 19.99m
            },
            new()
            {
                ProductId = 33,
                ProductTypeId = 9,
                Price = 6.99m,
                OriginalPrice = 11.49m
            },
            new()
            {
                ProductId = 33,
                ProductTypeId = 10,
                Price = 6.99m,
                OriginalPrice = 11.49m
            },
            new()
            {
                ProductId = 35,
                ProductTypeId = 8,
                Price = 72.49m
            },
            new()
            {
                ProductId = 35,
                ProductTypeId = 9,
                Price = 66.49m
            },
            new()
            {
                ProductId = 35,
                ProductTypeId = 10,
                Price = 33.99m
            },
            new()
            {
                ProductId = 35,
                ProductTypeId = 11,
                Price = 49.99m
            },
            new()
            {
                ProductId = 36,
                ProductTypeId = 8,
                Price = 72.49m
            },
            new()
            {
                ProductId = 36,
                ProductTypeId = 9,
                Price = 66.49m
            },
            new()
            {
                ProductId = 36,
                ProductTypeId = 10,
                Price = 33.99m
            },
            new()
            {
                ProductId = 36,
                ProductTypeId = 11,
                Price = 49.99m
            },
            new()
            {
                ProductId = 31,
                ProductTypeId = 8,
                Price = 86.99m
            },
            new()
            {
                ProductId = 31,
                ProductTypeId = 9,
                Price = 69.99m
            },
            new()
            {
                ProductId = 31,
                ProductTypeId = 10,
                Price = 69.99m
            },
            new()
            {
                ProductId = 37,
                ProductTypeId = 8,
                Price = 144.99m
            },
            new()
            {
                ProductId = 37,
                ProductTypeId = 9,
                Price = 114.99m
            },
            new()
            {
                ProductId = 37,
                ProductTypeId = 10,
                Price = 114.99m
            },
            new()
            {
                ProductId = 34,
                ProductTypeId = 8,
                Price = 28.99m
            },
            new()
            {
                ProductId = 34,
                ProductTypeId = 9,
                Price = 23.49m
            },
            new()
            {
                ProductId = 34,
                ProductTypeId = 10,
                Price = 23.49m
            }
        ];
    }
}
