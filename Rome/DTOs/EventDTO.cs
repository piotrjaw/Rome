using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
    }
}