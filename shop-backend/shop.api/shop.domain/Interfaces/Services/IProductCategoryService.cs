using shop.domain.Models.DTOs;
using shop.domain.Models.DTOs.ProductCategory;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

namespace shop.domain.Interfaces.Services;

public interface IProductCategoryService : IService<ProductCategory>
{
    public Task<PagedList<ProductCategoryResponse>> GetAll(ProductCategoryParameters parameters);
}