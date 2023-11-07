using shop.domain.Models.Entities;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

public class ProductCategoryStub
{
    public static IList<ProductCategory> GetProductCategoriesForFilterTesting()
    {
        return new List<ProductCategory>
        {
            new ProductCategory
            {
                Name = "Eletrônico",
                IsActive = false
            },
            new ProductCategory
            {
                Name = "Alimento",
                IsActive = true
            },
            new ProductCategory
            {
                Name = "Livro",
                IsActive = true
            },
            new ProductCategory
            {
                Name = "Moda",
                IsActive = true
            }
        };
    }
}
