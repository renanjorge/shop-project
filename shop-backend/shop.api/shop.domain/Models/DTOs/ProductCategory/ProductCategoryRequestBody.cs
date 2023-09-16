using shop.domain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace shop.domain.Models.DTOs.ProductCategory;

public class ProductCategoryRequestBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    private bool IsActive { get { return true; } }

    #region implicit operator
    public static implicit operator Entities.ProductCategory(ProductCategoryRequestBody requestBody)
    {
        if (requestBody.IsNull()) return null;

        return new Entities.ProductCategory
        {
            Name = requestBody.Name,
            Description = requestBody.Description,
            IsActive = requestBody.IsActive
        };
    }
    #endregion
}
