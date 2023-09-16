using Microsoft.OpenApi.Models;
using shop.api.Extensions.Startup;
using shop.infra.crossCutting.IoC;
using shop.infra.crossCutting.Middleware.ExceptionHandlerMiddleware;
using System.Reflection;

namespace shop.api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        builder.Services.AddCustomizedDatabase(builder.Configuration);
        builder.Services.RegisterServices();
        builder.Services.AddControllers();
        builder.Services.AddFluentValidationAuto();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(doc => 
        {
            doc.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0.0",
                Title = "Produto API",
                Description = "ASP.NET Core Web API para gerenciamento de produtos"
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            doc.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();
        app.UseHttpsRedirection();
        app.UseMiddleware<ErrorExceptionHandlerMiddleware>();
        app.UseAuthorization();
        app.MapControllers();
        app.MigrateDatabase();

        app.Run();
    }
}