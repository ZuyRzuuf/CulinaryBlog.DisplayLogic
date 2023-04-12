using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Infrastructure.Resolvers;

public class RecipeResolver : IRecipeResolver
{
    private readonly ICommentService _commentService;

    public RecipeResolver(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public async Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid)
    {
        return await _commentService.GetCommentsByRecipeUuidAsync(recipeUuid);
    }
}