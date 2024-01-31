using shop.domain.Parameters;
using shop.infra.data.FilterDefinitions.LambdaFilter;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

[Trait("shop.infra.data", "")]
public class ProductCategoryLambadaFilterTest
{
    [Theory(DisplayName = "Build filter from multiple product category parameters")]
    [MemberData(nameof(ProductCategoryParameterMemberData.GetDataProductCategoryParameters), MemberType = typeof(ProductCategoryParameterMemberData))]
    public void Given_ProductCategoryParameters_When_ApplyingFilter_Then_ExpectedResults(
        ProductCategoryParameters parameter, 
        int totalExpected)
    {
        // Arrange
        var productCategories = ProductCategoryStub.GetProductCategoriesForFilterTesting();

        // Act
        var filter = ProductCategoryLambdaFilter.Build(parameter);
        var totalActual = productCategories.Count(filter.Compile().Invoke);

        //Assert
        Assert.Equal(totalExpected, totalActual);
    }
}
