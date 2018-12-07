using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class EmployeeDays
    {
        public int EmployeeDayId { get; set; }
        public string DayName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? Active { get; set; }
        public int EmployeeAvailabilityId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public EmployeeAvailabilities EmployeeAvailability { get; set; }
    }
}
