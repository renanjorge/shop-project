using shop.domain.Extensions;

namespace shop.domain.Models.DTOs.ProductCategory;

public class ProductCategoryResponse
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    #region implicit operator
    public static implicit operator ProductCategoryResponse(Entities.ProductCategory entity)
    {
        if (entity.IsNull()) return null;

        return new ProductCategoryResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            IsActive = entity.IsActive,
        };
    }
    #endregion
}
