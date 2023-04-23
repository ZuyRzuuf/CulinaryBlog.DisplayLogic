using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using DisplayLogic.Domain.Test.Unit.DataMocks;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class ArticleResolverTests
{
    private readonly IArticleResolver _articleResolver;
    private readonly List<Article> _testArticles;
    
    public ArticleResolverTests()
    {
        _testArticles = ArticleMocks.TestArticles;
        _articleResolver = new ArticleResolver();
    }

    [Fact]
    public void GetAllArticles_ReturnsListOfArticles()
    {
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
    
        // Act
        var result = _articleResolver.GetArticleById(nonExistingId);

        // Assert
        Assert.Null(result);
    }
}
