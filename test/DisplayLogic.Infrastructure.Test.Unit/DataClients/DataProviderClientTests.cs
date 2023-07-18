using System.Net;
using DisplayLogic.Infrastructure.DataClients;
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
        public async Task GetRecipesAsync_ReturnsNull_WhenResponseIsUnsuccessful()
        {
            // Arrange
            var handler = new Mock<HttpMessageHandler>();

            // Mock an unsuccessful response from HttpClient
            handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
                .ReturnsResponse(HttpStatusCode.BadRequest);

            _httpClient = new HttpClient(handler.Object);
            
            var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
            
            // Act
            var recipes = await dataProviderClient.GetRecipesAsync();

            // Assert
            Assert.Null(recipes);
        }
        
        [Fact]
        public async Task GetRecipesAsync_ReturnsNull_WhenJsonIsInvalid()
        {
            // Arrange
            var handler = new Mock<HttpMessageHandler>();

            // Mock a successful response with invalid JSON
            handler.SetupRequest(HttpMethod.Get, "http://example.com/api/recipes")
                .ReturnsResponse(HttpStatusCode.OK, "invalid JSON");

            _httpClient = new HttpClient(handler.Object);
            
            var dataProviderClient = new DataProviderClient(_httpClient, _mockOptions.Object, _mockLogger.Object);
            
            // Act
            var recipes = await dataProviderClient.GetRecipesAsync();

            // Assert
            Assert.Null(recipes);
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

}