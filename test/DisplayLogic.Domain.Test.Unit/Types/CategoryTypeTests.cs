using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class CategoryTypeTests
{
    [Fact]
    public void CategoryType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<CategoryType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<CategoryType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }

    // Add ArticleType_Fields_ExistAndAreCorrectType
    [Fact]
    public void CategoryType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<CategoryType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Category").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "name" && x.Type.NamedType().Name.Equals("String"));
    }
}