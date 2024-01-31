using shop.domain.Entities;
using shop.domain.Parameters;

namespace shop.domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    public Task<IList<Product>> SelectWith(ProductParameters parameters);
}