using Domain.Enums;
using Domain.Models;

namespace DataAccess.Data;

internal static class MovieSeeder
{
    internal static List<Product> SeedMovieProducts()
    {
        List<Product> movies =
        [
            new()
            {
                Id = 11,
                Title = "Inception",
                Description = "Inception is a 2010 science fiction film directed by Christopher Nolan. The story follows a skilled thief who steals secrets from within the subconscious during the dream state.",
                CategoryId = 2,
                Featured = true,
                PublishedDate = new DateTime(2010, 7, 16)
            },
            new()
            {
                Id = 12,
                Title = "Parasite",
                Description = "Parasite is a 2019 South Korean black comedy thriller film directed by Bong Joon-ho. It tells the story of a poor family who schemes to become employed by a wealthy family.",
                CategoryId = 2,
                PublishedDate = new DateTime(2019, 12, 2)
            },
            new()
            {
                Id = 13,
                Title = "The Shawshank Redemption",
                Description = "The Shawshank Redemption is a 1994 drama film based on a Stephen King novella. It follows the story of a banker sentenced to life in Shawshank State Penitentiary for the murder of his wife.",
                CategoryId = 2,
                PublishedDate = new DateTime(1994, 9, 23)
            },
            new()
            {
                Id = 14,
                Title = "The Godfather",
                Description = "The Godfather is a 1972 crime film directed by Francis Ford Coppola. It chronicles the powerful Italian-American crime family of Don Vito Corleone.",
                CategoryId = 2,
                PublishedDate = new DateTime(1972, 12, 26)
            },
            new()
            {
                Id = 15,
                Title = "The Dark Knight",
                Description = "The Dark Knight is a 2008 superhero film directed by Christopher Nolan. It features Batman as he faces off against the Joker, who seeks to create chaos in Gotham City.",
                CategoryId = 2,
                PublishedDate = new DateTime(2008, 7, 22)
            },
            new()
            {
                Id = 16,
                Title = "Forrest Gump",
                Description = "Forrest Gump is a 1994 drama film directed by Robert Zemeckis. The story follows a slow-witted but kind-hearted man as he witnesses and unwittingly influences several historical events.",
                CategoryId = 2,
                PublishedDate = new DateTime(1994, 7, 6)
            },
            new()
            {
                Id = 17,
                Title = "The Matrix",
                Description = "The Matrix is a 1999 science fiction action film (and franchise) where humanity is unknowingly trapped in a simulated reality called the Matrix by intelligent machines.",
                CategoryId = 2,
                PublishedDate = new DateTime(1999, 3, 31)
            },
            new()
            {
                Id = 18,
                Title = "The Matrix Reloaded",
                Description = "The Matrix Reloaded follows Neo, Morpheus, and Trinity as they battle the machines for Zion's survival and the fate of humanity.",
                CategoryId = 2,
                PublishedDate = new DateTime(2003, 5, 15)
            },
            new()
            {
                Id = 19,
                Title = "The Matrix Revolutions",
                Description = "The Matrix Revolutions is the third and final film in the original Matrix trilogy, depicting the epic war between humans and machines as Neo must confront the rogue program Agent Smith.",
                CategoryId = 2,
                PublishedDate = new DateTime(2003, 11, 5)
            },
            new()
            {
                Id = 20,
                Title = "The Matrix Resurrections",
                Description = "The Matrix Resurrections is a 2021 science fiction film and the fourth installment in The Matrix franchise. It revisits the world of the Matrix with returning characters and new challenges.",
                CategoryId = 2,
                PublishedDate = new DateTime(2021, 12, 22)
            },
            new()
            {
                Id = 21,
                Title = "Spider-Man: No Way Home",
                Description = "Spider-Man: No Way Home is a 2021 superhero film directed by Jon Watts. It follows Peter Parker as he seeks help from Doctor Strange to manage the fallout from revealing his identity.",
                CategoryId = 2,
                Featured = true,
                PublishedDate = new DateTime(2021, 12, 17)
            }
        ];

        movies.ForEach(p =>
        {
            p.CreatedDate = new DateTime(2025, 1, 1);
        });

        return movies;
    }

    internal static List<Image> SeedMovieImages()
    {
        return
        [
            new()
            {
                Id = 11,
                Data = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg",
                Type = ImageType.Url,
                ProductId = 11
            },
            new()
            {
                Id = 12,
                Data = "https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png",
                Type = ImageType.Url,
                ProductId = 12
            },
            new()
            {
                Id = 13,
                Data = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg",
                Type = ImageType.Url,
                ProductId = 13
            },
            new()
            {
                Id = 14,
                Data = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg",
                Type = ImageType.Url,
                ProductId = 14
            },
            new()
            {
                Id = 15,
                Data = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg",
                Type = ImageType.Url,
                ProductId = 15
            },
            new()
            {
                Id = 16,
                Data = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg",
                Type = ImageType.Url,
                ProductId = 16
            },
            new()
            {
                Id = 17,
                Data = "https://upload.wikimedia.org/wikipedia/en/d/db/The_Matrix.png",
                Type = ImageType.Url,
                ProductId = 17
            },
            new()
            {
                Id = 18,
                Data = "https://upload.wikimedia.org/wikipedia/en/b/ba/Poster_-_The_Matrix_Reloaded.jpg",
                Type = ImageType.Url,
                ProductId = 18
            },
            new()
            {
                Id = 19,
                Data = "https://upload.wikimedia.org/wikipedia/en/7/7b/The-matrix-revolutions_oxlati6t.png",
                Type = ImageType.Url,
                ProductId = 19
            },
            new()
            {
                Id = 20,
                Data = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                Type = ImageType.Url,
                ProductId = 20
            },
            new()
            {
                Id = 21,
                Data = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                Type = ImageType.Url,
                ProductId = 21
            }
        ];
    }

    internal static List<ProductVariant> SeedMovieVariants()
    {
        return
        [
            new()
            {
                ProductId = 11,
                ProductTypeId = 6,
                Price = 14.99m,
                OriginalPrice = 19.99m
            },
            new()
            {
                ProductId = 11,
                ProductTypeId = 5,
                Price = 9.99m,
                OriginalPrice = 14.99m
            },
            new()
            {
                ProductId = 12,
                ProductTypeId = 6,
                Price = 12.99m,
                OriginalPrice = 16.99m
            },
            new()
            {
                ProductId = 13,
                ProductTypeId = 6,
                Price = 10.99m,
                OriginalPrice = 15.99m
            },
            new()
            {
                ProductId = 14,
                ProductTypeId = 6,
                Price = 14.99m,
                OriginalPrice = 19.99m
            },
            new()
            {
                ProductId = 15,
                ProductTypeId = 6,
                Price = 16.99m,
                OriginalPrice = 22.99m
            },
            new()
            {
                ProductId = 16,
                ProductTypeId = 6,
                Price = 12.99m,
                OriginalPrice = 17.99m
            },
            new()
            {
                ProductId = 17,
                ProductTypeId = 6,
                Price = 13.99m,
                OriginalPrice = 18.99m
            },
            new()
            {
                ProductId = 18,
                ProductTypeId = 6,
                Price = 19.99m,
                OriginalPrice = 24.99m
            },
            new()
            {
                ProductId = 19,
                ProductTypeId = 6,
                Price = 17.99m,
                OriginalPrice = 23.99m
            },
            new()
            {
                ProductId = 20,
                ProductTypeId = 6,
                Price = 11.99m,
                OriginalPrice = 15.99m
            },
            new()
            {
                ProductId = 21,
                ProductTypeId = 6,
                Price = 14.99m
            }
        ];
    }
}
