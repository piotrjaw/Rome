using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rome.Models;

namespace Rome.DTOs
{
    public class StatusSetDTO
    {
        public int StatusSetId { get; set; }
        public string StatusSetDescription { get; set; }
        public IEnumerable<Status> Statuses {get; set;}
    }
}