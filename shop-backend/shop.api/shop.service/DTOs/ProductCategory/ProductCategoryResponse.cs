namespace shop.service.DTOs.ProductCategory;

public class ProductCategoryResponse
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
