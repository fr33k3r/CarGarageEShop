using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarGarageApi.Models
{
    public class Vehicle
    {

        [BsonId]
        public int? Id { get; set; }

        [BsonElement("make")]
        public string Make { get; set; } = null!;

        [BsonElement("model")]
        public string Model { get; set; } = null!;

        [BsonElement("year_model")]
        public int YearModel { get; set; } 

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("licensed")]
        public bool Licensed { get; set; }

        [BsonElement("date_added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/mm/dd}")]
        public DateTime DateAdded { get; set; }
    }
}