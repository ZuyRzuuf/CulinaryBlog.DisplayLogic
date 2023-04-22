using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Infrastructure.Resolvers;

/// <inheritdoc />
public class RecipeService : IRecipeService
{
    private readonly List<Recipe> _recipes;

    public RecipeService()
    {
        var sampleAuthor = new Author { Id = Guid.Parse("8c6a9b4c-f504-4912-b25a-c8deee55bf57"), Username = "john_doe" };
        var secondAuthor = new Author { Id = Guid.Parse("c17fd06b-7ef5-4b2a-95b0-2dd692585eb3"), Username = "jane_doe" };

        _recipes = new List<Recipe>
        {
            new Recipe
            {
                Id = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377"),
                Title = "Spicy Thai Green Curry",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Id = 1, Name = "Green curry paste" },
                    new Ingredient { Id = 2, Name = "Coconut milk" }
                },
                Instructions = new List<string> { "Heat oil in a large pot...", "Add the curry paste..." },
                Author = sampleAuthor,
                PublishedDate = DateTime.Parse("2023-04-08"),
                ImageUrl = "https://example.com/images/thai-green-curry.jpg",
                Category = new Category { Id = Guid.NewGuid(), Name = "Curry" },
                Cuisine = new Cuisine { Id = 1, Name = "Thai" },
                Diet = new Diet { Id = 1, Name = "Vegetarian" },
                Method = new Method { Id = 1, Name = "Stovetop" },
                Season = new Season { Id = 1, Name = "All seasons" },
                Tags = new List<Tag>
                {
                    new Tag { Id = 3, Name = "Spicy" },
                    new Tag { Id = 4, Name = "Green Curry" }
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "Delicious recipe! Will make it again.",
                        Author = secondAuthor,
                        CreatedAt = DateTime.Parse("2023-04-09")
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "I love this dish!",
                        Author = secondAuthor,
                        CreatedAt = DateTime.Parse("2023-04-10")
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "My family enjoyed it.",
                        Author = secondAuthor,
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
                    new Ingredient { Id = 3, Name = "Red curry paste" },
                    new Ingredient { Id = 4, Name = "Coconut milk" }
                },
                Instructions = new List<string> { "Heat oil in a pan...", "Add the curry paste..." },
                Author = secondAuthor,
                PublishedDate = DateTime.Parse("2023-04-12"),
                ImageUrl = "https://example.com/images/thai-red-curry.jpg",
                Category = new Category { Id = Guid.NewGuid(), Name = "Curry" },
                Cuisine = new Cuisine { Id = 1, Name = "Thai" },
                Diet = new Diet { Id = 2, Name = "Vegan" },
                Method = new Method { Id = 1, Name = "Stovetop" },
                Season = new Season { Id = 1, Name = "All Seasons" },
                Tags = new List<Tag>
                {
                    new Tag { Id = 5, Name = "Spicy" },
                    new Tag { Id = 6, Name = "Red Curry" }
                },
                Comments = new List<Comment>
                {
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "So flavorful and delicious!",
                        Author = sampleAuthor,
                        CreatedAt = DateTime.Parse("2023-04-13")
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "This recipe is a keeper.",
                        Author = sampleAuthor,
                        CreatedAt = DateTime.Parse("2023-04-14")
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        Content = "Can't wait to make this again.",
                        Author = sampleAuthor,
                        CreatedAt = DateTime.Parse("2023-04-15")
                    }
                }
            }
        };
    }

    /// <inheritdoc />
    public List<Recipe> GetAllRecipes()
    {
        return _recipes;
    }

    /// <inheritdoc />
    public Recipe? GetRecipeById(Guid uuid)
    {
        return _recipes.FirstOrDefault(recipe => recipe.Id == uuid);
    }
}