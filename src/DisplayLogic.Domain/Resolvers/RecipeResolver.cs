using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Resolvers;

/// <inheritdoc />
public class RecipeResolver : IRecipeResolver
{
    private readonly List<Recipe> _recipes;
    private readonly IDataProviderClient _dataProviderClient;
    private readonly IRecipeService _recipeService;
    private readonly ILogger<RecipeResolver> _logger;

    public RecipeResolver(
        IDataProviderClient dataProviderClient, 
        IRecipeService recipeService,
        ILogger<RecipeResolver> logger)
    {
        _dataProviderClient = dataProviderClient;
        _recipeService = recipeService;
        _logger = logger;

        var sampleAuthor = new Author
            { Id = Guid.Parse("8c6a9b4c-f504-4912-b25a-c8deee55bf57"), Username = "john_doe" };
        var secondAuthor = new Author
            { Id = Guid.Parse("c17fd06b-7ef5-4b2a-95b0-2dd692585eb3"), Username = "jane_doe" };

        _recipes = new List<Recipe>
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
                Author = sampleAuthor,
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
                Author = secondAuthor,
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
                }
            }
        };
    }

    /// <inheritdoc />
    public async Task<List<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic:RecipeResolver] Getting recipes from RecipeService");
        
        var recipes = await _recipeService.GetAllRecipesAsync(cancellationToken);
        
        _logger.LogInformation("[DisplayLogic:RecipeResolver] Recipes: {@Recipes}", recipes);
        
        cancellationToken.ThrowIfCancellationRequested();

        return recipes;
    }

    /// <inheritdoc />
    public async Task<Recipe?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic:RecipeResolver] Getting recipe by id {Id}", id);
        
        var recipe = await _recipeService.GetRecipeByIdAsync(id, cancellationToken);
        
        _logger.LogInformation("[DisplayLogic:RecipeResolver] Recipe: {@Recipe}", recipe);
        
        return recipe;
    }
}