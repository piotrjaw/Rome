using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class RoleAssignment
    {
        public int RoleAssignmentId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }
    }
}