using shop.domain.Entities;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;

namespace shop.service.Interfaces;

public interface IProductService : IService<Product>
{
    public Task<PagedList<ProductResponse>> GetAll(ProductParameters parameters);
}
