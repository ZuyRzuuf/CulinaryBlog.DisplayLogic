using System.Text.Json;
using DisplayLogic.Domain.Dtos;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DisplayLogic.Infrastructure.DataClients;

public class DataProviderClient : IDataProviderClient
{
    public readonly HttpClient _httpClient;
    private readonly DataProviderOptions _dataProviderOptions;
    private readonly ILogger<DataProviderClient> _logger;

    public DataProviderClient(
        HttpClient httpClient, 
        IOptions<DataProviderOptions> options, 
        ILogger<DataProviderClient> logger)
    {
        _httpClient = httpClient;
        _dataProviderOptions = options.Value;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<List<RecipeDto>> GetRecipesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic] Getting recipes from DataProvider");
        
        var url = CreateUrl(_dataProviderOptions.Host, _dataProviderOptions.Endpoints["Recipes"]);
        
        var response = await _httpClient.GetAsync(
            url,
            cancellationToken);
        
        _logger.LogInformation("Response status code: {StatusCode}", response.StatusCode);
        
        List<RecipeDto>? recipes = null;

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                recipes = JsonSerializer.Deserialize<List<RecipeDto>>(content, options) ?? new List<RecipeDto>();
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "[DisplayLogic] Error deserializing the received recipes");
            }
            
            _logger.LogInformation("[DisplayLogic] Recipes: {@Recipes}", recipes);
        }
        else
        {
            _logger.LogError("[DisplayLogic] Error getting recipes from DataProvider");
        }

        return recipes;
    }

    /// <inheritdoc />
    public Task<RecipeDto> GetRecipeAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<List<RecipeDto>> GetRecipesByPartialTitleAsync(string partialTitle)
    {
        throw new NotImplementedException();
    }
    
    private static string CreateUrl(string host, string endpoint) => 
        $"{host}{endpoint}".TrimEnd('/');
}