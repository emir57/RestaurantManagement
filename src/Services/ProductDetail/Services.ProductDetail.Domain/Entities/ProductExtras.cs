using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Services.ProductDetail.Core.Entities;

namespace Services.ProductDetail.Domain.Entities
{
    public class ProductExtras : BaseEntity
    {

        //[BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }

        [BsonIgnore]
        public ProductsDetail ProductDetail { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string ExtraId { get; set; }

        [BsonIgnore]
        public Extra Extra { get; set; }
    }    
}
