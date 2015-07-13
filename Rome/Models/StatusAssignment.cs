using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class StatusAssignment
    {
        public int StatusId { get; set; }
        public int StatusSetId { get; set; }

        public virtual Status Status { get; set; }
        public virtual StatusSet StatusSet { get; set; }
    }
}