using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Entities;

public class Query
{
    /// <summary>
    /// Get all articles
    /// </summary>
    /// <param name="articleService"></param>
    /// <returns></returns>
    public List<Article> GetArticles([Service] IArticleService articleService)
    {
        return articleService.GetAllArticles();
    }

    /// <summary>
    /// Get all recipes
    /// </summary>
    /// <param name="recipeService"></param>
    /// <returns></returns>
    public List<Recipe> GetRecipes([Service] IRecipeService recipeService)
    {
        return recipeService.GetAllRecipes();
    }
}