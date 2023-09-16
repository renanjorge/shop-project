using shop.domain.Models.DTOs;
using shop.domain.Models.DTOs.Product;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

namespace shop.domain.Interfaces.Services;

public interface IProductService : IService<Product>
{
    public Task<PagedList<ProductResponse>> GetAll(ProductParameters parameters);
}
