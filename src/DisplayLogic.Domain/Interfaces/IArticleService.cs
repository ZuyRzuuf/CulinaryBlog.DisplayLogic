using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Filters;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Service for managing articles.
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Gets all articles.
    /// </summary>
    /// <returns>
    /// Returns all articles.
    /// </returns>
    List<Article> GetAllArticles();
    /// <summary>
    /// Gets an article by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Returns an article with the provided id.
    /// </returns>
    Article? GetArticleById(Guid id);
    /// <summary>
    /// Gets articles filtered by the provided filters.
    /// </summary>
    /// <param name="filters"></param>
    /// <param name="logger"></param>
    /// <returns>
    /// Returns list of articles filtered by the provided filters.
    /// </returns>
    List<Article> GetFilteredArticles(ArticleFilter? filters, ILogger logger);
}
