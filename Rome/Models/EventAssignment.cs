using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class EventAssignment
    {
        public int EventAssignmentId { get; set; }
        public int EventId { get; set; }
        public int EventSetId { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventSet EventSet { get; set; }
    }
}
