using Services.ProductDetail.Domain.Entities;
using System.Linq.Expressions;

namespace Services.ProductDetail.Application.Services
{
    public interface IProductDetailService
    {
        //Get methods should not return deletedtime non null productsdetails
        Task<List<ProductsDetail>> GetListAsync(Expression<Func<ProductsDetail, bool>> predicate);
        Task<ProductsDetail> GetAsync(Expression<Func<ProductsDetail, bool>> predicate);
        Task AddAsync(ProductsDetail productDetail);
        Task UpdateAsync(ProductsDetail productDetail);
        Task DeleteAsync(string id);
    }
}
