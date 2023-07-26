using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Filters;
using DisplayLogic.Domain.Interfaces;
using DisplayLogic.Domain.Types;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;

namespace DisplayLogic.Domain.Test.Unit.Types;

public class BlogDataTypeTests
{
    [Fact]
    public void BlogDataType_Fields_ExistAndAreCorrectType()
    {
        // Arrange
        var schema = SchemaBuilder.New()
            .AddQueryType<QueryType>()
            .AddType<BlogDataType>()
            .AddType<ArticleType>()
            .AddType<RecipeType>()
            .Create();

        // Act
        var fields = schema.GetType<ObjectType>("BlogData").Fields;

        // Assert
        Assert.Contains(fields, x => x.Name == "articles" && x.Type.IsListType() && x.Type.ListType().ElementType.NamedType().Name.Equals("Article"));
        Assert.Contains(fields, x => x.Name == "recipes" && x.Type.IsListType() && x.Type.ListType().ElementType.NamedType().Name.Equals("Recipe"));
        Assert.Contains(fields, x => x.Name == "article" && x.Type.NamedType().Name.Equals("Article"));
        Assert.Contains(fields, x => x.Name == "recipe" && x.Type.NamedType().Name.Equals("Recipe"));
    }
}