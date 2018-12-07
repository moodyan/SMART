using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class WeeklySchedules
    {
        public WeeklySchedules()
        {
            EmployeeShifts = new HashSet<EmployeeShifts>();
        }

        public int WeeklyScheduleId { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Clients Client { get; set; }
        public ICollection<EmployeeShifts> EmployeeShifts { get; set; }
    }
}
