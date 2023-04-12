using DisplayLogic.Domain.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DisplayLogic.Domain.ExtensionMethods;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddType<ArticleType>()
            .AddType<RecipeType>()
            .AddType<AuthorType>()
            .AddType<TagType>()
            .AddType<CommentType>()
            .AddType<IngredientType>()
            .AddType<CategoryType>()
            .AddType<CuisineType>()
            .AddType<MethodType>()
            .AddType<SeasonType>()
            .AddType<DietType>()
            // .AddType<CommentsType>()
            ;

        return services;
    }
}