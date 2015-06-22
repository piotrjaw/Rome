using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public int EventTypeId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public int UserId { get; set; }
        public int EventResultId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Base Base { get; set; }
        public virtual User User { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Result EventResult { get; set; }
    }
}