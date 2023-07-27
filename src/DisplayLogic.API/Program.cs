using DisplayLogic.Domain.ExtensionMethods;
using DisplayLogic.Domain.Types;
using DisplayLogic.Infrastructure.ExtensionMethods;
using DisplayLogic.Infrastructure.Options;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((
        (hostBuilderContext, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(hostBuilderContext.Configuration)));

builder.Services
    .AddOptions<DataProviderOptions>()
    .BindConfiguration("DataSources:DataProvider")
    .ValidateOnStart();

// Add services to the container.
builder.Services.AddAuthorization();
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
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGraphQL();
});

app.Run();

public partial class Program { }
