using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Services.ProductDetail.Domain.Entities;
using Services.ProductDetail.Persistence.Settings;
using System.Linq.Expressions;

namespace Services.ProductDetail.Application.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductsDetail> _productsDetailCollections;

        public ProductDetailService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productsDetailCollections = database.GetCollection<ProductsDetail>(databaseSettings.ProductDetailCollectionName);
        }

        public async Task<List<ProductsDetail>> GetListWithNoDeletedAsync()
        {
            List<ProductsDetail> productsDetailList = await _productsDetailCollections.Find(x => x.DeletedTime.HasValue == false).ToListAsync();
            return productsDetailList;
        }

        public async Task<List<ProductsDetail>> GetListWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            List<ProductsDetail> productsDetailList = await _productsDetailCollections.Find(x => x.DeletedTime.HasValue == false).ToListAsync();
            productsDetailList = productsDetailList.AsQueryable().Where(predicate).ToList();
            return productsDetailList;
        }

        public async Task<List<ProductsDetail>> GetListWithDeletedAsync()
        {
            List<ProductsDetail> productsDetailList = await _productsDetailCollections.Find(x => x.DeletedTime.HasValue == true).ToListAsync();
            return productsDetailList;
        }

        public async Task<List<ProductsDetail>> GetListWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            List<ProductsDetail> productsDetailList = await _productsDetailCollections.Find(x => x.DeletedTime.HasValue == true).ToListAsync();
            productsDetailList = productsDetailList.AsQueryable().Where(predicate).ToList();
            return productsDetailList;
        }

        public async Task<ProductsDetail> GetWithDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            ProductsDetail productsDetail = await _productsDetailCollections.Find(predicate).FirstAsync();
            return productsDetail.DeletedTime.HasValue == true ?
                productsDetail :
                default;
        }
        public async Task<ProductsDetail> GetWithNoDeletedAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            ProductsDetail productsDetail = await _productsDetailCollections.Find(predicate).FirstAsync();

            return productsDetail.DeletedTime.HasValue == false ?
                productsDetail :
                default;
        }

        public async Task AddAsync(ProductsDetail productDetail)
        {
            productDetail.CreatedTime = DateTime.Now.Date;
            productDetail.UpdatedTime = DateTime.Now.Date;
            await _productsDetailCollections.InsertOneAsync(productDetail);
        }

        public async Task DeleteAsync(string id)
        {
            ProductsDetail productsDetail = await GetWithNoDeletedAsync(p => p.Id == id);
            productsDetail.DeletedTime = DateTime.Now.Date;
            await UpdateAsync(productsDetail);
        }

        public async Task UpdateAsync(ProductsDetail productDetail)
        {
            productDetail.UpdatedTime = DateTime.Now.Date;
            await _productsDetailCollections.FindOneAndReplaceAsync(x => x.Id == productDetail.Id, productDetail);
        }
    }
}
