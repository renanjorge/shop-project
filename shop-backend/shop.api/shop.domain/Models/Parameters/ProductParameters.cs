namespace shop.domain.Models.Parameters;

public class ProductParameters : PagedListParameters 
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsPerishable { get; set; }
    public int ProductCategoryId { get; set; }
}