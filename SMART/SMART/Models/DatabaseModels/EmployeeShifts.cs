using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class EmployeeShifts
    {
        public int EmployeeShiftId { get; set; }
        public int? ScheduleDayShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTimeOffset ShiftDate { get; set; }
        public int WeeklyScheduleId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Employees Employee { get; set; }
        public ScheduleDaysShifts ScheduleDayShift { get; set; }
        public WeeklySchedules WeeklySchedule { get; set; }
    }
}
