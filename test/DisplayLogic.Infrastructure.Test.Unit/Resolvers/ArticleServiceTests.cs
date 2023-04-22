using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Infrastructure.Resolvers;
using DisplayLogic.Infrastructure.Test.Unit.DataMocks;

namespace DisplayLogic.Infrastructure.Test.Unit.Resolvers;

public class ArticleServiceTests
{
    private readonly IArticleService _articleService;
    private readonly List<Article> _testArticles;
    
    public ArticleServiceTests()
    {
        _testArticles = ArticleMocks.TestArticles;
        _articleService = new ArticleService();
    }

    [Fact]
    public void GetAllArticles_ReturnsListOfArticles()
    {
        // Act
        var result = _articleService.GetAllArticles();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_testArticles.Count, result.Count);
        Assert.All(result, article => Assert.IsType<Article>(article));
    }

    [Fact]
    public void GetArticleById_WithExistingId_ReturnsArticle()
    {
        // Arrange
        var existingId = _testArticles.First().Id;
        
        // Act
        var result = _articleService.GetArticleById(existingId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Article>(result);
        Assert.Equal(existingId, result?.Id);
    }

    [Fact]
    public void GetArticleById_WithNonExistingId_ReturnsNull()
    {
        // Arrange
        var nonExistingId = Guid.Parse("00000000-0000-0000-0000-000000000000");
    
        // Act
        var result = _articleService.GetArticleById(nonExistingId);

        // Assert
        Assert.Null(result);
    }
}
