using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
            LocationsPositions = new HashSet<LocationsPositions>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public float Wage { get; set; }
        public int? WageGroupId { get; set; }
        public bool? Active { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public WageGroups WageGroup { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<LocationsPositions> LocationsPositions { get; set; }
    }
}
