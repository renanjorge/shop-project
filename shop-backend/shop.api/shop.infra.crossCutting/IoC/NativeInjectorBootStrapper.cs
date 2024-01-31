using Microsoft.Extensions.DependencyInjection;
using shop.domain.Interfaces;
using shop.infra.data.Repositories;
using shop.service.Interfaces;
using shop.service.Services;

namespace shop.infra.crossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        Services(services);
        Repositories(services);
    }

    private static void Services(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
    }

    private static void Repositories(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
    }
}
