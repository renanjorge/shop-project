using shop.domain.Entities;
using shop.domain.Parameters;

namespace shop.domain.Interfaces;

public interface IProductCategoryRepository : IRepository<ProductCategory>
{
    public Task<IList<ProductCategory>> SelectWith(ProductCategoryParameters parameters);
}