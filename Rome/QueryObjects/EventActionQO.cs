using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.QueryObjects
{
    public class EventActionQO
    {
        public DateTime? EventActionDate { get; set; }
        public int EventId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public int UserId { get; set; }
        public int ResultId { get; set; }
        public int StatusId { get; set; }
        public int? SetEventId { get; set; }
        public DateTime? SetEventActionDate { get; set; }
    }
}