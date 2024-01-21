using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using shop.domain.Validators;

namespace shop.infra.crossCutting.Startup;
public static class FluentValidation
{
    public static void AddFluentValidationAuto(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProductRequestBodyValidator>();

        services.AddFluentValidationAutoValidation();
    }
}
