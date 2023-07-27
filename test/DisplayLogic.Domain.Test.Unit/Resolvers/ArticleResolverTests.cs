using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using DisplayLogic.Domain.Test.Unit.DataMocks;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class ArticleResolverTests
{
    private readonly IArticleResolver _articleResolver;
    private readonly List<Article> _testArticles;
    private readonly Mock<ILogger<ArticleResolver>> _mockLogger;
    private readonly Mock<IArticleService> _mockArticleService;
    
    public ArticleResolverTests()
    {
        _mockLogger = new Mock<ILogger<ArticleResolver>>();
        _mockArticleService = new Mock<IArticleService>();
        _testArticles = ArticleMocks.TestArticles;
        _articleResolver = new ArticleResolver(_mockLogger.Object, _mockArticleService.Object);
    }

    [Fact]
    public void GetAllArticles_ReturnsListOfArticles()
    {
        // Arrange
        _mockArticleService.Setup(s => s.GetAllArticles()).Returns(_testArticles);

        // Act
        var result = _articleResolver.GetAllArticles();

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
        _mockArticleService.Setup(s => s.GetArticleById(existingId)).Returns(_testArticles.First(a => a.Id == existingId));

        // Act
        var result = _articleResolver.GetArticleById(existingId);

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
        _mockArticleService.Setup(s => s.GetArticleById(nonExistingId)).Returns((Article)null);

        // Act
        var result = _articleResolver.GetArticleById(nonExistingId);

        // Assert
        Assert.Null(result);
    }
}
