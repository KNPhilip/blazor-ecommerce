using Domain.Models;

namespace DataAccess.Data;

internal static class BookSeeder
{
    internal static List<Product> SeedBookProducts()
    {
        return
        [
            new()
            {
                Id = 1,
                Title = "The Martian",
                Description = "The Martian is a science fiction novel by Andy Weir, published in 2011. The story follows astronaut Mark Watney, who is stranded on Mars and must use his ingenuity and spirit to survive.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/71/The_Martian_%28Weir_novel%29.jpg",
                CategoryId = 1,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 2,
                Title = "The Silent Patient",
                Description = "The Silent Patient is a psychological thriller novel by Alex Michaelides, published in 2019. It tells the story of a woman who shoots her husband and then stops speaking, and the psychotherapist determined to uncover her motivations.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/df/The_Silent_Patient_early_2019_UK_edition.png",
                CategoryId = 1,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 3,
                Title = "Where the Crawdads Sing",
                Description = "Where the Crawdads Sing is a novel by Delia Owens, published in 2018. It is a coming-of-age story that intertwines a murder mystery with the life of a young girl growing up in the marshes of North Carolina.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1f/Where_The_Crawdads_Sing_Book_Cover.jpg",
                CategoryId = 1,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 4,
                Title = "Educated",
                Description = "Educated is a memoir by Tara Westover, published in 2018. It recounts her experiences growing up in a strict and abusive household in rural Idaho, and her quest for knowledge that ultimately leads her to earn a PhD.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/1f/Educated_%28Tara_Westover%29.png",
                CategoryId = 1,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 5,
                Title = "The Night Circus",
                Description = "The Night Circus is a fantasy novel by Erin Morgenstern, published in 2011. It follows a magical competition between two young illusionists, set against the backdrop of a mysterious circus that appears only at night.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c5/TheNightCircus.jpg",
                CategoryId = 1,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 6,
                Title = "The Vanishing Half",
                Description = "The Vanishing Half is a novel by Brit Bennett, published in 2020. It tells the story of twin sisters whose lives diverge when one decides to pass as white, exploring themes of race, identity, and family.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/ed/The_Vanishing_Half_%28Brit_Bennett%29.png",
                CategoryId = 1,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 7,
                Title = "Dune",
                Description = "Dune is a science fiction novel by Frank Herbert, published in 1965. It is set in a distant future amidst a huge interstellar empire, focusing on the conflict over the desert planet Arrakis and its valuable resource, spice.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/de/Dune-Frank_Herbert_%281965%29_First_edition.jpg",
                CategoryId = 1,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 8,
                Title = "The Book Thief",
                Description = "The Book Thief is a historical novel by Markus Zusak, published in 2005. It follows a young girl in Nazi Germany who finds solace by stealing books and sharing them with others, narrated by Death.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/8/8f/The_Book_Thief_by_Markus_Zusak_book_cover.jpg",
                CategoryId = 1,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 9,
                Title = "Circe",
                Description = "Circe is a fantasy novel by Madeline Miller, published in 2018. It is a retelling of the life of Circe, the daughter of Helios, exploring her journey of self-discovery and empowerment.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9b/Circe_%28novel%29_Madeline_Milller.jpeg",
                CategoryId = 1,
                Featured = true,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            },
            new()
            {
                Id = 10,
                Title = "The Giver of Stars",
                Description = "The Giver of Stars is a historical novel by Jojo Moyes, published in 2019. It tells the story of a group of women who become traveling librarians in 1930s Kentucky, fighting for their right to work and make a difference.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7c/The_Giver_of_Stars.jpg",
                CategoryId = 1,
                Visible = true,
                CreatedDate = new DateTime(2025, 1, 1)
            }
        ];
    }

    internal static List<ProductVariant> SeedBookVariants()
    {
        return
        [
            new()
            {
                ProductId = 1,
                ProductTypeId = 2,
                Price = 14.99m,
                OriginalPrice = 19.99m,
                Visible = true
            },
            new()
            {
                ProductId = 1,
                ProductTypeId = 3,
                Price = 9.99m,
                OriginalPrice = 14.99m,
                Visible = true
            },
            new()
            {
                ProductId = 2,
                ProductTypeId = 2,
                Price = 12.99m,
                OriginalPrice = 16.99m,
                Visible = true
            },
            new()
            {
                ProductId = 3,
                ProductTypeId = 2,
                Price = 15.99m,
                OriginalPrice = 20.99m,
                Visible = true
            },
            new()
            {
                ProductId = 4,
                ProductTypeId = 2,
                Price = 13.99m,
                OriginalPrice = 18.99m,
                Visible = true
            },
            new()
            {
                ProductId = 5,
                ProductTypeId = 2,
                Price = 16.99m,
                OriginalPrice = 21.99m,
                Visible = true
            },
            new()
            {
                ProductId = 6,
                ProductTypeId = 2,
                Price = 14.99m,
                OriginalPrice = 19.99m,
                Visible = true
            },
            new()
            {
                ProductId = 7,
                ProductTypeId = 2,
                Price = 17.99m,
                OriginalPrice = 22.99m,
                Visible = true
            },
            new()
            {
                ProductId = 8,
                ProductTypeId = 2,
                Price = 10.99m,
                OriginalPrice = 15.99m,
                Visible = true
            },
            new()
            {
                ProductId = 9,
                ProductTypeId = 2,
                Price = 18.99m,
                OriginalPrice = 24.99m,
                Visible = true
            },
            new()
            {
                ProductId = 10,
                ProductTypeId = 2,
                Price = 12.99m,
                OriginalPrice = 17.99m,
                Visible = true
            }
        ];
    }
}
