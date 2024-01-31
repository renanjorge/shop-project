using System.ComponentModel.DataAnnotations;
using shop.domain.Extensions;

namespace shop.service.DTOs.ProductCategory;

public class ProductCategoryRequestBody
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    private bool IsActive { get { return true; } }

    internal bool IsNotNullOrEmpty()
    {
        throw new NotImplementedException();
    }

    #region implicit operator
    public static implicit operator domain.Entities.ProductCategory(ProductCategoryRequestBody requestBody)
    {
        if (requestBody.IsNull()) return null;

        return new domain.Entities.ProductCategory
        {
            Name = requestBody.Name,
            Description = requestBody.Description,
            IsActive = requestBody.IsActive
        };
    }
    #endregion
}
