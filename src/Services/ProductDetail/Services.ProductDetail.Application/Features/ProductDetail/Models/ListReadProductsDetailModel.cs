using Services.ProductDetail.Application.Features.ProductDetail.Dtos;

namespace Services.ProductDetail.Application.Features.ProductDetail.Models;

public sealed class ListReadProductsDetailModel
{
    public IList<ReadProductsDetailDto> Items { get; set; }
}
