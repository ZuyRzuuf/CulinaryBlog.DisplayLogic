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

    public List<Comment> GetCommentsByArticleId(IResolverContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var articleId = context.Parent<Article>().Id;
        return _commentService.GetCommentsByArticleId(articleId);
    }

    public Task<List<Comment>> GetCommentsByRecipeIdAsync(IResolverContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var recipeId = context.Parent<Recipe>().Id;
        return _commentService.GetCommentsByRecipeIdAsync(recipeId);
    }
}