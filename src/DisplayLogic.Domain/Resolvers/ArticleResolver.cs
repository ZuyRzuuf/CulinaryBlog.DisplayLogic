using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Filters;
using DisplayLogic.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Resolvers;

/// <inheritdoc />
public class ArticleResolver : IArticleResolver
{
    private readonly ILogger<ArticleResolver> _logger;
    private readonly IArticleService _articleService;

    public ArticleResolver(ILogger<ArticleResolver> logger, IArticleService articleService)
    {
        _logger = logger;
        _articleService = articleService;
    }
    
    /// <inheritdoc />
    public List<Article> GetAllArticles() => _articleService.GetAllArticles();

    /// <inheritdoc />
    public Article? GetArticleById(Guid id)
    {
        _logger.LogInformation("[DisplayLogic] Getting article by id: {Id}", id);
        return _articleService.GetArticleById(id);
    }

    /// <inheritdoc />
    public List<Article> GetFilteredArticles(ArticleFilter? filters) => _articleService.GetFilteredArticles(filters, _logger);
}
