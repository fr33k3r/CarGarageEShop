using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarGarageApi.Models
{
    public class VehicleFullDetails
    {

        [BsonId]
        public int? Id { get; set; }

        [BsonElement("name")]
        public string WareHouseName { get; set; } = null!;

        [BsonElement("location")]
        public Location WareHouseLocation { get; set; } = null!;

        [BsonElement("location")]
        public string CarsLocation { get; set; } = null!;



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
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DateAdded { get; set; }

       


    }
}