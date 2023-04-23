using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Types;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(f => f.GetArticles(default!))
            .Type<ListType<ArticleType>>()
            .Name("articles");

        descriptor.Field(f => f.GetRecipes(default!))
            .Type<ListType<RecipeType>>()
            .Name("recipes");

        descriptor.Field("blogData")
            .Type<BlogDataType>()
            .Resolve<BlogData>(ctx =>
            {
                var articleResolver = ctx.Service<IArticleResolver>();
                var recipeResolver = ctx.Service<IRecipeResolver>();

                var articles = ctx.Parent<Query>().GetArticles(articleResolver);
                var recipes = ctx.Parent<Query>().GetRecipes(recipeResolver);

                return new BlogData
                {
                    Articles = articles,
                    Recipes = recipes
                };
            });
    }
}