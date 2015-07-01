using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class EventActionDTO
    {
        public int EventActionId { get; set; }
        public DateTime? EventActionDate { get; set; }
        public int EventId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public int UserId { get; set; }
        public int ResultId { get; set; }
        public int StatusId { get; set; }
        public int? SetEventId { get; set; }
        public DateTime? SetEventActionDate { get; set; }
        public string Comment { get; set; }

        public Client Client { get; set; }
        public Event Event { get; set; }
        public Status Status { get; set; }
    }
}