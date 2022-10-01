using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Services
{
    public interface IProductDetailService
    {
        Task AddAsync(ProductsDetail productDetail);
        Task UpdateAsync(ProductsDetail productDetail);
        Task DeleteAsync(string id);
    }
}
