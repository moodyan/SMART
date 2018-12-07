using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class ScheduleDaysShifts
    {
        public ScheduleDaysShifts()
        {
            EmployeeShifts = new HashSet<EmployeeShifts>();
        }

        public int ScheduleDayShiftId { get; set; }
        public int ScheduleDayId { get; set; }
        public int ShiftId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ScheduleDays ScheduleDay { get; set; }
        public Shifts Shift { get; set; }
        public ICollection<EmployeeShifts> EmployeeShifts { get; set; }
    }
}
