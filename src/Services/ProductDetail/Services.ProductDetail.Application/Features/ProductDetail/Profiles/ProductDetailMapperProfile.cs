using AutoMapper;
using Services.ProductDetail.Application.Features.ProductDetail.Commands.CreateProductsDetail;
using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Features.ProductDetail.Profiles;

public sealed class ProductDetailMapperProfile : Profile
{
    public ProductDetailMapperProfile()
    {
        CreateMap<ProductsDetail, CreateProductsDetailCommand>().ReverseMap();
    }
}
