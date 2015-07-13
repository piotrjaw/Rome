using System;
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
        public int? SuperiorUnitId { get; set; }

        public virtual UnitType UnitType { get; set; }
        public virtual Unit SuperiorUnit { get; set; }
	}
}