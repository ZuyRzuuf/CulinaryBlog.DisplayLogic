using DisplayLogic.Domain.Services;

namespace DisplayLogic.Domain.Test.Unit.Services;

public class CommentServiceTests
{
    private readonly CommentService _commentService;

    public CommentServiceTests()
    {
        _commentService = new CommentService();
    }

    [Fact]
    public void GetCommentsByArticleId_Should_Return_Correct_Comments()
    {
        // Arrange
        var articleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285");

        // Act
        var comments = _commentService.GetCommentsByArticleId(articleId);

        // Assert
        Assert.Single(new[] { comments.Count });
        Assert.All(comments, comment => Assert.Equal(articleId, comment.ArticleId));
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_Should_Return_Correct_Comments()
    {
        // Arrange
        var recipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");

        // Act
        var comments = await _commentService.GetCommentsByRecipeIdAsync(recipeId);

        // Assert
        Assert.Single(new[] { comments.Count });
        Assert.All(comments, comment => Assert.Equal(recipeId, comment.RecipeId));
    }

    [Fact]
    public void GetCommentsByArticleId_InvalidId_Should_Return_EmptyList()
    {
        // Arrange
        var invalidArticleId = Guid.NewGuid();

        // Act
        var comments = _commentService.GetCommentsByArticleId(invalidArticleId);

        // Assert
        Assert.Empty(comments);
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_InvalidId_Should_Return_EmptyList()
    {
        // Arrange
        var invalidRecipeId = Guid.NewGuid();

        // Act
        var comments = await _commentService.GetCommentsByRecipeIdAsync(invalidRecipeId);

        // Assert
        Assert.Empty(comments);
    }
}