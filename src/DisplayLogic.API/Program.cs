using DisplayLogic.Domain.ExtensionMethods;
using DisplayLogic.Domain.Types;
using DisplayLogic.Infrastructure.ExtensionMethods;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((
        (hostBuilderContext, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(hostBuilderContext.Configuration)));

// Add services to the container.
builder.Services.AddDomainServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryType>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSerilogRequestLogging();

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