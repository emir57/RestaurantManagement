namespace Services.ProductDetail.Application.Features.ProductDetail.Dtos;

public sealed class ReadProductsDetailDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public ReadFeatureDto Feature { get; set; }
    public string LongDescription { get; set; }
    public ICollection<ReadProductExtrasDto> ProductExtras { get; set; }
}

public sealed class ListReadProductsDetailDto
{
    public IList<ReadProductsDetailDto> ListProductsDetailDtos { get; set; }
}
