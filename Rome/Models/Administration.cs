using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Administration
    {
        public int AdministrationId { get; set; }

        public virtual ICollection<User> Admins { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}