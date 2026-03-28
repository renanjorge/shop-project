using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;

namespace shop.service.Interfaces;

public interface IProductCategoryService
{
    Task<PagedList<ProductCategoryResponse>> GetAll(ProductCategoryParameters parameters);
    Task<ProductCategoryResponse?> GetById(int id);
    Task<ProductCategoryResponse> Add(ProductCategoryRequestBody requestBody);
    Task<ProductCategoryResponse?> Update(int id, ProductCategoryRequestBody requestBody);
    Task<ProductCategoryResponse?> Delete(int id);
}