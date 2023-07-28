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
    /// Get article by id
    /// </summary>
    /// <param name="articleResolver"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Article GetArticleById([Service] IArticleResolver articleResolver, Guid id)
    {
        try
        {
            var article = articleResolver.GetArticleById(id);
            
            if (article == null)
            {
                throw new Exception($"Article with id {id} not found.");
            }
            
            return article;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Get all recipes
    /// </summary>
    /// <param name="recipeResolver"></param>
    /// <returns></returns>
    public List<Recipe> GetRecipes([Service] IRecipeResolver recipeResolver)
    {
        return recipeResolver.GetAllRecipesAsync().Result;
    }
}