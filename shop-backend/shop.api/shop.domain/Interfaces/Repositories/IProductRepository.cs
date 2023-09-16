using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

namespace shop.domain.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    public Task<IList<Product>> SelectWith(ProductParameters parameters);
}