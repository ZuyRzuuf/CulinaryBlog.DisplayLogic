using System.ComponentModel.DataAnnotations;

namespace DisplayLogic.Domain.Entities;

public class Season
{
    /// <summary>
    /// Gets or sets the unique identifier of the season.
    /// </summary>
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the season.
    /// </summary>
    [Required]
    public string Name { get; set; }
}