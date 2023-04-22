using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Resolvers;

/// <inheritdoc />
public class CommentResolver : ICommentResolver
{
    private readonly ICommentService _commentService;
    
    public CommentResolver(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    /// <inheritdoc />
    public List<Comment> GetCommentsByArticleId(IResolverContext context)
    {
        var articleUuid = context.Parent<Article>().Id;
        return _commentService.GetCommentsByArticleId(articleUuid);
    }
}