using MongoDB.Bson.Serialization.Attributes;

namespace CarGarageApi.Models
{
    public class Cars
    {
        [BsonElement("location")]
        public string Location { get; set; } = null!;

        [BsonElement("vehicles")]
        public List<Vehicle> Vehicles { get; set; } = null!;
    }
}
