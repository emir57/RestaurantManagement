namespace Services.ProductDetail.API.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ProductDetailCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
