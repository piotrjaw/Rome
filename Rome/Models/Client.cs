using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Owner { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<BaseAssignment> BaseAssignments { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}