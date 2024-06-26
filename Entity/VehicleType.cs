﻿using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VehicleTaxInfo> VehicleTaxInfos { get; set; } = new List<VehicleTaxInfo>();
    }

}
