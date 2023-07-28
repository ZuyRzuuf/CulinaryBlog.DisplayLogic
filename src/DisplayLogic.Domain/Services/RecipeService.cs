using DisplayLogic.Domain.Dtos;
using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Services;

public class RecipeService : IRecipeService
{
    private static readonly List<Recipe> Recipes = new()
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
            Author = new Author { Id = Guid.Parse("8c6a9b4c-f504-4912-b25a-c8deee55bf57"), Username = "john_doe" },
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
            Author = new Author { Id = Guid.Parse("c17fd06b-7ef5-4b2a-95b0-2dd692585eb3"), Username = "jane_doe" },
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
    private readonly IDataProviderClient _dataProviderClient;
    private readonly ILogger<RecipeService> _logger;

    public RecipeService(IDataProviderClient dataProviderClient, ILogger<RecipeService> logger)
    {
        _dataProviderClient = dataProviderClient;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic:RecipeService] Getting recipes from DataProvider");
        
        var recipesDto = await _dataProviderClient.GetRecipesAsync(cancellationToken);
        
        cancellationToken.ThrowIfCancellationRequested();
        
        _logger.LogInformation("[DisplayLogic:RecipeService] Recipes: {@Recipes}", recipesDto);

        return recipesDto.Select(MapFromDto).ToList();
    }

    /// <inheritdoc />
    public async Task<Recipe?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic:RecipeService] Getting recipe from DataProvider by id: {Id}", id);
        
        var recipeDto = await _dataProviderClient.GetRecipeByIdAsync(id, cancellationToken);
        
        _logger.LogInformation("[DisplayLogic:RecipeService] Recipe: {@Recipe}", recipeDto);

        return recipeDto != null ? MapFromDto(recipeDto) : null;
    }
    
    private Recipe MapFromDto(RecipeDto dto)
    {
        return new Recipe
        {
            Id = dto.Id,
            Title = dto.Title,
        };
    }
}