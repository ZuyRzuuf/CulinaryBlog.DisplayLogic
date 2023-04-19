using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Interfaces;

public interface IRecipeService
{
    /// <summary>
    /// Get all recipes
    /// </summary>
    /// <returns>
    /// List of recipes
    /// </returns>
    List<Recipe> GetAllRecipes();
    /// <summary>
    /// Get recipe by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Recipe
    /// </returns>
    Recipe GetRecipeById(Guid id);
}