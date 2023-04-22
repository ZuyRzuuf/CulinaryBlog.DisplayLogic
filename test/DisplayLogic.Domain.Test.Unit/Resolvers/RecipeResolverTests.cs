using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using DisplayLogic.Domain.Test.Unit.DataMocks;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class RecipeResolverTests
{
    private readonly RecipeResolver _recipeResolver;
    private readonly Mock<ICommentService> _commentServiceMock;
    private readonly List<Comment> _testComments;

    public RecipeResolverTests()
    {
        _commentServiceMock = new Mock<ICommentService>();
        _recipeResolver = new RecipeResolver(_commentServiceMock.Object);
        _testComments = CommentMocks.TestComments;
    }

    [Fact]
    public async Task GetCommentsByRecipeUuidAsync_ReturnsCommentsForRecipe()
    {
        // Arrange
        var testRecipeUuid = Guid.Parse(_testComments[0].RecipeId.ToString());

        _commentServiceMock
            .Setup(cs => cs.GetCommentsByRecipeUuidAsync(It.IsAny<Guid>()))
            .ReturnsAsync(_testComments.FindAll(c => c.RecipeId == testRecipeUuid));

        // Act
        var result = await _recipeResolver.GetCommentsByRecipeUuidAsync(testRecipeUuid);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(_testComments.FindAll(c => c.RecipeId == testRecipeUuid).Count, result.Count);
        _commentServiceMock.Verify(cs => cs.GetCommentsByRecipeUuidAsync(testRecipeUuid), Times.Once);
    }
}
