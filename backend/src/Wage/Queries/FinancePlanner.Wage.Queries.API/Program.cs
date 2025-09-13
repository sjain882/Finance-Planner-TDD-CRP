using FinancePlanner.Shared.Common.Utilities.DateTimeUtil;
using FinancePlanner.Wage.Queries.Application.WageCalculatorService;
using FinancePlanner.Wage.Queries.Application.WageDataService;
using FinancePlanner.Wage.Queries.Domain.Handlers;
using FinancePlanner.Wage.Queries.Repository;
using Microsoft.OpenApi.Models;

namespace FinancePlanner.Wage.Queries.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(config =>
        {
            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            config.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });
        });

        builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        builder.Services.AddSingleton<IWageService, WageService>();
        builder.Services.AddSingleton<IWageCalculatorService, WageCalculator>();
        builder.Services.AddSingleton<IWageRepository, WageRepository>();
        
        var connectionString = builder.Configuration["Database:Wage"];
        if (connectionString is null)
        {
            throw new NullReferenceException("Database connection string is null");
        }
        builder.Services.AddSingleton<IDatabaseQuery>(
            new DatabaseQuery(connectionString));

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}