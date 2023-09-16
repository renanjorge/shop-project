using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain.Models.Entities;

namespace shop.infra.data.Mapping;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("tblProduto")
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

        builder.Property(c => c.IsPerishable)
               .IsRequired()
               .HasColumnName("Perecivel")
               .HasColumnType("bit");

        builder.Property(c => c.ProductCategoryId)
               .IsRequired()
               .HasColumnName("CategoriaId");

        builder.HasOne(c => c.ProductCategory)
               .WithMany()
               .HasForeignKey(c => c.ProductCategoryId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
