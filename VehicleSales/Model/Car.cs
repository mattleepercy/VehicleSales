using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSales.Model
{
    public class Car : Vehicle
    {
        public Car()
        {
            VehicleType = VehicleType.Car;
        }
        [Required(AllowEmptyStrings = false)]
        public string Engine { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public int Wheels { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CarBodyType BodyType { get; set; }
    }
}
