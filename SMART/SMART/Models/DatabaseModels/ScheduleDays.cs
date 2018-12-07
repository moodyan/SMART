using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class ScheduleDays
    {
        public ScheduleDays()
        {
            ScheduleDaysShifts = new HashSet<ScheduleDaysShifts>();
        }

        public int ScheduleDayId { get; set; }
        public string DayName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? Active { get; set; }
        public int LocationScheduleId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public LocationSchedules LocationSchedule { get; set; }
        public ICollection<ScheduleDaysShifts> ScheduleDaysShifts { get; set; }
    }
}
