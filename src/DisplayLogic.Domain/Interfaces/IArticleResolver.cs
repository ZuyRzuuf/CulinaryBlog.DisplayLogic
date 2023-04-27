using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Filters;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Represents a service for articles.
/// </summary>
public interface IArticleResolver
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
    Article? GetArticleById(Guid id);
    /// <summary>
    /// Gets a list of articles filtered by the specified filters.
    /// </summary>
    /// <param name="filters"></param>
    /// <returns></returns>
    List<Article> GetFilteredArticles(ArticleFilter? filters);
}