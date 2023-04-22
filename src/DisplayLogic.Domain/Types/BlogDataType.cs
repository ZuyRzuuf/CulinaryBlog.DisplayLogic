using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Types;

public class BlogDataType : ObjectType<BlogData>
{
    protected override void Configure(IObjectTypeDescriptor<BlogData> descriptor)
    {
        descriptor.Field(f => f.Articles)
            .Type<ListType<ArticleType>>()
            .Name("articles");

        descriptor.Field(f => f.Recipes)
            .Type<ListType<RecipeType>>()
            .Name("recipes");
    }
}