using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class BaseAssignment
    {
        public int BaseAssignmentId { get; set; }
        public int BaseId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public virtual Base Base { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}