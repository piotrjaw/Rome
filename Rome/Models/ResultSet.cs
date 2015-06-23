﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rome.Models
{
    public class ResultSet
    {
        public int ResultSetId { get; set; }
        public string ResultSetDescription { get; set; }

        public virtual ICollection<ResultAssignment> ResultAssignments { get; set; }
    }
}
