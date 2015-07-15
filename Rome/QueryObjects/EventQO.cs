using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.QueryObjects
{
    public class EventQO
    {
        public int UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid SessionId { get; set; }
    }
}