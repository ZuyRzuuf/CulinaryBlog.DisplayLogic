using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class DietTypeTests
{
    [Fact]
    public void DietType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<DietType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<DietType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }

    [Fact]
    public void DietType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<DietType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Diet").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "name" && x.Type.NamedType().Name.Equals("String"));
    }
}