using Services.ProductDetail.Domain.Entities;

namespace Services.ProductDetail.Application.Services
{
    public interface IProductDetailService
    {
        Task<ProductsDetail> GetByIdAsync(string id);
        Task AddAsync(ProductsDetail productDetail);
        Task UpdateAsync(ProductsDetail productDetail);
        Task DeleteAsync(string id);
    }
}
