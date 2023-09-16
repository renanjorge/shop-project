using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

namespace shop.domain.Interfaces.Repositories;

public interface IProductCategoryRepository : IRepository<ProductCategory>
{
    public Task<IList<ProductCategory>> SelectWith(ProductCategoryParameters parameters);
}