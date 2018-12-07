using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class TimeOffTypes
    {
        public TimeOffTypes()
        {
            TimeOffRequests = new HashSet<TimeOffRequests>();
        }

        public int TimeOffTypeId { get; set; }
        public string TypeName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<TimeOffRequests> TimeOffRequests { get; set; }
    }
}
