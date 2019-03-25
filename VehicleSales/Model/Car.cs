using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
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
        public string Engine { get; set; } 
        public int Doors { get; set; }
        public int Wheels { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CarBodyType BodyType { get; set; }
    }
}
