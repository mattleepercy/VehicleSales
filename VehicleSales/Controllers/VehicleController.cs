using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleSales.Context;
using VehicleSales.Model;

namespace VehicleSales.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepo;
        public VehicleController(IVehicleRepository context)
        {
            _vehicleRepo = context;
            // Initialise with fake data
            LoadTestData();
        }

        private async void LoadTestData()
        {
            var vehicles = await _vehicleRepo.GetVehicles();
            if (vehicles.Count() == 0)
            {
                await _vehicleRepo.StoreVehicle(new Car()
                {
                    Make = "Subaru",
                    Model = "WRX",
                    BodyType = CarBodyType.Sedan,
                    Doors = 4,
                    Wheels = 4,
                    Engine = "4cyl 2.5L Turbo Petrol",
                });
                await _vehicleRepo.StoreVehicle(new Bike()
                {
                    Make = "Yamaha",
                    Model = "MT-03",
                    LearnerApproved = true,
                });
                // I know nothing about boats, so here's a random one
                await _vehicleRepo.StoreVehicle(new Boat()
                {
                    Make = "Haines Hunter",
                    Model = "650 Classic Offshore",
                    CarryingCapacity = 1234567,
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(string id)
        {
            var vehicle = await _vehicleRepo.GetVehicle(id);
            if (vehicle == null)
                return NotFound();
            return vehicle;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            var res = await _vehicleRepo.GetVehicles();
            return Ok(res);
        }

        [Route("boat")]
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostBoat([FromBody]Boat boat)
        {
            return await PostVehicle(boat);
        }

        [Route("bike")]
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostBike([FromBody]Bike bike)
        {
            return await PostVehicle(bike);
        }

        [Route("car")]
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostCar([FromBody]Car car)
        {
            return await PostVehicle(car);
        }

        async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            if (vehicle == null || vehicle.ID != null)
                return BadRequest();
            var newVehicle = await _vehicleRepo.StoreVehicle(vehicle);
            return CreatedAtAction(nameof(GetVehicle), new { id = newVehicle.ID }, newVehicle);
        }
    }
}
