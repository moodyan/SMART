using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class WageGroups
    {
        public WageGroups()
        {
            Positions = new HashSet<Positions>();
        }

        public int WageGroupId { get; set; }
        public string WageName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Positions> Positions { get; set; }
    }
}
