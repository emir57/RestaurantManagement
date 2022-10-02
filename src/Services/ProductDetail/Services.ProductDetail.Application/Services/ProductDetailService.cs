using MongoDB.Driver;
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

        public async Task<List<ProductsDetail>> GetListAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            List<ProductsDetail> productsDetailList = await _productsDetailCollections.Find(predicate).ToListAsync();
            //need to fill "ProductExtras" and "Feature" after other microservices done.
            return productsDetailList;
        }

        public async Task<ProductsDetail> GetAsync(Expression<Func<ProductsDetail, bool>> predicate)
        {
            ProductsDetail productsDetail = await _productsDetailCollections.Find(predicate).FirstAsync();
            //need to fill "ProductExtras" and "Feature" after other microservices done.
            return productsDetail;
        }

        public async Task AddAsync(ProductsDetail productDetail)
        {
            await _productsDetailCollections.InsertOneAsync(productDetail);
        }

        public async Task DeleteAsync(string id)
        {
            await _productsDetailCollections.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(ProductsDetail productDetail)
        {
            await _productsDetailCollections.FindOneAndReplaceAsync(x => x.Id == productDetail.Id, productDetail);
        }
    }
}
