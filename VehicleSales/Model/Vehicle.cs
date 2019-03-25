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
        [Required(AllowEmptyStrings = false)]
        public string Make { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public VehicleType VehicleType { get; protected set; }
    }
}
