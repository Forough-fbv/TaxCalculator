using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class OffDate
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public virtual City City { get; set; }
    }

}
