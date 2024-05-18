using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class VehicleTaxInfo
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int VehicleId { get; set; }
        public bool IsTaxFree { get; set; }

        public virtual City City { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
