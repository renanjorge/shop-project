using Microsoft.EntityFrameworkCore;
using shop.domain.Extensions;
using shop.infra.data.Context;

namespace shop.api.Extensions.Startup;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");

        var connectionString = string.Empty;
        if (dbHost.IsNull())
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        else
        {
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

            connectionString = $"Server={dbHost},{dbPort};" +
                               $"Database={dbName};" +
                               $"User Id={dbUser};" +
                               $"Password={dbPassword};" +
                               $"TrustServerCertificate=True";
        }

        services.AddDbContext<ShopContext>(options =>
        {
            options.UseSqlServer(connectionString,
            mgr => mgr.MigrationsAssembly("shop.infra.data"));
        });

        return services;
    }
}
