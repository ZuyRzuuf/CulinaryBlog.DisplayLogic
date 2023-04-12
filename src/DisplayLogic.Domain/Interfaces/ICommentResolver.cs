using DisplayLogic.Domain.Entities;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Interfaces;

public interface ICommentResolver
{
    public List<Comment> GetCommentsByArticleId(IResolverContext context);
}