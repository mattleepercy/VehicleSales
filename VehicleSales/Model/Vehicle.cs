using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSales.Model
{
    public abstract class Vehicle
    {
        [Key]
        public string ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleType VehicleType { get; protected set; }
    }
}
