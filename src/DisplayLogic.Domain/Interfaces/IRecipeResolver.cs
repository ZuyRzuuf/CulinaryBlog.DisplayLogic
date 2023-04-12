using DisplayLogic.Domain.Entities;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Interfaces;

public interface IRecipeResolver
{
    Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid);
}