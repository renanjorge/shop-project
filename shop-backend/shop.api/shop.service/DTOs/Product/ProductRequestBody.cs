using shop.domain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace shop.service.DTOs.Product;

public class ProductRequestBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    private bool IsActive { get { return true; } }

    [Required]
    public bool IsPerishable { get; set; }

    [Required]
    public int ProductCategoryId { get; set; }

    #region implicit operator
    public static implicit operator domain.Entities.Product(ProductRequestBody requestBody)
    {
        if (requestBody.IsNull()) return null;

        return new domain.Entities.Product
        {
            Name = requestBody.Name,
            Description = requestBody.Description,
            IsActive = requestBody.IsActive,
            IsPerishable = requestBody.IsPerishable,
            ProductCategoryId = requestBody.ProductCategoryId
        };
    }
    #endregion
}