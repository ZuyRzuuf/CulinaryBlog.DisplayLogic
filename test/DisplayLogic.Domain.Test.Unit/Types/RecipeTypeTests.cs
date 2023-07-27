using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class RecipeTypeTests
{
    [Fact]
    public void RecipeType_Schema_Snapshot()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddGraphQLServer()
            .AddQueryType<QueryType>()
            .AddType<RecipeType>()
            .Services
            .BuildServiceProvider();

        var schema = SchemaBuilder.New()
            .AddServices(services)
            .AddQueryType<QueryType>()
            .AddType<RecipeType>()
            .Create();

        // Assert
        schema.ToString().MatchSnapshot();
    }
    
    [Fact]
    public void RecipeType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<RecipeType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("Recipe").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "id" && x.Type.NamedType().Name.Equals("UUID"));
        Assert.Contains(fields, x => x.Name == "title" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "ingredients" && x.Type.NamedType().Name.Equals("Ingredient"));
        Assert.Contains(fields, x => x.Name == "instructions" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "author" && x.Type.NamedType().Name.Equals("Author"));
        Assert.Contains(fields, x => x.Name == "publishedDate" && x.Type.NamedType().Name.Equals("DateTime"));
        Assert.Contains(fields, x => x.Name == "imageUrl" && x.Type.NamedType().Name.Equals("String"));
        Assert.Contains(fields, x => x.Name == "category" && x.Type.NamedType().Name.Equals("Category"));
        Assert.Contains(fields, x => x.Name == "cuisine" && x.Type.NamedType().Name.Equals("Cuisine"));
        Assert.Contains(fields, x => x.Name == "diet" && x.Type.NamedType().Name.Equals("Diet"));
        Assert.Contains(fields, x => x.Name == "method" && x.Type.NamedType().Name.Equals("Method"));
        Assert.Contains(fields, x => x.Name == "season" && x.Type.NamedType().Name.Equals("Season"));
        Assert.Contains(fields, x => x.Name == "tags" && x.Type.NamedType().Name.Equals("Tag"));
        Assert.Contains(fields, x => x.Name == "comments" && x.Type.NamedType().Name.Equals("Comment"));
    }
}
