using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
        }

        public int CountryId { get; set; }
        public string Country { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Cities> Cities { get; set; }
    }
}
