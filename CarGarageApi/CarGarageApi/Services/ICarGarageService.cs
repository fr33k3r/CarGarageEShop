using CarGarageApi.Models;

namespace CarGarageApi.Services
{
    public interface ICarGarageService
    {
        Task<List<Warehouse>> GetAsync();

        Task<Warehouse?> GetAsync(string id);

        Task CreateAsync(Warehouse newWarehouse);

        Task UpdateAsync(string id, Warehouse updatedWarehouse);

        Task RemoveAsync(string id);
       
    }
}
