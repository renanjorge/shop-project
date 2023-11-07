using shop.domain.Models.Parameters;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

public class ProductCategoryParameterMemberData
{
    public static IEnumerable<object[]> GetDataProductCategoryParameters()
    {
        yield return new object[]
        {
           new ProductCategoryParameters(),
           4
        };

        yield return new object[]
        {
            new ProductCategoryParameters { Name = "Ele", IsActive = true }, 
            0
        };

        yield return new object[]
        {
           new ProductCategoryParameters { IsActive = true }, 
           3
        };

        yield return new object[]
        {
           new ProductCategoryParameters { IsActive = false }, 
           1
        };

        yield return new object[]
        {
            new ProductCategoryParameters { Name = "Livro", IsActive = false }, 
            0
        };

        yield return new object[]
        {
            new ProductCategoryParameters { Name = "Modas" },
            0
        };
    }
}
