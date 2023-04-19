using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

/// <summary>
/// Represents an article.
/// </summary>
public class Article
{
    /// <summary>
    /// Gets or sets the unique identifier of the article.
    /// </summary>
    [Required]
    public Guid Uuid { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the title of the article.
    /// </summary>
    [Required]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the content of the article.
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the article.
    /// </summary>
    [Required]
    public Author Author { get; set; } = new Author();

    /// <summary>
    /// Gets or sets the published date of the article.
    /// </summary>
    [Required]
    public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the image URL of the article.
    /// </summary>
    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the tags of the article.
    /// </summary>
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    /// <summary>
    /// Gets or sets the comments of the article.
    /// </summary>
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}