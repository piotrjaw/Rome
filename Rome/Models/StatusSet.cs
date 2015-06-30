using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class StatusSet
    {
        public int StatusSetId { get; set; }
        public string StatusSetDescription { get; set; }

        public virtual ICollection<StatusAssignment> StatusAssignments { get; set; }
    }
}