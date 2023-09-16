using FluentValidation;
using FluentValidation.AspNetCore;
using shop.domain.Validators;

namespace shop.api.Extensions.Startup;

public static class ValidatorExtension
{
    public static void AddFluentValidationAuto(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProductRequestBodyValidator>();

        services.AddFluentValidationAutoValidation();
    }
}