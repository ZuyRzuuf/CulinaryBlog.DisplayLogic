using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Infrastructure.DataClients;
using Microsoft.Extensions.DependencyInjection;

namespace DisplayLogic.Infrastructure.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient<IDataProviderClient, DataProviderClient>(config =>
        {
            config.DefaultRequestHeaders.Clear();
        });
        
        return services;
    }
}