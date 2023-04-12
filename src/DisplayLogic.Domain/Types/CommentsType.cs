using DisplayLogic.Domain.Entities;

namespace DisplayLogic.Domain.Types;

public class CommentsType : ObjectType<List<Comment>>
{
    protected override void Configure(IObjectTypeDescriptor<List<Comment>> descriptor)
    {
        descriptor
            .Name("Comments"); // Give this type a unique name

        descriptor
            .Field("items")
            .Type<NonNullType<ListType<NonNullType<CommentType>>>>()
            .Resolve(ctx => ctx.Parent<List<Comment>>());
    }
}