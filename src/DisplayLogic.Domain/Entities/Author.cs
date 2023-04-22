using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Author
{
    /// <summary>
    /// The unique identifier for the author.
    /// </summary>
    [Required]
    public Guid Id { get; set; }
    /// <summary>
    /// The name of the author. 
    /// </summary>
    [Required]
    public string Username { get; set; } = string.Empty;
}