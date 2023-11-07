using LinqKit;
using shop.domain.Models.Parameters;
using shop.infra.data.FilterDefinitions.LambdaFilter;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

[Trait("shop.infra.data", "")]
public class ProductLambdaFilterTest
{
    [Theory(DisplayName = "Build filter from multiple product parameters")]
    [MemberData(nameof(ProductParameterMemberData.GetDataProductParameters), MemberType = typeof(ProductParameterMemberData))]
    public void Given_ProductParameters_When_ApplyingFilter_Then_ExpectedResults(
       ProductParameters parameters, 
       int totalExpected)
    {
        // Arrange
        var products = ProductStub.GetProductsForFilterTesting();

        // Act
        var filter = ProductLambdaFilter.Build(parameters);
        var totalActual = products.Count(filter.Compile().Invoke);

        //Assert
        Assert.Equal(totalExpected, totalActual);
    }
}