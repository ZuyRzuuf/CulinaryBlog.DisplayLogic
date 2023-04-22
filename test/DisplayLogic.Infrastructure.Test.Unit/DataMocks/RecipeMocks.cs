using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Infrastructure.Test.Unit.DataMocks;

public static class RecipeMocks
{
    public static List<Recipe> TestRecipes = new List<Recipe>()
    {
        new Recipe
        {
            Id = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377"),
            Title = "Spicy Thai Green Curry",
            Ingredients = new List<Ingredient>
            {
                new Ingredient { Id = Guid.NewGuid(), Name = "Green curry paste" },
                new Ingredient { Id = Guid.NewGuid(), Name = "Coconut milk" }
            },
            Instructions = new List<string> { "Heat oil in a large pot...", "Add the curry paste..." },
            Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
            PublishedDate = DateTime.Parse("2023-04-08"),
            ImageUrl = "https://example.com/images/thai-green-curry.jpg",
            Category = new Category { Id = Guid.NewGuid(), Name = "Curry" },
            Cuisine = new Cuisine { Id = Guid.NewGuid(), Name = "Thai" },
            Diet = new Diet { Id = Guid.NewGuid(), Name = "Vegetarian" },
            Method = new Method { Id = Guid.NewGuid(), Name = "Stovetop" },
            Season = new Season { Id = Guid.NewGuid(), Name = "All seasons" },
            Tags = new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Spicy" },
                new Tag { Id = Guid.NewGuid(), Name = "Green Curry" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Delicious recipe! Will make it again.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
                    CreatedAt = DateTime.Parse("2023-04-09")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "I love this dish!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
                    CreatedAt = DateTime.Parse("2023-04-10")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "My family enjoyed it.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
                    CreatedAt = DateTime.Parse("2023-04-11")
                }
            }
        },
        new Recipe
        {
            Id = Guid.Parse("4f9b4d94-3c82-431f-8d99-ea3956324b0b"),
            Title = "Tasty Thai Red Curry",
            Ingredients = new List<Ingredient>
            {
                new Ingredient { Id = Guid.NewGuid(), Name = "Red curry paste" },
                new Ingredient { Id = Guid.NewGuid(), Name = "Coconut milk" }
            },
            Instructions = new List<string> { "Heat oil in a pan...", "Add the curry paste..." },
            Author = new Author { Id = Guid.NewGuid(), Username = "jane_doe" },
            PublishedDate = DateTime.Parse("2023-04-12"),
            ImageUrl = "https://example.com/images/thai-red-curry.jpg",
            Category = new Category { Id = Guid.NewGuid(), Name = "Curry" },
            Cuisine = new Cuisine { Id = Guid.NewGuid(), Name = "Thai" },
            Diet = new Diet { Id = Guid.NewGuid(), Name = "Vegan" },
            Method = new Method { Id = Guid.NewGuid(), Name = "Stovetop" },
            Season = new Season { Id = Guid.NewGuid(), Name = "All Seasons" },
            Tags = new List<Tag>
            {
                new Tag { Id = Guid.NewGuid(), Name = "Spicy" },
                new Tag { Id = Guid.NewGuid(), Name = "Red Curry" }
            },
            Comments = new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "So flavorful and delicious!",
                    Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
                    CreatedAt = DateTime.Parse("2023-04-13")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "This recipe is a keeper.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
                    CreatedAt = DateTime.Parse("2023-04-14")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = "Can't wait to make this again.",
                    Author = new Author { Id = Guid.NewGuid(), Username = "john_doe" },
                    CreatedAt = DateTime.Parse("2023-04-15")
                }
            }
        }
    };
}
