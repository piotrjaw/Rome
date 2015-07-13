using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class UserAssignment
    {
        public int UnitId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Role Role { get; set; }
    }
}