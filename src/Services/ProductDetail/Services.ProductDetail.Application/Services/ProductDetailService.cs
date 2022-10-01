using MongoDB.Driver;
using Services.ProductDetail.Domain.Entities;
using Services.ProductDetail.Persistence.Settings;

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

        public async Task AddAsync(ProductsDetail productDetail)
        {
            await _productsDetailCollections.InsertOneAsync(productDetail);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductsDetail productDetail)
        {
            throw new NotImplementedException();
        }
    }
}
