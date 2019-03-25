using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleSales.Model;

namespace VehicleSales.Context
{
    public class VehicleContext : DbContext, IVehicleRepository
    {
        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {            
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        // If we don't add each of these set's individually (EVEN if we don't use them), the controller won't work properly
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Boat> Boats { get; set; }

        public async Task<Vehicle> GetVehicle(string vehicleID)
        {
            return await Vehicles.FindAsync(vehicleID);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await Vehicles.ToListAsync();
        }

        public async Task<Vehicle> StoreVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
            await SaveChangesAsync();
            return vehicle;
        }
    }
}
