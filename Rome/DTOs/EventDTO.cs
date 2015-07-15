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
        public DateTime? SetEventDate { get; set; }
        public string Comment { get; set; }

        public Client Client { get; set; }
        public Base Base { get; set; }
        public User User { get; set; }
        public EventType EventType { get; set; }
        public Result Result { get; set; }
        public ResignationReason ResignationReason { get; set; }
        public Status Status { get; set; }
        public EventType SetEventType { get; set; }
    }
}