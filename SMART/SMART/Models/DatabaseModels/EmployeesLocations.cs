using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class EmployeesLocations
    {
        public int EmployeeId { get; set; }
        public int LocationId { get; set; }

        public Employees Employee { get; set; }
        public Locations Location { get; set; }
    }
}
