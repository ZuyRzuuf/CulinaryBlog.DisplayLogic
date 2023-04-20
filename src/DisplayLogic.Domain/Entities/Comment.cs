using System.ComponentModel.DataAnnotations;
using DisplayLogic.Domain.AttributeValidators;

namespace DisplayLogic.Domain.Entities;

[ExactlyOne("ArticleId", "RecipeId")]
public class Comment
{
    /// <summary>
    /// The unique identifier for the comment.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// The content of the comment.
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;
    /// <summary>
    /// The author of the comment.
    /// </summary>
    [Required]
    public Author Author { get; set; } = new Author();
    /// <summary>
    /// The date and time the comment was created.
    /// </summary>
    [Required]
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Id of the article the comment is associated with.
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// Id of the recipe the comment is associated with.
    /// </summary>
    public Guid RecipeId { get; set; }
}