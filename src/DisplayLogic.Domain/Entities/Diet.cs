using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Diet
{
    /// <summary>
    /// The unique identifier for the diet.
    /// </summary>
    [Required]
    public Guid Id { get; set; }
    /// <summary>
    /// The name of the diet.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}
