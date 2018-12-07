using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Locations
    {
        public Locations()
        {
            EmployeesLocations = new HashSet<EmployeesLocations>();
            LocationSchedules = new HashSet<LocationSchedules>();
            LocationsPositions = new HashSet<LocationsPositions>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Clients Client { get; set; }
        public ICollection<EmployeesLocations> EmployeesLocations { get; set; }
        public ICollection<LocationSchedules> LocationSchedules { get; set; }
        public ICollection<LocationsPositions> LocationsPositions { get; set; }
    }
}
