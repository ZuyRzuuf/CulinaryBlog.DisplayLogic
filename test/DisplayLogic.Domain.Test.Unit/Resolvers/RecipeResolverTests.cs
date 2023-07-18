using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class RecipeResolverTests
{
    private readonly RecipeResolver _recipeResolver;
    private readonly Mock<IDataProviderClient> _mockDataProviderClient;

    public RecipeResolverTests()
    {
        _mockDataProviderClient = new Mock<IDataProviderClient>();
        _recipeResolver = new RecipeResolver(_mockDataProviderClient.Object);
    }

    [Fact]
    public void GetAllRecipes_ReturnsAllRecipes()
    {
        // Act
        var recipes = _recipeResolver.GetAllRecipes();

        // Assert
        Assert.NotNull(recipes);
        Assert.Equal(2, recipes.Count);
        Assert.Equal("Spicy Thai Green Curry", recipes[0].Title);
        Assert.Equal("Tasty Thai Red Curry", recipes[1].Title);
    }

    [Fact]
    public void GetRecipeById_ReturnsRecipe_WhenIdExists()
    {
        // Arrange
        var recipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");

        // Act
        var recipe = _recipeResolver.GetRecipeById(recipeId);

        // Assert
        Assert.NotNull(recipe);
        Assert.Equal(recipeId, recipe?.Id);
        Assert.Equal("Spicy Thai Green Curry", recipe?.Title);
    }

    [Fact]
    public void GetRecipeById_ReturnsNull_WhenIdDoesNotExist()
    {
        // Arrange
        var nonExistentRecipeId = Guid.NewGuid();

        // Act
        var recipe = _recipeResolver.GetRecipeById(nonExistentRecipeId);

        // Assert
        Assert.Null(recipe);
    }
}