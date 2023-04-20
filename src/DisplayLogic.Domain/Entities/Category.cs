using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Category
{
    /// <summary>
    /// The unique identifier for the category.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// The name of the category.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}