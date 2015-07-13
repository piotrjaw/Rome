using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime? EventDate { get; set; }
        public int EventTypeId { get; set; }
        public int ClientId { get; set; }
        public int BaseId { get; set; }
        public int UserId { get; set; }
        public int ResultId { get; set; }
        public int? ResignationReasonId { get; set; }
        public int StatusId { get; set; }
        public int? SetEventTypeId { get; set; }
        public DateTime? SetEventDate { get; set; }
        public string Comment { get; set; }

        public virtual Client Client { get; set; }
        public virtual Base Base { get; set; }
        public virtual User User { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual Result Result { get; set; }
        public virtual ResignationReason ResignationReason { get; set; }
        public virtual Status Status { get; set; }
        public virtual EventType SetEventType { get; set; }
    }
}