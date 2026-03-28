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

    async Task<ProductCategoryResponse?> IProductCategoryService.GetById(int id)
    {
        ProductCategory? entity = await base.GetById(id);
        return entity is not null ? _mapper.Map<ProductCategoryResponse>(entity) : null;
    }

    async Task<ProductCategoryResponse> IProductCategoryService.Add(ProductCategoryRequestBody requestBody)
    {
        ProductCategory newCategory = _mapper.Map<ProductCategory>(requestBody);
        ProductCategory created = await base.Add(newCategory);
        return _mapper.Map<ProductCategoryResponse>(created);
    }

    async Task<ProductCategoryResponse?> IProductCategoryService.Update(int id, ProductCategoryRequestBody requestBody)
    {
        ProductCategory newCategory = _mapper.Map<ProductCategory>(requestBody);
        ProductCategory? updated = await base.Update(id, newCategory);
        return updated is not null ? _mapper.Map<ProductCategoryResponse>(updated) : null;
    }

    async Task<ProductCategoryResponse?> IProductCategoryService.Delete(int id)
    {
        ProductCategory? deleted = await base.Delete(id);
        return deleted is not null ? _mapper.Map<ProductCategoryResponse>(deleted) : null;
    }
}