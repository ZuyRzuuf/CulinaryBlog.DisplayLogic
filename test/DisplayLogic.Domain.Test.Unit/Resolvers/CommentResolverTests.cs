using System.Diagnostics;
using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class CommentResolverTests
{
    private readonly CommentResolver _commentResolver;
    private readonly Mock<IResolverContext> _mockResolverContext;
    private readonly Mock<ICommentService> _mockCommentService;

    public CommentResolverTests()
    {
        _mockResolverContext = new Mock<IResolverContext>();
        _mockCommentService = new Mock<ICommentService>();

        var sampleArticleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285");
        var sampleRecipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");

        // Default setup for any articleId
        _mockCommentService.Setup(service => 
                service.GetCommentsByArticleId(It.IsAny<Guid>()))
            .Returns(new List<Comment>());

        // Default setup for any recipeId
        _mockCommentService.Setup(service => 
                service.GetCommentsByRecipeIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new List<Comment>());

        _mockCommentService.Setup(service => 
                service.GetCommentsByArticleId(sampleArticleId))
            .Returns(new List<Comment>{ 
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Article Comment 1",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author1" },
                    ArticleId = sampleArticleId
                },
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Article Comment 2",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author2" },
                    ArticleId = sampleArticleId
                },
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Article Comment 3",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author3" },
                    ArticleId = sampleArticleId
                }
            });

        _mockCommentService.Setup(service => 
                service.GetCommentsByRecipeIdAsync(sampleRecipeId))
            .ReturnsAsync(new List<Comment>{ 
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Recipe Comment 1",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author4" },
                    RecipeId = sampleRecipeId
                },
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Recipe Comment 2",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author5" },
                    RecipeId = sampleRecipeId
                },
                new Comment 
                { 
                    Id = Guid.NewGuid(),
                    Content = "Recipe Comment 3",
                    CreatedAt = DateTime.UtcNow,
                    Author = new Author { Id = Guid.NewGuid(), Username = "Author6" },
                    RecipeId = sampleRecipeId
                } 
            });

        _commentResolver = new CommentResolver(_mockCommentService.Object);
    }

    [Fact]
    public void GetCommentsByArticleId_Should_Return_Correct_Comments()
    {
        // Arrange
        var articleId = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285");
        var article = new Article { Id = articleId };
        _mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);

        // Act
        var comments = _commentResolver.GetCommentsByArticleId(_mockResolverContext.Object);

        // Assert
        Assert.Equal(3, comments.Count);
        Assert.All(comments, comment => Assert.Equal(articleId, comment.ArticleId));
        Assert.Contains(comments, comment => comment.Content == "Article Comment 1");
        Assert.Contains(comments, comment => comment.Content == "Article Comment 2");
        Assert.Contains(comments, comment => comment.Content == "Article Comment 3");
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_Should_Return_Correct_Comments()
    {
        // Arrange
        var recipeId = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377");
        var recipe = new Recipe { Id = recipeId };
        _mockResolverContext.Setup(context => context.Parent<Recipe>()).Returns(recipe);

        // Act
        var comments = await _commentResolver.GetCommentsByRecipeIdAsync(_mockResolverContext.Object);

        // Assert
        Assert.Equal(3, comments.Count);
        Assert.All(comments, comment => Assert.Equal(recipeId, comment.RecipeId));
        Assert.Contains(comments, comment => comment.Content == "Recipe Comment 1");
        Assert.Contains(comments, comment => comment.Content == "Recipe Comment 2");
        Assert.Contains(comments, comment => comment.Content == "Recipe Comment 3");
    }
    
    [Fact]
    public void GetCommentsByArticleId_NoComments_Should_Return_EmptyList()
    {
        // Arrange
        var articleId = Guid.NewGuid(); // use a new Guid not setup in the mock
        var article = new Article { Id = articleId };
        _mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);

        // Act
        var comments = _commentResolver.GetCommentsByArticleId(_mockResolverContext.Object);

        // Assert
        Assert.Empty(comments);
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_NoComments_Should_Return_EmptyList()
    {
        // Arrange
        var recipeId = Guid.NewGuid(); // use a new Guid not setup in the mock
        var recipe = new Recipe { Id = recipeId };
        _mockResolverContext.Setup(context => context.Parent<Recipe>()).Returns(recipe);

        // Act
        var comments = await _commentResolver.GetCommentsByRecipeIdAsync(_mockResolverContext.Object);

        // Assert
        Assert.Empty(comments);
    }
    
    [Fact]
    public void GetCommentsByArticleId_InvalidParameter_Should_Throw_ArgumentNullException()
    {
        // Arrange
        IResolverContext nullResolverContext = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => _commentResolver.GetCommentsByArticleId(nullResolverContext));
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_InvalidParameter_Should_Throw_ArgumentNullException()
    {
        // Arrange
        IResolverContext nullResolverContext = null;

        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _commentResolver.GetCommentsByRecipeIdAsync(nullResolverContext));
    }
    
    [Fact]
    public void GetCommentsByArticleId_ServiceThrowsException_Should_Throw_Exception()
    {
        // Arrange
        var exceptionMessage = "Service Exception";
        var article = new Article { Id = Guid.NewGuid() };
        _mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);

        _mockCommentService.Setup(service => service.GetCommentsByArticleId(article.Id))
            .Throws(new Exception(exceptionMessage));

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _commentResolver.GetCommentsByArticleId(_mockResolverContext.Object));
        Assert.Equal(exceptionMessage, ex.Message);
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_ServiceThrowsException_Should_Throw_Exception()
    {
        // Arrange
        var exceptionMessage = "Service Exception";
        var recipe = new Recipe { Id = Guid.NewGuid() };
        _mockResolverContext.Setup(context => context.Parent<Recipe>()).Returns(recipe);

        _mockCommentService.Setup(service => service.GetCommentsByRecipeIdAsync(recipe.Id))
            .ThrowsAsync(new Exception(exceptionMessage));

        // Act & Assert
        var ex = await Assert.ThrowsAsync<Exception>(async () => await _commentResolver.GetCommentsByRecipeIdAsync(_mockResolverContext.Object));
        Assert.Equal(exceptionMessage, ex.Message);
    }
    
    [Fact]
    public void GetCommentsByArticleId_Performance_Test()
    {
        // Arrange
        var article = new Article { Id = Guid.Parse("3d5d4cd1-b6f4-4ae4-a25a-918e185d6285") };
        _mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);

        var stopwatch = new Stopwatch();

        // Act
        stopwatch.Start();
        var comments = _commentResolver.GetCommentsByArticleId(_mockResolverContext.Object);
        stopwatch.Stop();

        // Assert
        Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 500); // Adjust the maximum acceptable time as needed
    }

    [Fact]
    public async Task GetCommentsByRecipeIdAsync_Performance_Test()
    {
        // Arrange
        var recipe = new Recipe { Id = Guid.Parse("06afd62f-33fe-4271-952b-da9a1241c377") };
        _mockResolverContext.Setup(context => context.Parent<Recipe>()).Returns(recipe);

        var stopwatch = new Stopwatch();

        // Act
        stopwatch.Start();
        var comments = await _commentResolver.GetCommentsByRecipeIdAsync(_mockResolverContext.Object);
        stopwatch.Stop();

        // Assert
        Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 500); // Adjust the maximum acceptable time as needed
    }
}