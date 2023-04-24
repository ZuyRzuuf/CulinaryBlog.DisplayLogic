using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

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
        
        descriptor.Field<BlogData>(f => f.Article)
            .Type<ArticleType>()
            .Argument("articleId", a => a.Type<NonNullType<IdType>>())
            .Resolve(ctx =>
            {
                var articleId = ctx.ArgumentValue<Guid>("articleId");
                var articleResolver = ctx.Service<IArticleResolver>();
                var article = articleResolver.GetArticleById(articleId);

                if (article != null) return article;
                
                ctx.ReportError(ErrorBuilder.New()
                    .SetMessage($"Article with id {articleId} not found.")
                    .SetCode("ARTICLE_NOT_FOUND")
                    .Build());
                
                return null;
            });
    }
}