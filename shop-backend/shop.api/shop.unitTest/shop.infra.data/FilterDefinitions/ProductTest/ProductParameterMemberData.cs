using shop.domain.Models.Parameters;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

public class ProductParameterMemberData
{
    public static IEnumerable<object[]> GetDataProductParameters()
    {
        yield return new object[]
        {
            new ProductParameters { Name = "Note", IsActive = true, IsPerishable = false, ProductCategoryId = 1 },
            2
        };

        yield return new object[]
        {
            new ProductParameters { Name = "Comida" },
            2
        };

        yield return new object[]
        {
            new ProductParameters { Name = "Notebook", IsActive = false },
            1
        };

        yield return new object[]
        {
            new ProductParameters { IsActive = true },
            4
        };

        yield return new object[]
        {
            new ProductParameters { IsActive = false, ProductCategoryId = 3 },
            0
        };

        yield return new object[]
        {
           new ProductParameters { Name = "Livro" },
           0
        };

        yield return new object[]
        {
            new ProductParameters(),
            6
        };
    }
}
