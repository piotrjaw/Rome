using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public Client Client { get; set; }
    }
}