using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class EventAction
    {
        public int EventActionId { get; set; }
        public DateTime EventActionDate { get; set; }
        public int EventId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public int UserId { get; set; }
        public int EventResultId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Base Base { get; set; }
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
        public virtual Result EventResult { get; set; }
    }
}