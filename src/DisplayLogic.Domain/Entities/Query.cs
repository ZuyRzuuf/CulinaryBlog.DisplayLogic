using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Entities;

public class Query
{
    /// <summary>
    /// Get all articles
    /// </summary>
    /// <param name="articleResolver"></param>
    /// <returns></returns>
    public List<Article> GetArticles([Service] IArticleResolver articleResolver)
    {
        return articleResolver.GetAllArticles();
    }

    /// <summary>
    /// Get all recipes
    /// </summary>
    /// <param name="recipeResolver"></param>
    /// <returns></returns>
    public List<Recipe> GetRecipes([Service] IRecipeResolver recipeResolver)
    {
        return recipeResolver.GetAllRecipes();
    }
}