using Microsoft.EntityFrameworkCore;
using shop.domain.Entities;
using shop.domain.Interfaces;
using shop.domain.Parameters;
using shop.infra.data.Context;
using shop.infra.data.FilterDefinitions.LambdaFilter;

namespace shop.infra.data.Repositories;

public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(ShopContext context) : base(context) { }

    public async Task<IList<ProductCategory>> SelectWith(ProductCategoryParameters parameters)
    {
        var filter = ProductCategoryLambdaFilter.Build(parameters);

        return await _dbSet.AsTracking()
                           .Where(filter)
                           .OrderByDescending(productCategory => productCategory.Id)
                           .Skip(parameters.Skip()).Take(parameters.Take())
                           .ToListAsync();
    }
}