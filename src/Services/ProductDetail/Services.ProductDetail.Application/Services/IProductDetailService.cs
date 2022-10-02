using Services.ProductDetail.Domain.Entities;
using System.Linq.Expressions;

namespace Services.ProductDetail.Application.Services
{
    public interface IProductDetailService
    {
        /// <summary>
        /// Get list by DeletedTime is null
        /// </summary>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithNoDeletedAsync();

        /// <summary>
        /// Get list by predicate and DeletedTime is null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get list by deleted
        /// </summary>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithDeletedAsync();

        /// <summary>
        /// Get list by predicate and deleted
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get by deleted
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ProductsDetail> GetWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get by DeletedTime is null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ProductsDetail> GetWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        Task AddAsync(ProductsDetail productDetail);
        Task UpdateAsync(ProductsDetail productDetail);
        Task DeleteAsync(string id);
    }
}
