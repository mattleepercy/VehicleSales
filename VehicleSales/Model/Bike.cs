﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSales.Model
{
    public class Bike : Vehicle
    {
        [Required]
        public bool LearnerApproved { get; set; }
        public Bike()
        {
            VehicleType = VehicleType.Bike;
        }
    }
}
