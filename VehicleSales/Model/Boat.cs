using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSales.Model
{
    public class Boat : Vehicle
    {
        public int CarryingCapacity { get; set; }
        public Boat()
        {
            VehicleType = VehicleType.Boat;
        }
    }
}
