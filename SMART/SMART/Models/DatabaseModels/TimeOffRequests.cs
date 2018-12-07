using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class TimeOffRequests
    {
        public int TimeOffRequestId { get; set; }
        public DateTimeOffset? DateRequested { get; set; }
        public DateTimeOffset? RequestSubmittedDate { get; set; }
        public bool? Approved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTimeOffset? ApprovedDate { get; set; }
        public bool AllDay { get; set; }
        public int? TimeOffTypeId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public TimeOffTypes TimeOffType { get; set; }
    }
}
