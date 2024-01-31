using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain.Entities;
using shop.infra.data.Extensions.Seeds;

namespace shop.infra.data.Mapping;

public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("tblCategoriaProduto")
               .HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasColumnName("Nome")
               .HasColumnType("varchar(250)")
               .HasMaxLength(250);

        builder.Property(c => c.Description)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasColumnType("varchar(250)")
               .HasMaxLength(250);

        builder.Property(c => c.IsActive)
               .IsRequired()
               .HasColumnName("Ativo")
               .HasColumnType("bit");

        builder.Seed();
    }
}
