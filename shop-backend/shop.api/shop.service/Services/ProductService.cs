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
}