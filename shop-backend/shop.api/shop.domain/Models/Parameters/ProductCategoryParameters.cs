namespace shop.domain.Models.Parameters;

public class ProductCategoryParameters : PagedListParameters
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}