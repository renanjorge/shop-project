using shop.domain.Interfaces.Repositories;
using shop.domain.Interfaces.Services;
using shop.domain.Models.DTOs;
using shop.domain.Models.DTOs.Product;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;

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