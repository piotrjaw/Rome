using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int NetworkId { get; set; }

        public virtual Network Network { get; set; }

        public virtual User RegionManager { get; set; }
        public virtual ICollection<User> RegionDeputyManagers { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}