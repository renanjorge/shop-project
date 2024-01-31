using System.ComponentModel.DataAnnotations.Schema;

namespace shop.domain.Entities;

public class Product : Entity
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsPerishable { get; set; }

    public int ProductCategoryId { get; set; }

    [NotMapped]
    public virtual ProductCategory? ProductCategory { get; set; }
}
