using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSales.Model
{
    public class Boat : Vehicle
    {
        [Required]
        public int CarryingCapacity { get; set; }
        public Boat()
        {
            VehicleType = VehicleType.Boat;
        }
    }
}
