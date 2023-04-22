using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Resolvers;

/// <inheritdoc />
public class RecipeResolver : IRecipeResolver
{
    private readonly ICommentService _commentService;

    public RecipeResolver(ICommentService commentService)
    {
        _commentService = commentService;
    }

    /// <inheritdoc />
    public async Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid)
    {
        return await _commentService.GetCommentsByRecipeUuidAsync(recipeUuid);
    }
}