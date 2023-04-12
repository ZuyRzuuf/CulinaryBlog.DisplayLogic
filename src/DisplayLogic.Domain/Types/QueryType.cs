using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Types;

public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor.Field(f => f.GetArticles(default))
            .Type<ListType<ArticleType>>()
            .Name("articles");

        descriptor.Field(f => f.GetRecipes(default))
            .Type<ListType<RecipeType>>()
            .Name("recipes");
    }
}