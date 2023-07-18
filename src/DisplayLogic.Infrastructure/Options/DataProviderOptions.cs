using System.ComponentModel.DataAnnotations;
using DisplayLogic.Infrastructure.Interfaces;

namespace DisplayLogic.Infrastructure.Options;

public class DataProviderOptions : IApiOptions
{
    /// <inheritdoc />
    [Required]
    public string Host { get; set; } = string.Empty;
    /// <inheritdoc />
    [Required]
    public Dictionary<string, string> Endpoints { get; set; } = new();
    /// <inheritdoc />
    [Required]
    public string ApiKey { get; set; } = string.Empty;
}