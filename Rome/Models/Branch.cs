using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual User BranchManager { get; set; }
        public virtual ICollection<User> BranchDeputyManagers { get; set; }
        public virtual IEnumerable<User> Advisors { get; set; }

        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
    }
}