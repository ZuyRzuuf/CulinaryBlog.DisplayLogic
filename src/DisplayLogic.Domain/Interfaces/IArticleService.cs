using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Represents a service for articles.
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Gets all articles.
    /// </summary>
    /// <returns>
    /// A list of all articles.
    /// </returns>
    List<Article> GetAllArticles();
    /// <summary>
    /// Gets an article by its unique identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// The article with the specified unique identifier.
    /// </returns>
    Article GetArticleById(Guid id);
}