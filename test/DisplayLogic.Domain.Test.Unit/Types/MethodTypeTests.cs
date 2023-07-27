using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class MethodTypeTests
{
    [Fact]
    public void MethodType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<MethodType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<MethodType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }

    // Add ArticleType_Fields_ExistAndAreCorrectType
    [Fact]
    public void MethodType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<MethodType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Method").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "name" && x.Type.NamedType().Name.Equals("String"));
    }
}