using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Entities;

public class Query
{
    public List<Article> GetArticles([Service] IArticleService articleService)
    {
        return articleService.GetAllArticles();
    }

    public List<Recipe> GetRecipes([Service] IRecipeService recipeService)
    {
        return recipeService.GetAllRecipes();
    }
}