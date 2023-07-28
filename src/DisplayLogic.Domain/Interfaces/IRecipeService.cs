using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// Service for managing recipes.
/// </summary>
public interface IRecipeService
{
    /// <summary>
    /// Get all recipes
    /// </summary>
    /// <returns>
    /// List of recipes
    /// </returns>
    Task<List<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Get recipe by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Recipe
    /// </returns>
    Task<Recipe?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default);
}