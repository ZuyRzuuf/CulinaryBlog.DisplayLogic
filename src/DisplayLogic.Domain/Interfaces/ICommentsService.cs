using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Represents a service for comments.
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Gets all comments.
    /// </summary>
    /// <returns></returns>
    List<Comment> GetAllComments();
    /// <summary>
    /// Gets all comments for article with the specified unique identifier.
    /// </summary>
    /// <param name="articleUuid"></param>
    /// <returns></returns>
    List<Comment> GetCommentsByArticleId(Guid articleUuid);
    /// <summary>
    /// Gets all comments for recipe with the specified unique identifier.
    /// </summary>
    /// <param name="recipeUuid"></param>
    /// <returns></returns>
    Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid);
}
