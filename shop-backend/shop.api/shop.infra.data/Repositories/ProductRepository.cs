using Microsoft.EntityFrameworkCore;
using shop.domain.Interfaces.Repositories;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;
using shop.infra.data.Context;
using shop.infra.data.FilterDefinitions.LambdaFilter;

namespace shop.infra.data.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ShopContext context) : base(context) { }

    public async Task<IList<Product>> SelectWith(ProductParameters parameters)
    {
        var filter = ProductLambdaFilter.Build(parameters);

        return await _dbSet.Include(product => product.ProductCategory)
                           .AsNoTracking()
                           .Where(filter)
                           .OrderByDescending(product => product.Id)
                           .Skip(parameters.Skip()).Take(parameters.Take())
                           .ToListAsync();
    }

    public override async Task<Product?> Select(int id)
    {
        return await _dbSet.Include(product => product.ProductCategory)
                           .AsNoTracking()
                           .SingleOrDefaultAsync(product => product.Id == id);
    }
}
