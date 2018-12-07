using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Cities
    {
        public Cities()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Countries Country { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
