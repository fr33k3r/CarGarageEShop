using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarGarageApi.Models
{
    public class Location
    {
        [BsonElement("lat")]
        public string Lat { get; set; } = null!;

        [BsonElement("long")]
        public string Long { get; set; } = null!;

    }
}
