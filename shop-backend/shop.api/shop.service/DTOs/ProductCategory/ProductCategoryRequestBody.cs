using System.ComponentModel.DataAnnotations;

namespace shop.service.DTOs.ProductCategory;

public class ProductCategoryRequestBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }
}
