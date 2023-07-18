using DisplayLogic.Domain.Dtos;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Client for getting data from the DataProvider.
/// </summary>
public interface IDataProviderClient
{
    /// <summary>
    /// Get all recipes.
    /// </summary>
    /// <returns></returns>
    public Task<List<RecipeDto>> GetRecipesAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a recipe by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<RecipeDto> GetRecipeAsync(Guid id);
    
    /// <summary>
    /// Get recipes by partial title.
    /// </summary>
    /// <param name="partialTitle"></param>
    /// <returns></returns>
    public Task<List<RecipeDto>> GetRecipesByPartialTitleAsync(string partialTitle);
}