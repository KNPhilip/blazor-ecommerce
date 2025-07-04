using Domain.Models;

namespace DataAccess.Data;

internal static class MovieSeeder
{
    internal static List<Product> SeedMovieProducts()
    {
        return
        [
            new()
            {
                Id = 11,
                Title = "Inception",
                Description = "Inception is a 2010 science fiction film directed by Christopher Nolan. The story follows a skilled thief who steals secrets from within the subconscious during the dream state.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg",
                CategoryId = 2,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 12,
                Title = "Parasite",
                Description = "Parasite is a 2019 South Korean black comedy thriller film directed by Bong Joon-ho. It tells the story of a poor family who schemes to become employed by a wealthy family.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/53/Parasite_%282019_film%29.png",
                CategoryId = 2,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 13,
                Title = "The Shawshank Redemption",
                Description = "The Shawshank Redemption is a 1994 drama film based on a Stephen King novella. It follows the story of a banker sentenced to life in Shawshank State Penitentiary for the murder of his wife.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/81/ShawshankRedemptionMoviePoster.jpg",
                CategoryId = 2,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 14,
                Title = "The Godfather",
                Description = "The Godfather is a 1972 crime film directed by Francis Ford Coppola. It chronicles the powerful Italian-American crime family of Don Vito Corleone.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/Godfather_ver1.jpg",
                CategoryId = 2,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 15,
                Title = "The Dark Knight",
                Description = "The Dark Knight is a 2008 superhero film directed by Christopher Nolan. It features Batman as he faces off against the Joker, who seeks to create chaos in Gotham City.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg",
                CategoryId = 2,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 16,
                Title = "Forrest Gump",
                Description = "Forrest Gump is a 1994 drama film directed by Robert Zemeckis. The story follows a slow-witted but kind-hearted man as he witnesses and unwittingly influences several historical events.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg",
                CategoryId = 2,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 17,
                Title = "Pulp Fiction",
                Description = "Pulp Fiction is a 1994 crime film directed by Quentin Tarantino. The film intertwines multiple narratives of crime in Los Angeles, featuring an ensemble cast.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg",
                CategoryId = 2,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 18,
                Title = "The Matrix Resurrections",
                Description = "The Matrix Resurrections is a 2021 science fiction film and the fourth installment in The Matrix franchise. It revisits the world of the Matrix with returning characters and new challenges.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                CategoryId = 2,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 19,
                Title = "Spider-Man: No Way Home",
                Description = "Spider-Man: No Way Home is a 2021 superhero film directed by Jon Watts. It follows Peter Parker as he seeks help from Doctor Strange to manage the fallout from revealing his identity.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                CategoryId = 2,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 20,
                Title = "Get Out",
                Description = "Get Out is a 2017 horror film written and directed by Jordan Peele. It follows a young African-American man who uncovers disturbing secrets when he meets his white girlfriend's family.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a3/Get_Out_poster.png",
                CategoryId = 2,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
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
                OriginalPrice = 19.99m,
                Visible = true
            },
            new()
            {
                ProductId = 11,
                ProductTypeId = 5,
                Price = 9.99m,
                OriginalPrice = 14.99m,
                Visible = true
            },
            new()
            {
                ProductId = 12,
                ProductTypeId = 6,
                Price = 12.99m,
                OriginalPrice = 16.99m,
                Visible = true
            },
            new()
            {
                ProductId = 13,
                ProductTypeId = 6,
                Price = 10.99m,
                OriginalPrice = 15.99m,
                Visible = true
            },
            new()
            {
                ProductId = 14,
                ProductTypeId = 6,
                Price = 14.99m,
                OriginalPrice = 19.99m,
                Visible = true
            },
            new()
            {
                ProductId = 15,
                ProductTypeId = 6,
                Price = 16.99m,
                OriginalPrice = 22.99m,
                Visible = true
            },
            new()
            {
                ProductId = 16,
                ProductTypeId = 6,
                Price = 12.99m,
                OriginalPrice = 17.99m,
                Visible = true
            },
            new()
            {
                ProductId = 17,
                ProductTypeId = 6,
                Price = 13.99m,
                OriginalPrice = 18.99m,
                Visible = true
            },
            new()
            {
                ProductId = 18,
                ProductTypeId = 6,
                Price = 19.99m,
                OriginalPrice = 24.99m,
                Visible = true
            },
            new()
            {
                ProductId = 19,
                ProductTypeId = 6,
                Price = 17.99m,
                OriginalPrice = 23.99m,
                Visible = true
            },
            new()
            {
                ProductId = 20,
                ProductTypeId = 6,
                Price = 11.99m,
                OriginalPrice = 15.99m,
                Visible = true
            }
        ];
    }
}
