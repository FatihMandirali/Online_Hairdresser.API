using Elastic.Apm.NetCoreAll;
using Microsoft.Extensions.Options;
using Online_Hairdresser.API.Extensions;
using Online_Hairdresser.API.Extensions.SeedData;
using Online_Hairdresser.Data;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Online_Hairdresser.API.Middleware;

// dotnet ef --startup-project ../Online_Hairdresser.API/ migrations add EditTables --context OnlineHairdresserDbContext

var builder = WebApplication.CreateBuilder(args);

ConfigureLogging();

//var configuration = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json")
//        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
//        .Build();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(configuration).Enrich.FromLogContext()
//    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.ServiceCollectionExtension(builder.Configuration);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = app.Services.CreateScope())
{
    await scope.ServiceProvider.GetRequiredService<OnlineHairdresserDbContext>().DatabaseMigrator();
}

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizationOptions.Value);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAllElasticApm(builder.Configuration);
app.UseCors("corsapp");

app.UseMiddleware<ExceptionCatcherMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{"onlinehairdresser"}-{DateTime.UtcNow:yyyy-MM}"
    };
}
