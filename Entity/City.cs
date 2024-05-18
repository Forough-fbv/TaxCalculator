using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CongestionConfig> CongestionConfigs { get; set; } = new List<CongestionConfig>();
        public virtual ICollection<CongestionTax> CongestionTaxes { get; set; } = new List<CongestionTax>();
        public virtual ICollection<OffDay> OffDays { get; set; } = new List<OffDay>();
        public virtual ICollection<OffDate> OffDates { get; set; } = new List<OffDate>();
        public virtual ICollection<VehicleTaxInfo> VehicleTaxInfos { get; set; } = new List<VehicleTaxInfo>();
    }

}
