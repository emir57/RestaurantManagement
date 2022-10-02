namespace Services.ProductDetail.Application.Features.ProductDetail.Dtos;

public sealed class WriteProductsDetailDto
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public WriteFeatureDto Feature { get; set; }
    public string LongDescription { get; set; }
    public List<WriteProductExtrasDto> ProductExtras { get; set; }
}
