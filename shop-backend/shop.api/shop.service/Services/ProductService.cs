using AutoMapper;
using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;
using shop.service.Interfaces;

namespace shop.service.Services;

public class ProductService : BaseService<Product>, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
        _productRepository = productRepository;
    }

    public async Task<PagedList<ProductResponse>> GetAll(ProductParameters parameters)
    {
        IList<Product> products = await _productRepository.SelectWith(parameters);
        int total = await _productRepository.Total();

        IEnumerable<ProductResponse> productsResponse = products
            .Select(product => _mapper.Map<ProductResponse>(product));

        return new PagedList<ProductResponse>(productsResponse, parameters.PageNumber, parameters.PageSize, total);
    }

    async Task<ProductResponse?> IProductService.GetById(int id)
    {
        Product? entity = await base.GetById(id);
        return entity is not null ? _mapper.Map<ProductResponse>(entity) : null;
    }

    async Task<ProductResponse> IProductService.Add(ProductRequestBody requestBody)
    {
        Product newProduct = _mapper.Map<Product>(requestBody);
        Product created = await base.Add(newProduct);

        Product? createdWithCategory = await base.GetById(created.Id);
        return _mapper.Map<ProductResponse>(createdWithCategory);
    }

    async Task<ProductResponse?> IProductService.Update(int id, ProductRequestBody requestBody)
    {
        Product newProduct = _mapper.Map<Product>(requestBody);
        Product? updated = await base.Update(id, newProduct);
        return updated is not null ? _mapper.Map<ProductResponse>(updated) : null;
    }

    async Task<ProductResponse?> IProductService.Delete(int id)
    {
        Product? deleted = await base.Delete(id);
        return deleted is not null ? _mapper.Map<ProductResponse>(deleted) : null;
    }
}