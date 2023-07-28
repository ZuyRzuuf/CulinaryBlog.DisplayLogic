using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class RecipeResolverTests
{
    private readonly RecipeResolver _recipeResolver;
    private readonly Mock<IDataProviderClient> _mockDataProviderClient;
    private readonly Mock<IRecipeService> _recipeServiceMock;
    private readonly Mock<ILogger<RecipeResolver>> _loggerMock;

    public RecipeResolverTests()
    {
        var existingId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");

        _mockDataProviderClient = new Mock<IDataProviderClient>();
        _recipeServiceMock = new Mock<IRecipeService>();
        _loggerMock = new Mock<ILogger<RecipeResolver>>();

        // Set up mock responses
        var recipe1 = new Recipe { Id = existingId, Title = "Spicy Thai Green Curry" }; // here's the change
        var recipe2 = new Recipe { Id = Guid.NewGuid(), Title = "Tasty Thai Red Curry" };
        var recipes = new List<Recipe> { recipe1, recipe2 };
    
        _recipeServiceMock.Setup(service => 
                service.GetAllRecipesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipes);
    
        _recipeServiceMock.Setup(service => 
                service.GetRecipeByIdAsync(existingId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(recipe1);
    
        _recipeServiceMock.Setup(service => 
                service.GetRecipeByIdAsync(It.Is<Guid>(id => id != recipe1.Id && id != recipe2.Id), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Recipe)null);
    
        _recipeResolver = new RecipeResolver(
            _mockDataProviderClient.Object,
            _recipeServiceMock.Object,
            _loggerMock.Object);
    }

    [Fact]
    public async void GetAllRecipes_ReturnsAllRecipes()
    {
        // Act
        var recipes = await _recipeResolver.GetAllRecipesAsync();

        // Assert
        Assert.NotNull(recipes);
        Assert.Equal(2, recipes.Count);
        Assert.Equal("Spicy Thai Green Curry", recipes[0].Title);
        Assert.Equal("Tasty Thai Red Curry", recipes[1].Title);
    }

    [Fact]
    public async void GetRecipeById_ReturnsRecipe_WhenIdExists()
    {
        // Arrange
        var recipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");

        // Act
        var recipe = await _recipeResolver.GetRecipeByIdAsync(recipeId);

        // Assert
        Assert.NotNull(recipe);
        Assert.Equal(recipeId, recipe?.Id);
        Assert.Equal("Spicy Thai Green Curry", recipe?.Title);
    }

    [Fact]
    public async void GetRecipeById_ReturnsNull_WhenIdDoesNotExist()
    {
        // Arrange
        var nonExistentRecipeId = Guid.NewGuid();

        // Act
        var recipe = await _recipeResolver.GetRecipeByIdAsync(nonExistentRecipeId);

        // Assert
        Assert.Null(recipe);
    }
}