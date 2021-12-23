using CarGarageApi.Controllers;
using CarGarageApi.Models;
using CarGarageApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarGarageApi.Tests.Controllers
{
    public class WarehousesControllerTests
    {
        private readonly CarGarageDatabaseSettings _carGarageDatabaseSettings;
        private readonly Mock<CarGarageService> _mockService;
        private readonly WarehousesController _controller;
        public WarehousesControllerTests()
        {
            _carGarageDatabaseSettings = new CarGarageDatabaseSettings()
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "test",
                CarGarageCollectionName = "CarGarage"
            };

            var _carGarageDatabaseOptions = Options.Create(_carGarageDatabaseSettings);

            _mockService = new Mock<CarGarageService>(_carGarageDatabaseOptions);
            _controller = new WarehousesController(_mockService.Object);

        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsListOfVehicles()

        {
            // Act
            var okResult = await _controller.Get();
            // Assert
            Assert.IsType<List<VehicleFullDetails>>(okResult);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItems()
        {
            //Act
            var okResult = await _controller.Get();

            // Assert
            Assert.Equal(80, okResult.Count);            
        }

        [Fact]
        public async Task GetById_UnknownIdPassed_ReturnsNull()
        {
            //Arrange
            string Id = "81";

            // Act
            var notFoundResult = await _controller.Get(Id);

            // Assert
            Assert.Null(notFoundResult.Value);
        }

        [Fact]
        public async Task GetById_ExistingIdPassed_ReturnsWarehouseObject()
        {
            //Arrange
            string Id = "1";

            // Act
            var okResult = await _controller.Get(Id);

            // Assert
            Assert.IsType<CarGarageApi.Models.Warehouse>(okResult.Value);
        }

        [Fact]
        public async Task GetById_ExistingIdPassed_ReturnsRightItem()
        {
            //Arrange
            string Id = "1";

            // Act
            var okResult = await _controller.Get(Id);

            // Assert
            Assert.IsType<Warehouse>(okResult.Value);
            Assert.Equal(Id, okResult?.Value?.Id);
        }
    }
}
