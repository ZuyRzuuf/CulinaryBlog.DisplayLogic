using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;

namespace DisplayLogic.Domain.Types;

public class ArticleType : ObjectType<Article>
{
    protected override void Configure(IObjectTypeDescriptor<Article> descriptor)
    {
        descriptor.Field(a => a.Uuid).Type<NonNullType<UuidType>>();
        descriptor.Field(a => a.Title).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Content).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Author).Type<NonNullType<AuthorType>>();
        descriptor.Field(a => a.PublishedDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(a => a.ImageUrl).Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Tags).Type<NonNullType<ListType<NonNullType<TagType>>>>();

        descriptor
            .Field("comments")
            .Type<NonNullType<ListType<NonNullType<CommentType>>>>()
            .ResolveWith<ICommentResolver>(r => r.GetCommentsByArticleId(default!));
    }
}