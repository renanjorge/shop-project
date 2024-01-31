using FluentValidation;
using shop.service.DTOs.Product;
using shop.domain.Extensions;

namespace shop.service.Validators;

public class ProductRequestBodyValidator : AbstractValidator<ProductRequestBody>
{
    public ProductRequestBodyValidator()
    {
        RuleFor(product => product.Name)
            .Must(name => name.IsNotNullOrEmpty())
                .WithMessage("'Name' não deve ser nulo ou vazio")
            .MaximumLength(250)
            .MinimumLength(5);

        RuleFor(product => product.Description)
            .Must(description => description.IsNotNullOrEmpty())
                .WithMessage("'Description' não deve ser nulo ou vazio")
            .MaximumLength(250)
            .MinimumLength(5);

        RuleFor(product => product.ProductCategoryId)
           .GreaterThan(0);
    }
}