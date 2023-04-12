using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

public interface IArticleService
{
    List<Article> GetAllArticles();
    Article GetArticleById(Guid id);
}