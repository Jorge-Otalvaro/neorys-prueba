using ClientePersonaMicroservicio.Api.ApiHandlers;
using ClientePersonaMicroservicio.Api.Filters;
using ClientePersonaMicroservicio.Api.Middleware;
using FluentValidation;
using ClientePersonaMicroservicio.Infrastructure.DataSource;
using ClientePersonaMicroservicio.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Elasticsearch;
using Prometheus;
using ClientePersonaMicroservicio.Api.Automapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(config.GetConnectionString("DefaultConnection"), options =>
    {
        options.UseRelationalNulls();
        options.EnableRetryOnFailure();
        options.CommandTimeout(60);
        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(2), null);
        options.MigrationsAssembly(typeof(DataContext).Assembly.FullName);
    });
});


builder.Services.AddHealthChecks()
    .AddDbContextCheck<DataContext>()
    .ForwardToPrometheus();

builder.Services.AddDomainServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.Load("ClientePersonaMicroservicio.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(EntityProfile));

builder.Host.UseSerilog((_, loggerConfiguration) =>
    loggerConfiguration
        .WriteTo.Console()
        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config.GetValue<string>("esUrl")!))
        {
            TypeName = null,
            ModifyConnectionSettings = cx => cx.ServerCertificateValidationCallback((_, _, _, _) => true),
            AutoRegisterTemplate = true,
            IndexFormat = "dotnet-ms-{0:yyyy-MM-dd}",
        }));

SelfLog.Enable(Console.Error);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpMetrics();

app.UseMiddleware<AppExceptionHandlerMiddleware>();

app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.UseRouting().UseEndpoints(endpoint => {
    endpoint.MapMetrics();
});

app.MapGroup("/api").MapRoutes().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);

app.UseRouting();

app.Run();