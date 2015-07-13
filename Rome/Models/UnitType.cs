using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class UnitType
    {
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public string FirstRoleName { get; set; }
        public string SecondRoleName { get; set; }
        public string ThirdRoleName { get; set; }
        public int? SuperiorUnitTypeId { get; set; }

        public virtual UnitType SuperiorUnitType { get; set; }
    }
}