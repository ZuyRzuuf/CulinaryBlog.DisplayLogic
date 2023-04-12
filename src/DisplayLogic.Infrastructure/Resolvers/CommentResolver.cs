using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using HotChocolate.Resolvers;

namespace DisplayLogic.Infrastructure.Resolvers;

public class CommentResolver : ICommentResolver
{
    private readonly ICommentService _commentService;
    
    public CommentResolver(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    public List<Comment> GetCommentsByArticleId(IResolverContext context)
    {
        Guid articleUuid = context.Parent<Article>().Uuid;
        return _commentService.GetCommentsByArticleId(articleUuid);
    }
}