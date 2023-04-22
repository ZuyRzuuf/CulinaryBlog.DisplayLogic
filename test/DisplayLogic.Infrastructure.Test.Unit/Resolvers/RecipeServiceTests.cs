using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Infrastructure.Resolvers;
using DisplayLogic.Infrastructure.Test.Unit.DataMocks;

namespace DisplayLogic.Infrastructure.Test.Unit.Resolvers;

public class RecipeServiceTests
{
    private readonly IRecipeService _recipeService;
    private readonly List<Recipe> _testRecipes;

    public RecipeServiceTests()
    {
        _testRecipes = RecipeMocks.TestRecipes;
        _recipeService = new RecipeService();
    }

    [Fact]
    public void GetAllRecipes_ReturnsListOfRecipes()
    {
        // Act
        var result = _recipeService.GetAllRecipes();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_testRecipes.Count, result.Count);
        Assert.All(result, recipe => Assert.IsType<Recipe>(recipe));
    }

    [Fact]
    public void GetRecipeById_WithExistingId_ReturnsRecipe()
    {
        // Arrange
        var existingId = _testRecipes.First().Uuid;
        
        // Act
        var result = _recipeService.GetRecipeById(existingId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Recipe>(result);
        Assert.Equal(existingId, result?.Uuid);
    }

    [Fact]
    public void GetRecipeById_WithNonExistingId_ReturnsNull()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");

        // Act
        var result = _recipeService.GetRecipeById(nonExistingId);

        // Assert
        Assert.Null(result);
    }
}