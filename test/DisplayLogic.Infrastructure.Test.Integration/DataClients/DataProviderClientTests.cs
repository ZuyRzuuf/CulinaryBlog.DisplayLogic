using System.Text.Json;
using DisplayLogic.Domain.Dtos;
using DisplayLogic.Infrastructure.DataClients;
using DisplayLogic.Infrastructure.Options;
using DisplayLogic.Infrastructure.Test.Integration.Fixtures;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Contrib.HttpClient;
using Polly;

namespace DisplayLogic.Infrastructure.Test.Integration.DataClients;

public class DataProviderClientTests : IClassFixture<DataProviderClientFixture>
{
    private readonly DataProviderClientFixture _fixture;

    public DataProviderClientTests(DataProviderClientFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetRecipesAsync_ReturnsRecipes()
    {
        // Arrange

        // Act
        var result = await _fixture.Client.GetRecipesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.All(result, item => Assert.IsType<RecipeDto>(item));
        Assert.All(result, item => Assert.NotEmpty(new[] { item.Id }));
        Assert.All(result, item => Assert.NotEmpty(item.Title));
    }
    
    
    // TODO: Add a testing endpoint in DataProvider that will be used to simulate errors
}

// Move this part to the Infrastructure.Test.Unit project

// For  you might need to create a mock server (for example using TestServer from ASP.NET Core or WebApplicationFactory or a tool like WireMock) that you can control fully from your tests. But note, using such mock servers often blurs the line between unit tests and integration tests.

    // [Fact]
    // public async Task GetRecipesAsync_ReturnsRecipes()
    // {
    //     // Arrange
    //     var expectedRecipes = new List<RecipeDto>
    //     {
    //         new RecipeDto { Title = "Recipe 1", Id = Guid.NewGuid()},
    //         new RecipeDto { Title = "Recipe 2", Id = Guid.NewGuid()},
    //     };
    //
    //     var handler = new Mock<HttpMessageHandler>();
    //     // handler.SetupRequest(HttpMethod.Get, _fixture.Client._httpClient.BaseAddress.AbsoluteUri + "/v1/recipes")
    //     //        .ReturnsResponse(JsonSerializer.Serialize(expectedRecipes), "application/json");
    //
    //     handler.SetupAnyRequest()
    //         .ReturnsResponse(JsonSerializer.Serialize(expectedRecipes), "application/json");
    //
    //     var httpClient = new HttpClient(handler.Object)
    //     {
    //         BaseAddress = new Uri(_fixture.Configuration["DataSources:DataProvider:Host"]!)
    //     };
    //
    //     var logger = LoggerFactory
    //         .Create(builder => builder.AddConsole())
    //         .CreateLogger<DataProviderClient>();
    //
    //     var options = Microsoft.Extensions.Options.Options.Create(new DataProviderOptions
    //     {
    //         Host = _fixture.Configuration["DataSources:DataProvider:Host"]!,
    //         Endpoints = new Dictionary<string, string>
    //         {
    //             {"Recipes", _fixture.Configuration["DataSources:DataProvider:Endpoints:Recipes"]!}
    //         },
    //         ApiKey = _fixture.Configuration["DataSources:DataProvider:ApiKey"]!
    //     });
    //
    //     var client = new DataProviderClient(httpClient, options, logger);
    //
    //     // Act
    //     var actualRecipes = await client.GetRecipesAsync();
    //
    //     // Assert
    //     Assert.NotNull(actualRecipes);
    //     Assert.Equal(expectedRecipes.Count, actualRecipes.Count);
    //     for (var i = 0; i < expectedRecipes.Count; i++)
    //     {
    //         Assert.Equal(expectedRecipes[i].Id, actualRecipes[i].Id);
    //         Assert.Equal(expectedRecipes[i].Title, actualRecipes[i].Title);
    //         // Add more assertions for other properties
    //     }
    // }
// [Fact]
// public async Task GetRecipesAsync_HandlesNetworkFailure()
// {
//     // Arrange: Configure a HttpClient that will simulate a network failure
//     var policy = Policy<HttpResponseMessage>
//         .HandleResult(msg => !msg.IsSuccessStatusCode)  // This handles unsuccessful status codes
//         .Or<Exception>()
//         .RetryAsync(3);
//
//     var httpClient = new HttpClient(new PolicyHttpMessageHandler(policy)
//     {
//         InnerHandler = new HttpClientHandler() // This is the last handler in the chain
//     })
//     {
//         BaseAddress = new Uri(_fixture.Configuration["DataSources:DataProvider:Host"]!)
//     };
//
//     var logger = LoggerFactory
//         .Create(builder => builder.AddConsole())
//         .CreateLogger<DataProviderClient>();
//     
//     var options = Microsoft.Extensions.Options.Options.Create(new DataProviderOptions
//     {
//         Host = _fixture.Configuration["DataSources:DataProvider:Host"]!,
//         Endpoints = new Dictionary<string, string>
//         {
//             {"Recipes", _fixture.Configuration["DataSources:DataProvider:Endpoints:Recipes"]!}
//         },
//         ApiKey = _fixture.Configuration["DataSources:DataProvider:ApiKey"]!
//     });
//
//     var client = new DataProviderClient(httpClient, options, logger);
//
//     // Act
//     var result = await client.GetRecipesAsync();
//
//     // Assert: Check that the result is null or that the appropriate error handling has occurred
//     Assert.Null(result);
// }
