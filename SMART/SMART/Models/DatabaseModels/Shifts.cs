using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Shifts
    {
        public Shifts()
        {
            ScheduleDaysShifts = new HashSet<ScheduleDaysShifts>();
        }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ScheduleDaysShifts> ScheduleDaysShifts { get; set; }
    }
}
