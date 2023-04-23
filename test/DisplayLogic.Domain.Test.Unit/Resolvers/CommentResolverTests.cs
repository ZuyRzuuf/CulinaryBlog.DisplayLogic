using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Resolvers;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class CommentResolverTests
{
    private readonly CommentResolver _commentResolver;
    private readonly Mock<IResolverContext> _mockResolverContext;

    public CommentResolverTests()
    {
        _commentResolver = new CommentResolver();
        _mockResolverContext = new Mock<IResolverContext>();
    }

    [Fact]
    public void GetCommentsByArticleId_Should_Return_Correct_Comments()
    {
        // Arrange
        var article = new Article { Id = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285") };
        _mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);

        // Act
        var comments = _commentResolver.GetCommentsByArticleId(_mockResolverContext.Object);

        // Assert
        Assert.Single(comments);
        Assert.Equal("First sample comment.", comments[0].Content);
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_Should_Return_Correct_Comments()
    {
        // Arrange
        var recipe = new Recipe { Id = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377") };
        _mockResolverContext.Setup(context => context.Parent<Recipe>()).Returns(recipe);

        // Act
        var comments = await _commentResolver.GetCommentsByRecipeIdAsync(_mockResolverContext.Object);

        // Assert
        Assert.Single(comments);
        Assert.Equal("Second sample comment.", comments[0].Content);
    }
}