﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
	public class Unit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int UnitTypeId { get; set; }
        public int? MasterUnitId { get; set; }
        public ICollection<User> Managers { get; set; }
        public ICollection<User> DeputyManagers { get; set; }
        public ICollection<User> Advisors { get; set; }
        public virtual ICollection<Unit> MasteUnits { get; set; }
        public virtual ICollection<Unit> SlaveUnits{ get; set; }
        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
	}
}