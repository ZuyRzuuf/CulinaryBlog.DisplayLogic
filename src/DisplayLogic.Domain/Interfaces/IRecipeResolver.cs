using DisplayLogic.Domain.Entities;
using HotChocolate.Resolvers;

namespace DisplayLogic.Domain.Interfaces;

/// <summary>
/// This interface is used to resolve the comments of a recipe.
/// </summary>
public interface IRecipeResolver
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
    Recipe? GetRecipeById(Guid id);
    /// <summary>
    /// This method is used to resolve the comments of a recipe.
    /// </summary>
    /// <param name="recipeUuid"></param>
    /// <returns>
    /// A list of comments.
    /// </returns>
    Task<List<Comment>> GetCommentsByRecipeUuidAsync(Guid recipeUuid);
}