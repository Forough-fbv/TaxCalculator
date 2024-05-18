using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class CongestionTax
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public decimal Amount { get; set; }

        public virtual City City { get; set; }
    }

}
