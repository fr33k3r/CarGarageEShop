using CarGarageApi.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGarageApi.Tests.Services
{
    public class CarGarageServiceFake
    {
        private readonly List<Warehouse> _WarehousesCollection;

        public CarGarageServiceFake()
        {
            _WarehousesCollection = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Name = "Warehouse A",
                    Id = "1",
                    Location = new Location() {
                        Lat = "47.13111",
                        Long = "-61.54801"
                    },
                    Cars = new Cars() {
                        Location =  "West wing",
                        Vehicles =  new List<Vehicle>()
                        {
                            new Vehicle() {
                                Id = 1,
                                Make =  "Volkswagen",
                                Model = "Jetta III",
                                YearModel = 1995,
                                Price = 12947.52,
                                Licensed = true,
                                DateAdded = "2018-09-18"
                            },
                            new Vehicle() {
                                Id = 2,
                                Make =  "Chevrolet",
                                Model = "Corvette",
                                YearModel = 2004,
                                Price = 20019.64,
                                Licensed = true,
                                DateAdded = "2018-01-27"
                            },
                            new Vehicle() {
                                Id = 3,
                                Make =  "Ford",
                                Model = "Expedition EL",
                                YearModel = 2008,
                                Price = 27323.42,
                                Licensed = false,
                                DateAdded = "2018-07-03"
                            }
                        }
                    }

                },
                new Warehouse()
                {
                    Name = "Warehouse B",
                    Id = "2",
                    Location = new Location() {
                        Lat = "15.95386",
                        Long = "7.06246"
                    },
                    Cars = new Cars() {
                        Location =  "East wing",
                        Vehicles =  new List<Vehicle>()
                        {
                            new Vehicle() {
                                Id = 20,
                                Make =  "Maserati",
                                Model = "Coupe",
                                YearModel = 2005,
                                Price = 19957.71,
                                Licensed = false,
                                DateAdded = "2017-11-14"
                            },
                            new Vehicle() {
                                Id = 21,
                                Make =  "Isuzu",
                                Model = "Rodeo",
                                YearModel = 1998,
                                Price = 6303.99,
                                Licensed = false,
                                DateAdded = "2017-12-03"
                            },
                            new Vehicle() {
                                Id = 22,
                                Make =  "Infiniti",
                                Model = "I",
                                YearModel = 2002,
                                Price = 6910.16,
                                Licensed = true,
                                DateAdded = "2017-10-15"
                            }
                        }
                    }

                }
            };               
        }

        public async Task<List<Warehouse>> GetAsync() => await Task.FromResult(_WarehousesCollection);
        
        public async Task<Warehouse?> GetAsync(string id) => await Task.FromResult(_WarehousesCollection.Where(x => x.Id == id).FirstOrDefault());

        public async Task CreateAsync(Warehouse newWarehouse) => await Task.Run( () =>_WarehousesCollection.Add(newWarehouse));

        public async Task<Warehouse?> UpdateAsync(string id, Warehouse updatedWarehouse)
        {
            var warehouse = await Task.FromResult(_WarehousesCollection?.FirstOrDefault(x => x.Id == id));
            await Task.FromResult(warehouse = updatedWarehouse);
            return warehouse;
        }

        public async Task RemoveAsync(string id) => await Task.FromResult(_WarehousesCollection.Remove(_WarehousesCollection.First(x => x.Id == id)));        
    }
}
