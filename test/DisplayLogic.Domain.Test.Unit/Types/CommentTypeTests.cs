using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class CommentTypeTests
{
    // Create CommentType_Schema_Snapshot
    [Fact]
    public void CommentType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<CommentType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<CommentType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }
    
    [Fact]
    public void CommentType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<CommentType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Comment").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "content" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "author" && x.Type.NamedType().Name.Equals("Author"));
        Assert.Contains(fields, x => x.Name == "createdAt" && x.Type.NamedType().Name.Equals("DateTime"));
        Assert.Contains(fields, x => x.Name == "articleId" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "recipeId" && x.Type.NamedType().Name.Equals("UUID"));
    }
}