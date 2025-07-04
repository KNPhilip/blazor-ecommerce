using Domain.Models;

namespace DataAccess.Data;

internal static class DataSeeder
{
    internal static List<Product> SeedProducts()
    {
        return new List<List<Product>>
        {
            BookSeeder.SeedBookProducts(),
            MovieSeeder.SeedMovieProducts(),
            VideoGameSeeder.SeedVideoGameProducts()
        }.SelectMany(x => x).ToList();
    }

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
                IsSoftDeleted = false
            },
            new()
            {
                Id = 2,
                Name = "Movies",
                Url = "movies",
                Visible = true,
                IsSoftDeleted = false
            },
            new()
            {
                Id = 3,
                Name = "Video Games",
                Url = "video-games",
                Visible = true,
                IsSoftDeleted = false
            }
        ];
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

    internal static List<ProductType> SeedProductTypes()
    {
        return 
        [
            new()
            {
                Id = 1,
                Name = "Default",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 2,
                Name = "Paperback",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 3,
                Name = "E-Book",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 4,
                Name = "Audiobook",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 5,
                Name = "Stream",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 6,
                Name = "Blu-ray",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 7,
                Name = "VHS",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 8,
                Name = "PC",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 9,
                Name = "PlayStation",
                IsSoftDeleted = false
            },
            new()
            {
                Id = 10,
                Name = "Xbox",
                IsSoftDeleted = false
            }
        ];
    }
}
