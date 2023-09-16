using Microsoft.EntityFrameworkCore;
using shop.infra.data.Context;

namespace shop.api.Extensions.Startup;

public static class MigrationExtension
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<ShopContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        return host;
    }
}
