using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class EventSet
    {
        public int EventSetId { get; set; }
        public string EventSetDescription { get; set; }

        public virtual ICollection<EventAssignment> EventAssignments { get; set; }
    }
}
