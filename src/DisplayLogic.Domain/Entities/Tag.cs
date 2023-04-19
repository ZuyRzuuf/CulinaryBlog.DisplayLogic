using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Tag
{
    /// <summary>
    /// Gets or sets the unique identifier of the tag.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the tag.
    /// </summary>
    [Required]
    public string Name { get; set; }
}