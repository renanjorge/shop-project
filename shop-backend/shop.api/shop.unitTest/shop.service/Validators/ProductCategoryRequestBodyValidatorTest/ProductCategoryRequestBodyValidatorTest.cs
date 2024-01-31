using FluentValidation.TestHelper;
using shop.service.DTOs.ProductCategory;
using shop.service.Validators;

namespace shop.unitTest.shop.service.Validators;

[Trait("shop.domain", "")]
public class ProductCategoryRequestBodyValidatorTest
{
    private ProductCategoryRequestBodyValidator _validator;

    public ProductCategoryRequestBodyValidatorTest()
    {
        _validator = new ProductCategoryRequestBodyValidator();
    }

    [Theory(DisplayName = "Validate invalid product category request bodies")]
    [MemberData(nameof(InvalidProductCategoryRequestBodiesMemberData.GetProductCategoryRequestBodies), MemberType = typeof(InvalidProductCategoryRequestBodiesMemberData))]
    public void Validate_InvalidProductCategoryRequestBodies_When_ProductCategoryRequestBodyIsSent_Then_ShowError(ProductCategoryRequestBody productCategoryRequestBody)
    {
        // Act
        var response = _validator.TestValidate(productCategoryRequestBody);

        // Assert
        response.ShouldHaveValidationErrorFor(r => r.Name);
        response.ShouldHaveValidationErrorFor(r => r.Description);
    }

    [Fact(DisplayName = "Validate valid product category request body")]
    public void Validate_ValidProductCategoryRequestBodies_When_ProductCategoryRequestBodyIsSent_Then_Ok()
    {
        // Arrange
        var productCategoryRequestBody = new ProductCategoryRequestBody
        {
            Name = "Teste 123",
            Description = "Teste 123"
        };

        // Act
        var response = _validator.TestValidate(productCategoryRequestBody);

        // Assert
        response.ShouldNotHaveAnyValidationErrors();
    }
}
