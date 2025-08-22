using FinancePlanner.Common.Utilities.DateTimeUtil;
using FinancePlanner.Commands.Wage.Application;
using FinancePlanner.Commands.Wage.Domain.Handlers;
using FinancePlanner.Commands.Wage.Repository;
using Microsoft.OpenApi.Models;

namespace FinancePlanner.Queries.Wage.API;

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


        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        // builder.Services.AddOpenApi();

        
        builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        builder.Services.AddSingleton<IDatabaseQuery>(new DatabaseQuery("User ID=root;Password=root;Host=postgres-master;Port=5432;Database=root;"));
        builder.Services.AddSingleton<IWageRepository, WageRepository>();
        builder.Services.AddSingleton<IWageService, WageService>();

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

        FinancePlanner.Commands.Wage.DatabaseMigration.Program.Main(args);

        app.Run();
    }
}