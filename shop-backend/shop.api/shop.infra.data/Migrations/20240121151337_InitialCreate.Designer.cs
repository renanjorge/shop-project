﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shop.infra.data.Context;

#nullable disable

namespace shop.infra.data.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20240121151337_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("shop.domain.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<bool>("IsPerishable")
                        .HasColumnType("bit")
                        .HasColumnName("Perecivel");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Nome");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("tblProduto", (string)null);
                });

            modelBuilder.Entity("shop.domain.Models.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("tblCategoriaProduto", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Eletrodomésticos",
                            IsActive = true,
                            Name = "Eletrônico"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Produtos para Informática",
                            IsActive = true,
                            Name = "Informática"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Aparelhos e acessórios",
                            IsActive = true,
                            Name = "Celulares"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Artigos para vestuário em geral",
                            IsActive = true,
                            Name = "Moda"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Livros",
                            IsActive = true,
                            Name = "Livros"
                        });
                });

            modelBuilder.Entity("shop.domain.Models.Entities.Product", b =>
                {
                    b.HasOne("shop.domain.Models.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
