using shop.domain.Extensions;
using shop.domain.Models.DTOs.ProductCategory;

namespace shop.domain.Models.DTOs.Product;

public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPerishable { get; set; }

    public virtual ProductCategoryResponse ProductCategory { get; set; }

    #region implicit operator
    public static implicit operator ProductResponse(Entities.Product entity)
    {
        if (entity.IsNull()) return null;

        return new ProductResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            IsActive = entity.IsActive,
            IsPerishable = entity.IsPerishable,
            ProductCategory = entity.ProductCategory ?? new ProductCategoryResponse()
        };
    }
    #endregion
}
