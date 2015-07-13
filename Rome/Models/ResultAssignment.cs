using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rome.Models
{
    public class ResultAssignment
    {
        public int ResultId { get; set; }
        public int ResultSetId { get; set; }

        public virtual Result Result { get; set; }
        public virtual ResultSet ResultSet { get; set; }
    }
}