using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Ingredient
{
    /// <summary>
    /// The unique identifier for the ingredient.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    [Required]
    public string Name { get; set; }
}