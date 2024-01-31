using shop.domain.Interfaces;
using shop.domain.Entities;
using shop.service.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;

namespace shop.service.Services;

public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryService(IProductCategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<PagedList<ProductCategoryResponse>> GetAll(ProductCategoryParameters parameters)
    {
        IList<ProductCategory> productCategories = await _repository.SelectWith(parameters);
        int total = await _repository.Total();

        IEnumerable<ProductCategoryResponse> productCategoriesResponse = productCategories
            .Select(productCategory => (ProductCategoryResponse) productCategory);

        return new PagedList<ProductCategoryResponse>(productCategoriesResponse, parameters.PageNumber, parameters.PageSize, total);
    }
}