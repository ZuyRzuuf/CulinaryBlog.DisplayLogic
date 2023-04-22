using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Resolvers;
using DisplayLogic.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DisplayLogic.Infrastructure.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IArticleService, ArticleService>()
            .AddScoped<IRecipeService, RecipeService>()
            .AddScoped<IRecipeResolver, RecipeResolver>()
            .AddScoped<ICommentService, CommentService>()
            .AddScoped<ICommentResolver, CommentResolver>();

        return services;
    }
}