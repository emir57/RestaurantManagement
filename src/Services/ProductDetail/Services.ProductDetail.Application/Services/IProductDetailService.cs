using Services.ProductDetail.Domain.Entities;
using System.Linq.Expressions;

namespace Services.ProductDetail.Application.Services
{
    public interface IProductDetailService
    {
        /// <summary>
        /// Get list deleted and not deleted by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetAllList(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get list deleted and not deleted
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetAllList();


        /// <summary>
        /// Get list DeletedTime is null
        /// </summary>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithNoDeletedAsync();

        /// <summary>
        /// Get list DeletedTime is null by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get list deleted
        /// </summary>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithDeletedAsync();

        /// <summary>
        /// Get list deleted by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<ProductsDetail>> GetListWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get deleted
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ProductsDetail> GetWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        /// <summary>
        /// Get DeletedTime is null
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ProductsDetail> GetWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate);

        Task AddAsync(ProductsDetail productDetail);
        Task UpdateAsync(ProductsDetail productDetail);
        Task DeleteAsync(string id);
        Task UndoDeleteAsync(string id);
    }
}
