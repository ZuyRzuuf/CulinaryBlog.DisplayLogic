using System.Net;
using System.Text.Json;
using DisplayLogic.Infrastructure.DataClients;
using DisplayLogic.Infrastructure.Exceptions;
using DisplayLogic.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq.Contrib.HttpClient;

namespace DisplayLogic.Infrastructure.Test.Unit.DataClients;

public class DataProviderClientTests
{
    private readonly Mock<ILogger<DataProviderClient>> _mockLogger;
    private readonly Mock<IOptions<DataProviderOptions>> _mockOptions;
    private HttpClient _httpClient;

    public DataProviderClientTests()
    {
        // Mock logger and options
        _mockLogger = new Mock<ILogger<DataProviderClient>>();
        _mockOptions = new Mock<IOptions<DataProviderOptions>>();
        
        _mockOptions.Setup(o => o.Value).Returns(new DataProviderOptions
        {
            Host = "http://example.com",
            Endpoints = new Dictionary<string, string>
            {
                { "Recipes", "/api/recipes" }
            }
        });
    }

    [Fact]
    public async Task GetRecipesAsync_ReturnsRecipes_WhenResponseIsSuccessful()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();

        // Mock a successful response from HttpClient
        handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
            .ReturnsResponse(HttpStatusCode.OK, "[{ \"id\": \"d3e6479d-0c7e-4125-9049-7d6e1b7614e1\", \"title\": \"Sample Recipe\" }]");

        _httpClient = new HttpClient(handler.Object);
        
        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
        
        // Act
        var recipes = await dataProviderClient.GetRecipesAsync();

        // Assert
        Assert.NotNull(recipes);
        Assert.Single(recipes);
        Assert.Equal("Sample Recipe", recipes[0].Title);
    }
    
    [Fact]
    public async Task GetRecipesAsync_ReturnsEmptyList_WhenResponseIsEmptyJson()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();

        // Mock a successful response with an empty JSON array
        handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
            .ReturnsResponse(HttpStatusCode.OK, "[]");

        _httpClient = new HttpClient(handler.Object);

        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);

        // Act
        var recipes = await dataProviderClient.GetRecipesAsync();

        // Assert
        Assert.NotNull(recipes);
        Assert.Empty(recipes);
    }

    [Fact]
    public async Task GetRecipesAsync_ThrowsDataClientConnectionProblemException_WhenResponseIsUnsuccessful()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();

        // Mock an unsuccessful response from HttpClient
        handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
            .ReturnsResponse(HttpStatusCode.BadRequest);

        _httpClient = new HttpClient(handler.Object);
    
        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
    
        // Act & Assert
        await Assert.ThrowsAsync<DataClientConnectionProblemException>(() => dataProviderClient.GetRecipesAsync());
    }
    
    [Fact]
    public async Task GetRecipesAsync_ThrowsJsonException_WhenJsonIsInvalid()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();

        // Mock a successful response with invalid JSON
        handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
            .ReturnsResponse(HttpStatusCode.OK, "invalid JSON");

        _httpClient = new HttpClient(handler.Object);
    
        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
    
        // Act & Assert
        await Assert.ThrowsAsync<JsonException>(() => dataProviderClient.GetRecipesAsync());
    }

    [Fact]
    public async Task GetRecipesAsync_Throws_WhenRequestIsCanceled()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();

        // Mock a successful response
        handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{ \"id\": \"d3e6479d-0c7e-4125-9049-7d6e1b7614e1\", \"title\": \"Sample Recipe\" }]")
            });

        _httpClient = new HttpClient(handler.Object);

        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);

        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        // Act & Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() => dataProviderClient.GetRecipesAsync(cancellationTokenSource.Token));
    }

    [Fact]
    public void GetRecipeAsync_Throws_NotImplementedException()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(handler.Object);
        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
        var testGuid = Guid.NewGuid();

        // Act & Assert
        Assert.ThrowsAsync<NotImplementedException>(() => dataProviderClient.GetRecipeByIdAsync(testGuid));
    }

    [Fact]
    public void GetRecipesByPartialTitleAsync_Throws_NotImplementedException()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(handler.Object);
        var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
        var partialTitle = "TestTitle";

        // Act & Assert
        Assert.ThrowsAsync<NotImplementedException>(() => dataProviderClient.GetRecipesByPartialTitleAsync(partialTitle));
    }
}