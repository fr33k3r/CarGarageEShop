using CarGarageApi.Models;
using CarGarageApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGarageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class WarehousesController : ControllerBase
    {
        private readonly CarGarageService _carGarageService;

        public WarehousesController(CarGarageService carGarageService) =>
            _carGarageService = carGarageService;

        //[HttpGet]
        //public async Task<List<Warehouse>> Get() =>
        //    await _carGarageService.GetAsync();

        [HttpGet]
        public async Task<List<Vehicle>> Get()
        {
            List<Warehouse> warehouses  = await _carGarageService.GetAsync();

            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (Warehouse warehouse in warehouses)
            {               
                foreach(var vehicle in warehouse.Cars.Vehicles)
                {
                    vehicles.Add(vehicle);
                }                         
            }
            return vehicles.OrderBy(x => x.DateAdded).ToList();
        }

        [HttpGet("{id}")]       
        public async Task<ActionResult<Warehouse>> Get(string id)
        {
            var warehouse = await _carGarageService.GetAsync(id);

            if (warehouse is null)
            {
                return NotFound();
            }

            return warehouse;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Warehouse newWarehouse)
        {
            await _carGarageService.CreateAsync(newWarehouse);

            return CreatedAtAction(nameof(Get), new { id = newWarehouse.Id }, newWarehouse);
        }

        [HttpPut("{id}")]        
        public async Task<IActionResult> Update(string id, Warehouse updatedWarehouse)
        {
            var warehouse = await _carGarageService.GetAsync(id);

            if (warehouse is null)
            {
                return NotFound();
            }

            updatedWarehouse.Id = warehouse.Id;

            await _carGarageService.UpdateAsync(id, updatedWarehouse);

            return NoContent();
        }

        [HttpDelete("{id}")]        
        public async Task<IActionResult> Delete(string id)
        {
            var warehouse = await _carGarageService.GetAsync(id);

            if (warehouse is null)
            {
                return NotFound();
            }

            await _carGarageService.RemoveAsync(warehouse.Id);

            return NoContent();
        }
    }
}
