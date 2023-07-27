using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class ArticleFilterInputTypeTests
{
    [Fact]
    public void ArticleFilterInputType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<ArticleFilterInputType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<ArticleFilterInputType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }
    
    [Fact]
    public void ArticleFilterInputType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<ArticleFilterInputType>()
            .Create();

        // Act
        var fields = schema.GetType<InputObjectType>("ArticleFilter").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "articleIds" && x.Type.IsListType() && x.Type.ListType().ElementType.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "tagIds" && x.Type.IsListType() && x.Type.ListType().ElementType.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "tagNames" && x.Type.IsListType() && x.Type.ListType().ElementType.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "articleId" && x.Type.NamedType().Name.Equals("UUID"));
    }
}