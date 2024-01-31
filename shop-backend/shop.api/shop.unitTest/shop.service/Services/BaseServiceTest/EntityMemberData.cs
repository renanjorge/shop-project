using AutoFixture;
using shop.domain.Entities;

namespace shop.unitTest.shop.service;

public class EntityMemberData
{
    public static IEnumerable<object[]> GetData()
    {
        yield return new object[] 
        {
            new Fixture().Create<Product>()
        };

        yield return new object[]
        {
            new Fixture().Create<ProductCategory>()
        };
    }
}