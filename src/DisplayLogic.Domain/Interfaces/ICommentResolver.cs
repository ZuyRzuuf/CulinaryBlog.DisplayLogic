using DisplayLogic.Domain.Entities;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Represents a resolver for comments.
/// </summary>
public interface ICommentResolver
{
    /// <summary>
    /// Gets all comments for article with the specified unique identifier.
    /// </summary>
    /// <param name="context"></param>
    /// <returns>
    /// A list of all comments for article with the specified unique identifier.
    /// </returns>
    public List<Comment> GetCommentsByArticleId(IResolverContext context);
}