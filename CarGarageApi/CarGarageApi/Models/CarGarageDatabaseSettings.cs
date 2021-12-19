namespace CarGarageApi.Models
{
    public class CarGarageDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CarGarageCollectionName { get; set; } = null!;
    }
}
