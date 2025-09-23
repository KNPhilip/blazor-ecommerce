using Domain.Models;

namespace DataAccess.Data;

internal static class DataSeeder
{
    internal static List<Category> SeedCategories()
    {
        return 
        [
            new()
            {
                Id = 1,
                Name = "Books",
                Url = "books",
                Visible = true,
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 2,
                Name = "Movies",
                Url = "movies",
                Visible = true,
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 3,
                Name = "Video Games",
                Url = "video-games",
                Visible = true,
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            }
        ];
    }

    internal static List<ProductType> SeedProductTypes()
    {
        return 
        [
            new()
            {
                Id = 1,
                Name = "Default",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 2,
                Name = "Paperback",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 3,
                Name = "E-Book",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 4,
                Name = "Audiobook",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 5,
                Name = "Stream",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 6,
                Name = "Blu-ray",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 7,
                Name = "VHS",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 8,
                Name = "PC",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 9,
                Name = "PlayStation",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 10,
                Name = "Xbox",
                IsSoftDeleted = false,
                CreatedDate = new DateTime(2025, 1, 1)
            }
        ];
    }

    internal static List<Product> SeedProducts()
    {
        return new List<List<Product>>
        {
            BookSeeder.SeedBookProducts(),
            MovieSeeder.SeedMovieProducts(),
            VideoGameSeeder.SeedVideoGameProducts()
        }.SelectMany(x => x).ToList();
    }

    internal static List<Image> SeedImages()
    {
        return new List<List<Image>>
        {
            BookSeeder.SeedBookImages(),
            MovieSeeder.SeedMovieImages(),
            VideoGameSeeder.SeedVideoGameImages()
        }.SelectMany(x => x).ToList();
    }

    internal static List<ProductVariant> SeedProductVariants()
    {
        return new List<List<ProductVariant>>
        {
            BookSeeder.SeedBookVariants(),
            MovieSeeder.SeedMovieVariants(),
            VideoGameSeeder.SeedVideoGameVariants()
        }.SelectMany(x => x).ToList();
    }

    internal static List<DbUser> SeedPublishers()
    {
        List<DbUser> publishers =
        [
            new()
            {
                Id = "47fac782-04bb-45f0-8700-2b9a3b855984",
                PasswordHash = "$3y$20$bDDaBlqNVSIfhAL7UBFjA2sDVVQABeMd",
                UserName = "andy@weir.fake",
                FirstName = "Andy",
                LastName = "Weir",
                BirthDate = new DateTime(1972, 6, 16)
            },
            new()
            {
                Id = "9904a3cc-92aa-43e4-a743-5bdc46374c6c",
                PasswordHash = "$3y$20$e0NRG7mXG1fXo8e2c4c0EuXHkOa7wY",
                UserName = "alex@michaelides.fake",
                FirstName = "Alex",
                LastName = "Michaelides",
                BirthDate = new DateTime(1977, 9, 4)
            },
            new()
            {
                Id = "d02c893b-5ed4-4e37-bac0-0b62bb50fcdb",
                PasswordHash = "$3y$20$gk1F8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "delia@owens.fake",
                FirstName = "Delia",
                LastName = "Owens",
                BirthDate = new DateTime(1949, 4, 4)
            },
            new()
            {
                Id = "dc7b8125-6391-4774-b1f2-ad92281ed289",
                PasswordHash = "$3y$20$hL2G9JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "tara@westover.fake",
                FirstName = "Tara",
                LastName = "Westover",
                BirthDate = new DateTime(1986, 9, 1)
            },
            new()
            {
                Id = "27045ac4-b1d1-4dbb-a13b-529456b1dad2",
                PasswordHash = "$3y$20$kM3H9JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "erin@morgenstern.fake",
                FirstName = "Erin",
                LastName = "Morgenstern",
                BirthDate = new DateTime(1978, 7, 8)
            },
            new()
            {
                Id = "bafc87aa-2221-4543-ac96-9f1e4aac691d",
                PasswordHash = "$3y$20$uN4J8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "brit@bennett.fake",
                FirstName = "Brit",
                LastName = "Bennett",
                BirthDate = new DateTime(1990, 1, 1)
            },
            new()
            {
                Id = "35be5291-5ce0-4483-9e7d-9d60dc912f98",
                PasswordHash = "$3y$20$vP5K8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "frank@herbert.fake",
                FirstName = "Frank",
                LastName = "Herbert",
                BirthDate = new DateTime(1920, 10, 8)
            },
            new()
            {
                Id = "a989fbed-3273-4342-bf5b-7724721e1504",
                PasswordHash = "$3y$20$zQ6L8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "markus@zusak.fake",
                FirstName = "Markus",
                LastName = "Zusak",
                BirthDate = new DateTime(1975, 6, 23)
            },
            new()
            {
                Id = "8567a393-058f-4ecb-a209-307dc6c8c8fa",
                PasswordHash = "$3y$20$eR7M8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "madeline@miller.fake",
                FirstName = "Madeline",
                LastName = "Miller",
                BirthDate = new DateTime(1978, 6, 24)
            },
            new()
            {
                Id = "87ef6fb3-1a20-472e-b6d3-7599afb506e6",
                PasswordHash = "$3y$20$hT8N8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "jojo@moyes.fake",
                FirstName = "Jojo",
                LastName = "Moyes",
                BirthDate = new DateTime(1969, 8, 4)
            },
            new()
            {
                Id = "3711943c-2d78-4a3f-b007-a6ee15ba0e7b",
                PasswordHash = "$3y$20$mQ0P8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "contact@barunsonena.com",
                NickName = "Barunson E&A and CJ Entertainment",
                BirthDate = new DateTime(1996, 12, 20)
            },
            new()
            {
                Id = "0f39bc69-752a-495f-9e13-07b8d447e98f",
                PasswordHash = "$3y$20$nR1Q8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "info@castle-rock.com",
                NickName = "Castle Rock Entertainment",
                BirthDate = new DateTime(1987, 6, 19)
            },
            new()
            {
                Id = "2bc82d0e-8b77-4a6a-84da-e79b618acbcf",
                PasswordHash = "$3y$20$oS2R8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "studio_operations@paramount.com",
                NickName = "Paramount Pictures",
                BirthDate = new DateTime(1912, 5, 8)
            },
            new()
            {
                Id = "c5534807-f265-41c6-afa8-fcbefabb164b",
                PasswordHash = "$3y$20$pT3S8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "support@wbd.com",
                NickName = "Warner Bros. Pictures",
                BirthDate = new DateTime(1923, 4, 4)
            },
            new()
            {
                Id = "8a57c8e1-08f3-42b5-9671-cbc84976fb01",
                PasswordHash = "$3y$20$kP9O8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "ms-comms@marvelstudios.com",
                NickName = "Marvel Studios",
                BirthDate = new DateTime(1993, 12, 7)
            },
            new()
            {
                Id = "e2e7e873-a404-4c13-bd5e-8c10a046c168",
                PasswordHash = "$3y$20$qU4T8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "contact@nintendo.de",
                NickName = "Nintendo",
                BirthDate = new DateTime(1889, 9, 23)
            },
            new()
            {
                Id = "e29ae0f4-c7d1-4a08-bfbb-b1fcbf2f391d",
                PasswordHash = "$3y$20$rV5U8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "info@sony.fake",
                NickName = "Sony Interactive Entertainment",
                BirthDate = new DateTime(1993, 11, 16)
            },
            new()
            {
                Id = "354f78e9-61bc-4f6e-8761-3cfab3749d42",
                PasswordHash = "$3y$20$sW6V8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "biz@cdprojektred.com",
                NickName = "CD Projekt RED",
                BirthDate = new DateTime(2002, 3, 6)
            },
            new()
            {
                Id = "a73f5524-6667-4a81-a1a0-1b3e3bbc432f",
                PasswordHash = "$3y$20$tX7W8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "us@innersloth.com",
                NickName = "InnerSloth",
                BirthDate = new DateTime(2015, 1, 1)
            },
            new()
            {
                Id = "7260b1d5-3c97-4bd1-8bbd-1b0183bb2393",
                PasswordHash = "$3y$20$uY8X8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "info@supergiantgames.com",
                NickName = "Supergiant Games",
                BirthDate = new DateTime(2009, 1, 1)
            },
            new()
            {
                Id = "448d440b-c1c4-453c-8cda-608fedad3762",
                PasswordHash = "$3y$20$vZ9Y8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "support@square-enix.fake",
                NickName = "Square Enix",
                BirthDate = new DateTime(2003, 4, 1)
            },
            new()
            {
                Id = "d6c9880a-9926-400f-86da-79dc08234f33",
                PasswordHash = "$3y$20$wA0Z8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "info-asia@capcom.com",
                NickName = "Capcom",
                BirthDate = new DateTime(1979, 5, 30)
            },
            new()
            {
                Id = "8b1922c7-8118-474b-aa7b-032bec00234c",
                PasswordHash = "$3y$20$xB1A8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "support@rockstargames.com",
                NickName = "Rockstar Games",
                BirthDate = new DateTime(1998, 12, 1)
            },
            new()
            {
                Id = "7c4df877-bffb-4cbd-8417-097cff415a03",
                PasswordHash = "$3y$20$yC2B8JH6k9mXQ8e2c4c0EuXHkOa7wY",
                UserName = "scoops@minecraft.net",
                NickName = "Mojang Studios",
                BirthDate = new DateTime(2009, 6, 18)
            }
        ];

        publishers.ForEach(p =>
        {
            p.ConcurrencyStamp = p.Id;
            p.SecurityStamp = p.Id;
            p.NormalizedUserName = p.UserName!.ToUpper();
            p.Email = p.UserName;
            p.NormalizedEmail = p.UserName.ToUpper();
            p.EmailConfirmed = true;
            p.DateCreated = new DateTime(2025, 1, 1);
        });

        return publishers;
    }
}
