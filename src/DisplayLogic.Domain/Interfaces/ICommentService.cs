using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

public interface ICommentService
{
    List<Comment> GetCommentsByArticleId(Guid articleId);
    Task<List<Comment>> GetCommentsByRecipeIdAsync(Guid recipeId);
}