using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Method
{
    /// <summary>
    /// The unique identifier for the method.
    /// </summary>
    [Required]
    public Guid Id { get; set; }
    /// <summary>
    /// The name of the method.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;
}