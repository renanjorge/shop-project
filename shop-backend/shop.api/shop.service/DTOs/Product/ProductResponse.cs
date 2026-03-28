using shop.service.DTOs.ProductCategory;

namespace shop.service.DTOs.Product;

public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPerishable { get; set; }

    public virtual ProductCategoryResponse ProductCategory { get; set; }
}
