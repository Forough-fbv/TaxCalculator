using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Entity
{
    public class OffDay
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public DayOfWeek Day { get; set; }
        public bool IsWorkingDay { get; set; }

        public virtual City City { get; set; }
    }

}
