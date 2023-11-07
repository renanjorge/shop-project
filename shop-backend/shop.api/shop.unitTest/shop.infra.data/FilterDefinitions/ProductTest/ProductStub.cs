using shop.domain.Models.Entities;

namespace shop.unitTest.shop.infra.data.FilterDefinitions;

public class ProductStub
{
    public static IList<Product> GetProductsForFilterTesting()
    {
        return new List<Product>
        {
            new Product
            {
                Name = "Notebook",
                IsActive = false,
                IsPerishable = false,
                ProductCategoryId = 1
            },
            new Product
            {
                Name = "Celular",
                IsActive = true,
                IsPerishable = false,
                ProductCategoryId = 1
            },
            new Product
            {
                Name = "Notebook",
                IsActive = true,
                IsPerishable = false,
                ProductCategoryId = 1
            },
            new Product
            {
                Name = "Comida",
                IsActive = true,
                IsPerishable = true,
                ProductCategoryId = 2
            },
            new Product
            {
                Name = "Comida",
                IsActive = false,
                IsPerishable = true,
                ProductCategoryId = 2
            },
            new Product
            {
                Name = "Notebook",
                IsActive = true,
                IsPerishable = false,
                ProductCategoryId = 1
            }
        };
    }
}
