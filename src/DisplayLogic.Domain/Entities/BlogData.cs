namespace DisplayLogic.Domain.Entities;

public class BlogData
{
    /// <summary>
    /// The list of articles.
    /// </summary>
    public List<Article> Articles { get; set; } = new List<Article>();
    /// <summary>
    /// Article by id
    /// </summary>
    public Article? Article { get; set; }
    /// <summary>
    /// The list of recipes.
    /// </summary>
    public List<Recipe> Recipes { get; set; } = new List<Recipe>();
}