using CarGarageApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarGarageApi.Services
{
    public class CarGarageService
    {
        private readonly IMongoCollection<Warehouse> _WarehousesCollection;        

        public CarGarageService(
            IOptions<CarGarageDatabaseSettings> CarGarageDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                CarGarageDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                CarGarageDatabaseSettings.Value.DatabaseName);

            _WarehousesCollection = mongoDatabase.GetCollection<Warehouse>(
                CarGarageDatabaseSettings.Value.CarGarageCollectionName);
        }

        public async Task<List<Warehouse>> GetAsync() =>
            await _WarehousesCollection.Find(_ => true).ToListAsync();

        public async Task<Warehouse?> GetAsync(string id) =>
            await _WarehousesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Warehouse newWarehouse) =>
            await _WarehousesCollection.InsertOneAsync(newWarehouse);

        public async Task UpdateAsync(string id, Warehouse updatedWarehouse) =>
            await _WarehousesCollection.ReplaceOneAsync(x => x.Id == id, updatedWarehouse);

        public async Task RemoveAsync(string id) =>
            await _WarehousesCollection.DeleteOneAsync(x => x.Id == id);

    }
}
