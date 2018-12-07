using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class EmployeeAvailabilities
    {
        public EmployeeAvailabilities()
        {
            EmployeeDays = new HashSet<EmployeeDays>();
        }

        public int EmployeeAvailabilityId { get; set; }
        public int EmployeeId { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Employees Employee { get; set; }
        public ICollection<EmployeeDays> EmployeeDays { get; set; }
    }
}
