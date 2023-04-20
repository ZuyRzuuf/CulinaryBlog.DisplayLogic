using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace DisplayLogic.Domain.Types;

public class RecipeType : ObjectType<Recipe>
{
    protected override void Configure(IObjectTypeDescriptor<Recipe> descriptor)
    {
        descriptor.Field(f => f.Uuid).Type<NonNullType<UuidType>>();
        descriptor.Field(f => f.Title).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Ingredients).Type<NonNullType<ListType<NonNullType<IngredientType>>>>();
        descriptor.Field(f => f.Instructions).Type<NonNullType<ListType<NonNullType<StringType>>>>();
        descriptor.Field(f => f.Author).Type<NonNullType<AuthorType>>();
        descriptor.Field(f => f.PublishedDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(f => f.ImageUrl).Type<NonNullType<StringType>>();
        descriptor.Field(f => f.Category).Type<NonNullType<CategoryType>>();
        descriptor.Field(f => f.Cuisine).Type<NonNullType<CuisineType>>();
        descriptor.Field(f => f.Diet).Type<NonNullType<DietType>>();
        descriptor.Field(f => f.Method).Type<NonNullType<MethodType>>();
        descriptor.Field(f => f.Season).Type<NonNullType<SeasonType>>();
        descriptor.Field(f => f.Tags).Type<NonNullType<ListType<NonNullType<TagType>>>>();
        descriptor.Field(f => f.Comments).Type<NonNullType<ListType<NonNullType<CommentType>>>>();
        
        descriptor
            .Field("comments")
            .Type<NonNullType<ListType<NonNullType<CommentType>>>>()
            .Resolve(async ctx =>
            {
                try
                {
                    var recipeResolver = ctx.Service<IRecipeResolver>();
                    var comments = await recipeResolver.GetCommentsByRecipeUuidAsync(ctx.Parent<Recipe>().Uuid);
                    return comments;
                }
                catch (Exception ex)
                {
                    var logger = ctx.Service<ILogger<RecipeType>>();
                    logger.LogError(ex, "Error occurred while resolving comments for recipe");
                    throw;
                }
            });
    }
}