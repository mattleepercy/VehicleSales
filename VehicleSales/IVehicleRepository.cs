using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSales.Model;

namespace VehicleSales
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(string vehicleID);
        Task<IEnumerable<Vehicle>> GetVehicles();
        Task<Vehicle> StoreVehicle(Vehicle vehicle);
    }
}
