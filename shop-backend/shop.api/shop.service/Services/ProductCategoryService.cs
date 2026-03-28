using AutoMapper;
using shop.domain.Interfaces;
using shop.domain.Entities;
using shop.service.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;

namespace shop.service.Services;

public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _productCategoryRepository = repository;
    }

    public async Task<PagedList<ProductCategoryResponse>> GetAll(ProductCategoryParameters parameters)
    {
        IList<ProductCategory> productCategories = await _productCategoryRepository.SelectWith(parameters);
        int total = await _productCategoryRepository.Total();

        IEnumerable<ProductCategoryResponse> productCategoriesResponse = productCategories
            .Select(productCategory => _mapper.Map<ProductCategoryResponse>(productCategory));

        return new PagedList<ProductCategoryResponse>(productCategoriesResponse, parameters.PageNumber, parameters.PageSize, total);
    }
}