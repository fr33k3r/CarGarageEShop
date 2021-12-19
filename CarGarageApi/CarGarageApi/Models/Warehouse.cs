using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarGarageApi.Models
{
    public class Warehouse
    {
        [BsonId]        
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("location")]
        public Location Location { get; set; } = null!;

        [BsonElement("cars")]
        public Cars Cars { get; set; } = null!;
     
    }
}
