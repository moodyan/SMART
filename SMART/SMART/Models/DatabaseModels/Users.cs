using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class Users
    {
        public Users()
        {
            ClientsUsers = new HashSet<ClientsUsers>();
            Employees = new HashSet<Employees>();
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<ClientsUsers> ClientsUsers { get; set; }
        public ICollection<Employees> Employees { get; set; }
        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
