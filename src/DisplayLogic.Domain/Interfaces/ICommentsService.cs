using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

public interface ICommentService
{
    List<Comment> GetAllComments();
    List<Comment> GetCommentsByArticleId(Guid articleUuid);
}
