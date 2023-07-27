using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class ArticleTypeTests
{
    [Fact]
    public void ArticleType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<ArticleType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<ArticleType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void ArticleType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<ArticleType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Article").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "title" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "content" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "author" && x.Type.NamedType().Name.Equals("Author"));
        Assert.Contains(fields, x => x.Name == "publishedDate" && x.Type.NamedType().Name.Equals("DateTime"));
        Assert.Contains(fields, x => x.Name == "imageUrl" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "tags" && x.Type.NamedType().Name.Equals("Tag"));
        Assert.Contains(fields, x => x.Name == "comments" && x.Type.NamedType().Name.Equals("Comment"));
    }
}