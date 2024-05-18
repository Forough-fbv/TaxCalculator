using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class CongestionConfig
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public decimal MaxAmountPerDay { get; set; }
        public int SingleChargeRuleMinute { get; set; }

        public virtual City City { get; set; }
    }

}
