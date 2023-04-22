using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Services;
using DisplayLogic.Domain.Test.Unit.DataMocks;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

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
        var existingId = _testRecipes.First().Id;
        
        // Act
        var result = _recipeService.GetRecipeById(existingId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Recipe>(result);
        Assert.Equal(existingId, result?.Id);
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