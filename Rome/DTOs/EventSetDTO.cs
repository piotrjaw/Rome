using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rome.Models;

namespace Rome.DTOs
{
    public class EventSetDTO
    {
        public int EventSetId { get; set; }
        public string EventSetDescription { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
