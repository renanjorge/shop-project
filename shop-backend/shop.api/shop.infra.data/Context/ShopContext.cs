using Microsoft.EntityFrameworkCore;
using shop.domain.Models.Entities;
using shop.infra.data.Mapping;

namespace shop.infra.data.Context;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ProductCategoryMap());

        base.OnModelCreating(modelBuilder);
    }
}