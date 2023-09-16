using FluentValidation;
using shop.domain.Extensions;
using shop.domain.Models.DTOs.Product;

namespace shop.domain.Validators;

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