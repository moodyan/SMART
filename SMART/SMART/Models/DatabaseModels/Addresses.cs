using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Employees = new HashSet<Employees>();
        }

        public int AddressId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int? CityId { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Cities City { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
