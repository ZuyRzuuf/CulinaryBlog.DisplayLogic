using DisplayLogic.Domain.Filters;

namespace DisplayLogic.Domain.Types;

public class ArticleFilterInputType : InputObjectType<ArticleFilter>
{
    /// <inheritdoc />
    protected override void Configure(IInputObjectTypeDescriptor<ArticleFilter> descriptor)
    {
        descriptor
            .Name("ArticleFilter");
        
        descriptor
            .Field(f => f.Ids)
            .Type<ListType<UuidType>>()
            .Name("articleIds");
        
        descriptor
            .Field(f => f.TagIds)
            .Type<ListType<UuidType>>()
            .Name("tagIds");
        
        descriptor
            .Field(f => f.Id)
            .Type<UuidType>()
            .Name("articleId");
    }
}