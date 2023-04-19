using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Cuisine
{
    /// <summary>
    /// The unique identifier for the cuisine.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// The name of the cuisine.
    /// </summary>
    [Required]
    public string Name { get; set; }
}