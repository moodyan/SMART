using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Clients
    {
        public Clients()
        {
            ClientsUsers = new HashSet<ClientsUsers>();
            Locations = new HashSet<Locations>();
            Roles = new HashSet<Roles>();
            WeeklySchedules = new HashSet<WeeklySchedules>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ClientsUsers> ClientsUsers { get; set; }
        public ICollection<Locations> Locations { get; set; }
        public ICollection<Roles> Roles { get; set; }
        public ICollection<WeeklySchedules> WeeklySchedules { get; set; }
    }
}
