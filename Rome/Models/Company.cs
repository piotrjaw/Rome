using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int AdministrationId { get; set; }

        public virtual Administration Administration { get; set; }

        public virtual ICollection<User> CompanyManagers { get; set; }
        public virtual ICollection<Network> Networks { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}