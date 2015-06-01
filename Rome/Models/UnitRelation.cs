using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class UnitRelation
    {
        public int UnitRelationId { get; set; }
        public int UnitId { get; set; }
        public int ChildUnitId { get; set; }

    }
}