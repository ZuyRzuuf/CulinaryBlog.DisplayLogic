namespace DisplayLogic.Infrastructure.Interfaces;

public interface IApiOptions
{
    /// <summary>
    /// API client host
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// API client endpoints that will be used
    /// </summary>
    public Dictionary<string, string> Endpoints { get; set; }
    /// <summary>
    /// API client key used for authentication
    /// </summary>
    public string ApiKey { get; set; }
}