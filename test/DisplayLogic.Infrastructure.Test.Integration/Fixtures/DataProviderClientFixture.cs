using System.Net.Http.Headers;
using DisplayLogic.Infrastructure.DataClients;
using DisplayLogic.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Infrastructure.Test.Integration.Fixtures;

public class DataProviderClientFixture : IDisposable
{
    public DataProviderClient Client { get; }
    public IConfiguration Configuration { get; }

    public DataProviderClientFixture()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", optional: false, reloadOnChange: true)
            .Build();

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(Configuration["DataSources:DataProvider:Host"]!)
        };
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        var logger = LoggerFactory
            .Create(builder => builder.AddConsole())
            .CreateLogger<DataProviderClient>();
    
        var options = Microsoft.Extensions.Options.Options.Create(new DataProviderOptions
        {
            Host = Configuration["DataSources:DataProvider:Host"]!,
            Endpoints = new Dictionary<string, string>
            {
                {"Recipes", Configuration["DataSources:DataProvider:Endpoints:Recipes"]!}
            },
            ApiKey = Configuration["DataSources:DataProvider:ApiKey"]!
        });
    
        Client = new DataProviderClient(httpClient, options, logger);
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }
}