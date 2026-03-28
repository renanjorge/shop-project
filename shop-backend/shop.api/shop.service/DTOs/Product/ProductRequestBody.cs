using System.ComponentModel.DataAnnotations;

namespace shop.service.DTOs.Product;

public class ProductRequestBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public bool IsPerishable { get; set; }

    [Required]
    public int ProductCategoryId { get; set; }
}