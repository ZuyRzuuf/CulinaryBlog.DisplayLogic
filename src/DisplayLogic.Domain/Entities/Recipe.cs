namespace DisplayLogic.Domain.Entities;

public class Recipe
{
    public Guid Uuid { get; set; }
    public string Title { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<string> Instructions { get; set; } = new List<string>();
    public Author Author { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ImageUrl { get; set; }
    public Category Category { get; set; }
    public Cuisine Cuisine { get; set; }
    public Diet Diet { get; set; }
    public Method Method { get; set; }
    public Season Season { get; set; }
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}