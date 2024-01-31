using shop.domain.Entities;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;

namespace shop.service.Interfaces;

public interface IProductCategoryService : IService<ProductCategory>
{
    public Task<PagedList<ProductCategoryResponse>> GetAll(ProductCategoryParameters parameters);
}