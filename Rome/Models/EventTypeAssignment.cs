using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class EventTypeAssignment
    {
        public int EventTypeId { get; set; }
        public int EventTypeSetId { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual EventTypeSet EventTypeSet { get; set; }
    }
}
