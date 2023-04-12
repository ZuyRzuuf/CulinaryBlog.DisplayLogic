using DisplayLogic.Domain.Entities;
using DisplayLogic.Domain.ExtensionMethods;
using DisplayLogic.Domain.Types;
using DisplayLogic.Infrastructure.ExtensionMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDomainServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

builder.Services
    .AddGraphQLServer()
//     .AddType(new UuidType('D'))
//     .AddDocumentFromString(@"
//         type Query {
//             GetRecipesList(): Recipes
//         }
//
//         type Recipe {
//             uuid: Uuid!
//             title: String!
//         }
//         type Recipes {
//             book: [Recipe!]
//         }
//     ")
//     .BindRuntimeType<Recipe>()
//     .BindRuntimeType<Query>();
    .AddQueryType<QueryType>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();