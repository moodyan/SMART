using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class LocationSchedules
    {
        public LocationSchedules()
        {
            ScheduleDays = new HashSet<ScheduleDays>();
        }

        public int LocationScheduleId { get; set; }
        public int LocationId { get; set; }
        public string ScheduleName { get; set; }
        public DateTimeOffset? ScheduleStartDate { get; set; }
        public DateTimeOffset? ScheduleEndDate { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Locations Location { get; set; }
        public ICollection<ScheduleDays> ScheduleDays { get; set; }
    }
}
