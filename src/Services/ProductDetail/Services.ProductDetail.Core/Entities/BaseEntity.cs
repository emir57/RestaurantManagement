using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.ProductDetail.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedTime { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DeletedTime { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(string id) : this()
        {
            Id = id;
            CreatedTime = DateTime.Now;
        }
    }
}
