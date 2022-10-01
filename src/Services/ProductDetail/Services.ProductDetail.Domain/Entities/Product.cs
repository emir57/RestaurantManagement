using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Services.ProductDetail.Core.Entities;

namespace Services.ProductDetail.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Feature Feature { get; set; }

        public Product()
        {
        }

        public Product(string name, string shortDescription, decimal price, string image, Feature feature) : this()
        {
            Name = name;
            ShortDescription = shortDescription;
            Price = price;
            Image = image;
            Feature = feature;
        }
    }
}
