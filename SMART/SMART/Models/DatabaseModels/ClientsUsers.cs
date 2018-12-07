using System;
using System.Collections.Generic;

namespace SMART.Models
{
    public partial class ClientsUsers
    {
        public int UserId { get; set; }
        public int ClientId { get; set; }

        public Clients Client { get; set; }
        public Users User { get; set; }
    }
}
