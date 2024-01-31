using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;
using shop.service.Interfaces;

namespace shop.service.Services;

public class ProductService : BaseService<Product>, IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository) : base(productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<PagedList<ProductResponse>> GetAll(ProductParameters parameters)
    {
        IList<Product> products = await productRepository.SelectWith(parameters);
        int total = await productRepository.Total();

        IEnumerable<ProductResponse> productsResponse = products
            .Select(product => (ProductResponse) product);

        return new PagedList<ProductResponse>(productsResponse, parameters.PageNumber, parameters.PageSize, total);
    }
}