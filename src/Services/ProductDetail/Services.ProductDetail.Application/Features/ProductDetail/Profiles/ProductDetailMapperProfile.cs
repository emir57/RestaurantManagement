using AutoMapper;
using Services.ProductDetail.Application.Features.ProductDetail.Dtos;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Profiles;

public sealed class ProductDetailMapperProfile : Profile
{
    public ProductDetailMapperProfile()
    {
        CreateMap<ProductsDetail, WriteProductsDetailDto>()
            .ReverseMap();

        CreateMap<ProductsDetail, ReadProductsDetailDto>().ReverseMap();

        CreateMap<WriteFeatureDto, Feature>().ReverseMap();

        CreateMap<WriteProductExtrasDto, ProductExtras>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.ExtraId, opt => opt.MapFrom(x => x.Id))
            .ReverseMap();
    }
}
