using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public Clients Client { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
