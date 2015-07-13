using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class Base
    {
        public int BaseId { get; set; }
        public string BaseName { get; set; }
        public int BaseOptionSetId { get; set; }
        public DateTime BaseStart { get; set; }
        public DateTime BaseEnd { get; set; }

        public virtual BaseOptionSet BaseOptionSet { get; set; }
    }
}