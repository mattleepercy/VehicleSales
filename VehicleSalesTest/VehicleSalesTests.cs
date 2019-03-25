using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSales;
using VehicleSales.Controllers;
using VehicleSales.Model;

namespace Tests
{
    public class VehicleSalesTests
    {
        class MockVehicleRepository : IVehicleRepository
        {
            List<Vehicle> _vehicleList = new List<Vehicle>();
            public MockVehicleRepository(params Vehicle[] initialVehicles)
            {
                _vehicleList.AddRange(initialVehicles);
            }
            public Task<Vehicle> GetVehicle(string vehicleID)
            {
                return Task.FromResult<Vehicle>(_vehicleList.Find(vehicle => vehicle.ID == vehicleID));
            }

            public Task<IEnumerable<Vehicle>> GetVehicles()
            {
                return Task.FromResult<IEnumerable<Vehicle>>(_vehicleList);
            }

            public Task<Vehicle> StoreVehicle(Vehicle vehicle)
            {
                vehicle.ID = Guid.NewGuid().ToString();
                _vehicleList.Add(vehicle);
                return Task.FromResult<Vehicle>(vehicle);
            }
        }

        VehicleController _controller;
        IVehicleRepository _repo;
        Car testCar1 = new Car()
        {
            ID = "TESTCAR1"
        };
        Bike testBike1 = new Bike()
        {
            ID = "TESTBIKE1",
        };
        Boat testBoat1 = new Boat()
        {
            ID = "TESTBOAT1",
        };
        [SetUp]
        public void Setup()
        {
            _controller = new VehicleController(new MockVehicleRepository(testBike1, testBoat1, testCar1));
            //var mock = new Mock<IVehicleRepository>();
            // mock.Setup(p => p.GetVehicle("ID")).Returns(Task.FromResult<Vehicle>(new Car() { }));
            // _controller = new VehicleController(mock.Object);
        }

        [Test]
        public async Task Test_HasVehicleID()
        {
            var result = await _controller.GetVehicle(testCar1.ID);
            Assert.AreEqual(testCar1, result.Value);
        }

        [Test]
        public async Task Test_NonExistantVehicleID()
        {
            var result = await _controller.GetVehicle("INVALID");
            Assert.IsInstanceOf(typeof(NotFoundResult), result.Result);
            Assert.IsNull(result.Value);
        }

        [Test]
        public async Task Test_GetVehicles()
        {
            var result = await _controller.GetVehicles();
            var vehicles = (result.Result as ObjectResult).Value as IEnumerable<Vehicle>;
            Assert.AreEqual(3, vehicles.Count());
        }

        [Test]
        public async Task Test_PostCar()
        {
            var car = new Car()
            {
                Model = "Unique_Car_Model_83978"
            };
            var result = await _controller.PostCar(car);
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            var val = createdAtActionResult.Value as Car;
            Assert.AreEqual(car.Model, val.Model);
            Assert.IsNotNull(val.ID);
        }

        [Test]
        public async Task Test_GetVehiclesAfterStoreVehicle()
        {
            var car = new Car()
            {
                Model = "Unique_Car_Model_83978"
            };
            var result = await _controller.PostCar(car);
            var result2 = await _controller.GetVehicles();
            var vehicles = (result2.Result as ObjectResult).Value as IEnumerable<Vehicle>;
            Assert.AreEqual(4, vehicles.Count());
        }
    }
}