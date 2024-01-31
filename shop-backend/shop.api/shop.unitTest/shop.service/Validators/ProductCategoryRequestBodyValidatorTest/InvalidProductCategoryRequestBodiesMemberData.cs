using shop.service.DTOs.ProductCategory;

namespace shop.unitTest.shop.service.Validators;

public class InvalidProductCategoryRequestBodiesMemberData
{
    public static IEnumerable<object[]> GetProductCategoryRequestBodies()
    {
        yield return new object[]
        {
            new ProductCategoryRequestBody
            {
                Name = null,
                Description = null
            }
        };

        yield return new object[]
        {
            new ProductCategoryRequestBody
            {
                Name = "",
                Description = ""
            }
        };

        yield return new object[]
        {
            new ProductCategoryRequestBody
            {
                Name = "ABCD",
                Description = "ABCD"
            }
        };

        yield return new object[]
        {
            new ProductCategoryRequestBody
            {
                Name = new string('A', 251),
                Description = new string('A', 251)
            }
       };
    }
}
