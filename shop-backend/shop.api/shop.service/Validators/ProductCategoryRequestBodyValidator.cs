using FluentValidation;
using shop.service.DTOs.ProductCategory;
using shop.domain.Extensions;

namespace shop.service.Validators;

public class ProductCategoryRequestBodyValidator : AbstractValidator<ProductCategoryRequestBody>
{
    public ProductCategoryRequestBodyValidator()
    {
        RuleFor(productCategory => productCategory.Name)
            .Must(name => name.IsNotNullOrEmpty())
                .WithMessage("'Name' não deve ser nulo ou vazio")
            .MaximumLength(250)
            .MinimumLength(5);

        RuleFor(productCategory => productCategory.Description)
            .Must(description => description.IsNotNullOrEmpty())
                .WithMessage("'Description' não deve ser nulo ou vazio")
            .MaximumLength(250)
            .MinimumLength(5);
    }
}
