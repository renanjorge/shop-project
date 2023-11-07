using FluentValidation.TestHelper;
using shop.domain.Models.DTOs.Product;
using shop.domain.Validators;

namespace shop.unitTest.shop.domain.Validators;

[Trait("shop.domain", "")]
public class ProductRequestBodyValidatorTest
{
    private ProductRequestBodyValidator _validator;

    public ProductRequestBodyValidatorTest()
    {
        _validator = new ProductRequestBodyValidator();
    }

    [Theory(DisplayName = "Validate invalid product request bodies")]
    [MemberData(nameof(InvalidProductRequestBodiesMemberData.GetProductRequestBodies), MemberType = typeof(InvalidProductRequestBodiesMemberData))]
    public void Validate_InvalidProductRequestBodies_When_ProductRequestBodyIsSent_Then_ShowError(ProductRequestBody productRequestBody)
    {
        // Act
        var response = _validator.TestValidate(productRequestBody);

        // Assert
        response.ShouldHaveValidationErrorFor(r => r.Name);
        response.ShouldHaveValidationErrorFor(r => r.Description);
        response.ShouldHaveValidationErrorFor(r => r.ProductCategoryId);
    }

    [Fact(DisplayName = "Validate valid product request body")]
    public void Validate_ValidProductRequestBodies_When_ProductRequestBodyIsSent_Then_Ok()
    {
        // Arrange
        var productRequestBody = new ProductRequestBody 
        { 
            Name = "Teste 123",
            Description = "Teste 123",
            ProductCategoryId = 1
        };

        // Act
        var response = _validator.TestValidate(productRequestBody);

        // Assert
        response.ShouldNotHaveAnyValidationErrors();
    }
}