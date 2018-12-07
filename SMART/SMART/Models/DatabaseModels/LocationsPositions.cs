using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class LocationsPositions
    {
        public int PositionId { get; set; }
        public int LocationId { get; set; }

        public Locations Location { get; set; }
        public Positions Position { get; set; }
    }
}
