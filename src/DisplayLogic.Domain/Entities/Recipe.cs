using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

/// <summary>
/// Represents a recipe.
/// </summary>
public class Recipe
{
    /// <summary>
    /// Gets or sets the unique identifier of the recipe.
    /// </summary>
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the title of the recipe.
    /// </summary>
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of ingredients of the recipe.
    /// </summary>
    [Required]
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    /// <summary>
    /// Gets or sets the list of instructions for the recipe.
    /// </summary>
    [Required]
    public ICollection<string> Instructions { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the author of the recipe.
    /// </summary>
    [Required]
    public Author Author { get; set; } = new Author();

    /// <summary>
    /// Gets or sets the published date of the recipe.
    /// </summary>
    [Required]
    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the image URL of the recipe.
    /// </summary>
    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category of the recipe.
    /// </summary>
    [Required]
    public Category Category { get; set; } = new Category();

    /// <summary>
    /// Gets or sets the cuisine of the recipe.
    /// </summary>
    public Cuisine Cuisine { get; set; } = new Cuisine();

    /// <summary>
    /// Gets or sets the diet of the recipe.
    /// </summary>
    public Diet Diet { get; set; } = new Diet();

    /// <summary>
    /// Gets or sets the method of the recipe.
    /// </summary>
    public Method Method { get; set; } = new Method();

    /// <summary>
    /// Gets or sets the season of the recipe.
    /// </summary>
    public Season Season { get; set; } = new Season();

    /// <summary>
    /// Gets or sets the tags of the recipe.
    /// </summary>
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    /// <summary>
    /// Gets or sets the comments of the recipe.
    /// </summary>
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
