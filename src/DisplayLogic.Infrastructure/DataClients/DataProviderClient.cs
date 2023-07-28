using System.Net;
using System.Text.Json;
using DisplayLogic.Domain.Dtos;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Infrastructure.Exceptions;
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
        _logger.LogInformation("[DisplayLogic:DataProviderClient] Getting recipes from DataProvider");
        
        var url = CreateUrl(_dataProviderOptions.Host, _dataProviderOptions.Endpoints["Recipes"]);
        var response = await _httpClient.GetAsync(url, cancellationToken);
        
        cancellationToken.ThrowIfCancellationRequested();
        
        _logger.LogInformation("[DisplayLogic:DataProviderClient] Response status code: {StatusCode}", response.StatusCode);
        
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
                _logger.LogError(ex, "[DisplayLogic:DataProviderClient] Error deserializing the received recipes");
                throw;
            }
            
            _logger.LogInformation("[DisplayLogic:DataProviderClient] Recipes: {@Recipes}", recipes);
        }
        else
        {
            _logger.LogError("[DisplayLogic:DataProviderClient] Error getting recipes from DataProvider");
            throw new DataClientConnectionProblemException("Error getting recipes from DataProvider");
        }

        return recipes;
    }

    /// <inheritdoc />
    public async Task<RecipeDto?> GetRecipeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("[DisplayLogic:DataProviderClient] Getting recipe from DataProvider by id: {Id}", id);
        
        var urlParameters = new Dictionary<string, string>
        {
            { "id", id.ToString() },
        };
        var url = CreateUrl(
            _dataProviderOptions.Host, 
            _dataProviderOptions.Endpoints["RecipeById"], 
            urlParameters);
        var response = _httpClient.GetAsync(url, cancellationToken);
        
        cancellationToken.ThrowIfCancellationRequested();
        
        _logger.LogInformation("[DisplayLogic:DataProviderClient] Response status code: {StatusCode}", response.Result.StatusCode);
        
        RecipeDto? recipe = null;
        
        if (response.Result.IsSuccessStatusCode)
        {
            var content = await response.Result.Content.ReadAsStringAsync(cancellationToken);
            
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                recipe = JsonSerializer.Deserialize<RecipeDto>(content, options);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "[DisplayLogic:DataProviderClient] Error deserializing the received recipe");
                throw;
            }
            
            _logger.LogInformation("[DisplayLogic:DataProviderClient] Recipe: {@Recipe}", recipe);
        }
        else if (response.Result.StatusCode == HttpStatusCode.NotFound)
        {
            _logger.LogInformation("[DisplayLogic:DataProviderClient] Recipe not found");
        }
        else
        {
            _logger.LogError("[DisplayLogic:DataProviderClient] Error getting recipe from DataProvider");
            throw new DataClientConnectionProblemException("Error getting recipe from DataProvider");
        }
        
        return recipe;
    }

    /// <inheritdoc />
    public Task<List<RecipeDto>> GetRecipesByPartialTitleAsync(string partialTitle)
    {
        throw new NotImplementedException();
    }
    
    private static string CreateUrl(string host, string endpoint, Dictionary<string, string>? parameters = null)
    {
        var url = $"{host}{endpoint}".TrimEnd('/');

        return parameters == null 
            ? url 
            : parameters.Aggregate(url, (current, param) => 
                current.Replace($"{{{param.Key}}}", param.Value));
    }
}