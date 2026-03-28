using AutoMapper;
using shop.domain.Entities;
using shop.service.DTOs.Product;
using shop.service.DTOs.ProductCategory;

namespace shop.service.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ProductMappings();
        ProductCategoryMappings();
    }

    private void ProductMappings()
    {
        CreateMap<Product, ProductResponse>();

        CreateMap<ProductRequestBody, Product>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

        CreateMap<Product, Product>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ProductCategory, opt => opt.Ignore());
    }

    private void ProductCategoryMappings()
    {
        CreateMap<ProductCategory, ProductCategoryResponse>();

        CreateMap<ProductCategoryRequestBody, ProductCategory>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true));

        CreateMap<ProductCategory, ProductCategory>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
