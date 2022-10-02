namespace Services.ProductDetail.Application.Features.ProductDetail.Dtos;

public sealed class WriteProductDto
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public WriteFeatureDto Feature { get; set; }
}
