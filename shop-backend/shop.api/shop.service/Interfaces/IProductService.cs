using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;

namespace shop.service.Interfaces;

public interface IProductService
{
    Task<PagedList<ProductResponse>> GetAll(ProductParameters parameters);
    Task<ProductResponse?> GetById(int id);
    Task<ProductResponse> Add(ProductRequestBody requestBody);
    Task<ProductResponse?> Update(int id, ProductRequestBody requestBody);
    Task<ProductResponse?> Delete(int id);
}
