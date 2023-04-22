using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using HotChocolate.Resolvers;
using DisplayLogic.Domain.Test.Unit.DataMocks;

namespace DisplayLogic.Domain.Test.Unit.Resolvers;

public class CommentResolverTests
{
    private readonly Mock<ICommentService> _mockCommentService;
    private readonly CommentResolver _commentResolver;
    private readonly List<Comment> _testComments;

    public CommentResolverTests()
    {
        _mockCommentService = new Mock<ICommentService>();
        _commentResolver = new CommentResolver(_mockCommentService.Object);

        _testComments = CommentMocks.TestComments;

        _mockCommentService.Setup(service => service.GetCommentsByArticleId(It.IsAny<Guid>()))
            .Returns((Guid articleId) => _testComments.Where(comment => comment.ArticleId == articleId).ToList());
    }

    [Fact]
    public void GetCommentsByArticleId_WithExistingId_ReturnsComments()
    {
        var existingId = _testComments.First().ArticleId;
        var expectedComments = _testComments.Where(c => c.ArticleId == existingId).ToList();
        var mockContext = CreateResolverContext(new Article { Id = existingId });

        var result = _commentResolver.GetCommentsByArticleId(mockContext);

        Assert.NotNull(result);
        Assert.Equal(expectedComments.Count, result.Count);
        Assert.All(result, comment => Assert.Equal(existingId, comment.ArticleId));
    }

    [Fact]
    public void GetCommentsByArticleId_WithNonExistingId_ReturnsEmptyList()
    {
        var nonExistingId = Guid.NewGuid();
        var mockContext = CreateResolverContext(new Article { Id = nonExistingId });

        var result = _commentResolver.GetCommentsByArticleId(mockContext);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    private IResolverContext CreateResolverContext(Article article)
    {
        var mockResolverContext = new Mock<IResolverContext>();
        mockResolverContext.Setup(context => context.Parent<Article>()).Returns(article);
        return mockResolverContext.Object;
    }
}
