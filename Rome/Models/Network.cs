using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Network
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual User NetworkManager { get; set; }
        public virtual ICollection<User> NetworkDeputyManagers { get; set; }
        public virtual ICollection<Region> Regions { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}