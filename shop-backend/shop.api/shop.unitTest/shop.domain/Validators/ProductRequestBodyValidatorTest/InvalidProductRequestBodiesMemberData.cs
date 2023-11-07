using shop.domain.Models.DTOs.Product;

namespace shop.unitTest.shop.domain.Validators;

public class InvalidProductRequestBodiesMemberData
{
    public static IEnumerable<object[]> GetProductRequestBodies()
    {
        yield return new object[]
        {
            new ProductRequestBody 
            { 
                Name = null,
                Description = null
            }
        };

        yield return new object[]
        {
            new ProductRequestBody
            {
                Name = "",
                Description = "",
                ProductCategoryId = 0
            }
        };

       yield return new object[]
       {
            new ProductRequestBody
            {
                Name = "ABCD",
                Description = "ABCD"
            }
       };

        yield return new object[]
        {
            new ProductRequestBody
            {
                Name = new string('A', 251),
                Description = new string('A', 251)
            }
       };
    }
}